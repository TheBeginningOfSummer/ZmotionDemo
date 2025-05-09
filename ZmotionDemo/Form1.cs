﻿using cszmcaux;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZmotionDemo
{
    public partial class Form1 : Form
    {
        #region 组件与控制变量
        readonly KeyValueLoader config = new KeyValueLoader("Configuration.json", "Config");
        readonly MotionControlCard card = new MotionControlCard();
        readonly ManualResetEvent suspend = new ManualResetEvent(true);
        private bool isAuto = false;
        private bool isLaserWork = false;
        private bool isSuspend = true;
        #endregion

        public Form1()
        {
            InitializeComponent();
            try
            {
                LoadConfig();
                MessageRecorder.DocumentPath = "Log";
                if (card.Connect(TB_IP.Text))
                {
                    MessageBox.Show("控制器链接成功!", "提示");
                    InitializeAxes();
                    InitializeAxesConfig();
                    Task.Run(UpdateCardStatus);
                    card.Axes[1].MovingAction += YAxisMoving;
                    card.Axes[0].MovingTimeout += AxisTimeout;
                    card.Axes[1].MovingTimeout += AxisTimeout;
                    BGW_Auto.DoWork += BGW_Auto_DoWork;
                    BGW_Auto.WorkerSupportsCancellation = true;
                    BGW_Auto.RunWorkerCompleted += BGW_Auto_RunWorkerCompleted;
                    card.Axes[0].AbsoluteMove(0);
                    card.Axes[1].AbsoluteMove(0);
                }
                else
                {
                    MessageBox.Show("控制器链接失败，请检测IP地址!", "警告");
                    MessageRecorder.RecordError("控制卡连接失败。", "检查连接参数与连接线，重启程序。");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"初始化控制卡失败。{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageRecorder.RecordError($"初始化控制卡失败。{e.Message}", "检查连接与参数设置。");
            }
        }

        #region 事件委托
        private void BGW_Auto_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            isLaserWork = false;
            card.SetOutput(GetInt(TB_LaserSignal.Text), 0);
        }

        private void BGW_Auto_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            AutoRun();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //断开链接
                card.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("关闭失败。" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void YAxisMoving(float position)
        {
            if (!isLaserWork) return;
            if (int.TryParse(TB_LaserSignal.Text, out int laserSignal))
            {
                if (RB_模式1.Checked)
                {
                    if (float.TryParse(TB_LaserOnPos.Text, out float laserOnPos) && float.TryParse(TB_LaserOffPos.Text, out float laserOffPos))
                    {
                        if (card.Axes[1].Direction > 0)
                        {
                            if (position > laserOnPos)
                            {
                                //开激光
                                card.SetOutput(laserSignal, 1);
                            }
                            if (position > laserOffPos)
                            {
                                //关激光
                                card.SetOutput(laserSignal, 0);
                            }
                        }
                        else if (card.Axes[1].Direction < 0)
                        {
                            if (position < laserOnPos)
                            {
                                //关激光
                                card.SetOutput(laserSignal, 0);
                            }
                            if (position < laserOffPos && position > laserOnPos)
                            {
                                //开激光
                                card.SetOutput(laserSignal, 1);
                            }
                        }
                    }
                    else
                    {
                        Shutdown();
                        MessageBox.Show("输入正确激光开启或关闭位置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (RB_模式2.Checked)
                {
                    if (float.TryParse(TB_LaserOnPos.Text, out float laserOnPos) && float.TryParse(TB_LaserOffPos.Text, out float laserOffPos))
                    {
                        if (card.Axes[1].Direction > 0)
                        {
                            if (position > laserOnPos)
                            {
                                //开激光
                                card.SetOutput(laserSignal, 1);
                            }
                            if (position > laserOffPos)
                            {
                                //关激光
                                card.SetOutput(laserSignal, 0);
                            }
                        }
                    }
                    else
                    {
                        Shutdown();
                        MessageBox.Show("输入正确激光开启或关闭位置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void AxisTimeout()
        {
            Shutdown();
            MessageBox.Show("运动超时。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageRecorder.RecordError($"运动超时。", "检查超时时间设置。");
        }

        #endregion

        #region 方法
        public static void OnThread(Control control, Action method)
        {
            if (control.IsHandleCreated)
                control.Invoke(method);
            else
                method();
        }

        public void InitializeAxes()
        {
            card.Axes.Clear();
            card.AddAxis(GetInt(TB_XAxisType.Text, "X轴类型读取失败。"), 0, GetFloat(TB_X脉冲当量.Text, "脉冲当量X读取失败。"));
            card.AddAxis(GetInt(TB_YAxisType.Text, "Y轴类型读取失败。"), 1, GetFloat(TB_Y脉冲当量.Text, "脉冲当量Y读取失败。"));
        }

        public void InitializeAxesConfig()
        {
            card.Axes[0].Initialize(GetInt(TB_XPulseType.Text), GetFloat(TB_X运行速度.Text), GetFloat(TB_X加速度.Text), GetFloat(TB_X减速度.Text), GetFloat(TB_XS曲线.Text), GetFloat(TB_XCreepSpeed.Text), GetFloat(TB_XFastDec.Text));
            card.Axes[1].Initialize(GetInt(TB_YPulseType.Text), GetFloat(TB_Y运行速度.Text), GetFloat(TB_Y加速度.Text), GetFloat(TB_Y减速度.Text), GetFloat(TB_YS曲线.Text), GetFloat(TB_YCreepSpeed.Text), GetFloat(TB_YFastDec.Text));
            card.Axes[0].InitializeDatum(GetInt(TB_X原点信号.Text, "X原点信号设置数据读取失败。"));
            card.Axes[1].InitializeDatum(GetInt(TB_Y原点信号.Text, "Y原点信号设置数据读取失败。"));
            card.Axes[0].SetLimitSignal(GetInt(TB_X正限位信号.Text), GetInt(TB_X负限位信号.Text));
            card.Axes[1].SetLimitSignal(GetInt(TB_Y正限位信号.Text), GetInt(TB_Y负限位信号.Text));
            card.Axes[0].SetLimit(GetFloat(TB_X正软限位.Text), GetFloat(TB_X负软限位.Text));
            card.Axes[1].SetLimit(GetFloat(TB_Y正软限位.Text), GetFloat(TB_Y负软限位.Text));
        }

        private void UpdateCardStatus()
        {
            while (true)
            {
                Thread.Sleep(100);
                OnThread(LB_当前X轴位置, new Action(() => LB_当前X轴位置.Text = $"当前位置：{card.Axes[0].CurrentPosition:f2}"));
                OnThread(LB_当前Y轴位置, new Action(() => LB_当前Y轴位置.Text = $"当前位置：{card.Axes[1].CurrentPosition:f2}"));
                OnThread(LB_XSpeed, new Action(() => LB_XSpeed.Text = $"X轴速度：{card.Axes[0].GetMSpeed():f2}"));
                OnThread(LB_YSpeed, new Action(() => LB_YSpeed.Text = $"Y轴速度：{card.Axes[1].GetMSpeed():f2}"));
                OnThread(LB_Test1, new Action(() => LB_Test1.Text = $"X轴当前位置：{card.Axes[0].CurrentPosition:f2}"));
                OnThread(LB_Test2, new Action(() => LB_Test2.Text = $"Y轴当前位置：{card.Axes[1].CurrentPosition:f2}"));
            }
        }

        public void LoadConfig()
        {
            TB_X脉冲当量.Text = config.Load("X脉冲当量");
            TB_X运行速度.Text = config.Load("X运行速度");
            TB_X加速度.Text = config.Load("X加速度");
            TB_X减速度.Text = config.Load("X减速度");
            TB_XS曲线.Text = config.Load("XS曲线");
            TB_XCreepSpeed.Text = config.Load("X爬行速度");
            TB_X原点信号.Text = config.Load("X原点信号");
            TB_X正限位信号.Text = config.Load("X正限位信号");
            TB_X负限位信号.Text = config.Load("X负限位信号");
            TB_X正软限位.Text = config.Load("X正软限位");
            TB_X负软限位.Text = config.Load("X负软限位");
            TB_XPulseType.Text = config.Load("X轴脉冲类型");
            TB_XAxisType.Text = config.Load("X轴类型");
            TB_XFastDec.Text = config.Load("X刹车减速度");

            TB_Y脉冲当量.Text = config.Load("Y脉冲当量");
            TB_Y运行速度.Text = config.Load("Y运行速度");
            TB_Y加速度.Text = config.Load("Y加速度");
            TB_Y减速度.Text = config.Load("Y减速度");
            TB_YS曲线.Text = config.Load("YS曲线");
            TB_YCreepSpeed.Text = config.Load("Y爬行速度");
            TB_Y原点信号.Text = config.Load("Y原点信号");
            TB_Y正限位信号.Text = config.Load("Y正限位信号");
            TB_Y负限位信号.Text = config.Load("Y负限位信号");
            TB_Y正软限位.Text = config.Load("Y正软限位");
            TB_Y负软限位.Text = config.Load("Y负软限位");
            TB_YPulseType.Text = config.Load("Y轴脉冲类型");
            TB_YAxisType.Text = config.Load("Y轴类型");
            TB_YFastDec.Text = config.Load("Y刹车减速度");

            TB_起始位置.Text = config.Load("起始位置X");
            TB_终止位置.Text = config.Load("终止位置Y");
            TB_切割间隔.Text = config.Load("切割间隔");
            TB_LaserOnPos.Text = config.Load("激光开启位置");
            TB_LaserOffPos.Text = config.Load("激光关闭位置");
            TB_LaserSignal.Text = config.Load("激光信号");
            TB_切割次数.Text = config.Load("切割次数");

            TB_IP.Text = config.Load("IP");
            TB_运动超时时间.Text = config.Load("运动超时时间");
        }

        public void SaveConfig()
        {
            config.Change("X脉冲当量", TB_X脉冲当量.Text);
            config.Change("X运行速度", TB_X运行速度.Text);
            config.Change("X加速度", TB_X加速度.Text);
            config.Change("X减速度", TB_X减速度.Text);
            config.Change("XS曲线", TB_XS曲线.Text);
            config.Change("X爬行速度", TB_XCreepSpeed.Text);
            config.Change("X原点信号", TB_X原点信号.Text);
            config.Change("X正限位信号", TB_X正限位信号.Text);
            config.Change("X负限位信号", TB_X负限位信号.Text);
            config.Change("X正软限位", TB_X正软限位.Text);
            config.Change("X负软限位", TB_X负软限位.Text);
            config.Change("X轴脉冲类型", TB_XPulseType.Text);
            config.Change("X轴类型", TB_XAxisType.Text);
            config.Change("X刹车减速度", TB_XFastDec.Text);

            config.Change("Y脉冲当量", TB_Y脉冲当量.Text);
            config.Change("Y运行速度", TB_Y运行速度.Text);
            config.Change("Y加速度", TB_Y加速度.Text);
            config.Change("Y减速度", TB_Y减速度.Text);
            config.Change("YS曲线", TB_YS曲线.Text);
            config.Change("Y爬行速度", TB_YCreepSpeed.Text);
            config.Change("Y原点信号", TB_Y原点信号.Text);
            config.Change("Y正限位信号", TB_Y正限位信号.Text);
            config.Change("Y负限位信号", TB_Y负限位信号.Text);
            config.Change("Y正软限位", TB_Y正软限位.Text);
            config.Change("Y负软限位", TB_Y负软限位.Text);
            config.Change("Y轴脉冲类型", TB_YPulseType.Text);
            config.Change("Y轴类型", TB_YAxisType.Text);
            config.Change("Y刹车减速度", TB_YFastDec.Text);

            config.Change("起始位置X", TB_起始位置.Text);
            config.Change("终止位置Y", TB_终止位置.Text);
            config.Change("切割间隔", TB_切割间隔.Text);
            config.Change("激光开启位置", TB_LaserOnPos.Text);
            config.Change("激光关闭位置", TB_LaserOffPos.Text);
            config.Change("激光信号", TB_LaserSignal.Text);
            config.Change("切割次数", TB_切割次数.Text);

            config.Change("IP", TB_IP.Text);
            config.Change("运动超时时间", TB_运动超时时间.Text);
        }

        private void AutoRun()
        {
            if (!float.TryParse(TB_运动超时时间.Text, out float timeout))
            {
                MessageBox.Show("请输入超时时间。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!int.TryParse(TB_切割次数.Text, out int cutTimes))
            {
                MessageBox.Show("请输入整数。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isLaserWork = false;
            if (card.Axes[0].IsMoving)
            {
                MessageBox.Show("X轴运动中");
                return;
            }
            if (card.Axes[1].IsMoving)
            {
                MessageBox.Show("Y轴运动中");
                return;
            }
            card.Axes[0].Direction = 1;
            card.Axes[1].Direction = 1;
            card.Axes[0].Home();
            card.Axes[1].Home();
            //if (!card.Axes[0].Wait(timeout)) return;
            //if (!card.Axes[1].Wait(timeout)) return;
            card.Axes[0].Wait();
            card.Axes[1].Wait();
            if (BGW_Auto.CancellationPending) return;

            isLaserWork = true;
            if (RB_模式1.Checked)
            {
                card.Axes[0].SingleAbsoluteMove(GetFloat(TB_起始位置.Text, "X轴位置读取失败。"), timeout);
                if (BGW_Auto.CancellationPending) return;
                suspend.WaitOne();
                if (cutTimes % 2 != 0)
                {
                    //int remainder = cutTimes % 2;
                    for (int i = 0; i < cutTimes / 2; i++)
                    {
                        card.Axes[1].Direction = 1;
                        card.Axes[1].SingleAbsoluteMove(GetFloat(TB_终止位置.Text, "Y轴位置读取失败。"), timeout);
                        card.Axes[0].SingleRelativeMove(GetFloat(TB_切割间隔.Text, "X轴位置读取失败。"), timeout);
                        if (BGW_Auto.CancellationPending) return;
                        card.Axes[1].Direction = -1;
                        card.Axes[1].SingleAbsoluteMove(0, timeout);
                        card.Axes[0].SingleRelativeMove(GetFloat(TB_切割间隔.Text, "X轴位置读取失败。"), timeout);
                        if (BGW_Auto.CancellationPending) return;
                        suspend.WaitOne();
                    }
                    card.Axes[1].Direction = 1;
                    card.Axes[1].SingleAbsoluteMove(GetFloat(TB_终止位置.Text, "Y轴位置读取失败。"), timeout);
                }
                else
                {
                    for (int i = 0; i < cutTimes / 2; i++)
                    {
                        card.Axes[1].Direction = 1;
                        card.Axes[1].SingleAbsoluteMove(GetFloat(TB_终止位置.Text, "Y轴位置读取失败。"), timeout);
                        card.Axes[0].SingleRelativeMove(GetFloat(TB_切割间隔.Text, "X轴位置读取失败。"), timeout);
                        if (BGW_Auto.CancellationPending) return;
                        card.Axes[1].Direction = -1;
                        card.Axes[1].SingleAbsoluteMove(0);
                        card.Axes[0].SingleRelativeMove(GetFloat(TB_切割间隔.Text, "X轴位置读取失败。"), timeout);
                        if (BGW_Auto.CancellationPending) return;
                        suspend.WaitOne();
                    }
                }
            }
            else if (RB_模式2.Checked)
            {
                card.Axes[0].SingleAbsoluteMove(GetFloat(TB_起始位置.Text, "X轴位置读取失败。"), timeout);
                for (int i = 0; i < int.Parse(TB_切割次数.Text); i++)
                {
                    isLaserWork = true;
                    card.Axes[1].Direction = 1;
                    card.Axes[1].SingleAbsoluteMove(GetFloat(TB_终止位置.Text, "Y轴位置读取失败。"), timeout);
                    card.Axes[0].SingleRelativeMove(GetFloat(TB_切割间隔.Text, "X轴位置读取失败。"), timeout);
                    isLaserWork = false;
                    card.Axes[1].Direction = -1;
                    card.Axes[1].SingleAbsoluteMove(0);
                    if (BGW_Auto.CancellationPending) return;
                    suspend.WaitOne();
                }
            }
        }

        private void Shutdown()
        {
            if (BGW_Auto.IsBusy) BGW_Auto.CancelAsync();
            card.Scram();
            isLaserWork = false;
            card.SetOutput(int.Parse(TB_LaserSignal.Text), 0);
        }

        private float GetFloat(string stringValue, string message = "")
        {
            if (float.TryParse(stringValue, out var value))
                return value;
            else
            {
                if (message != "")
                {
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Shutdown();
                    MessageRecorder.RecordError($"读取float参数失败。", "检查输入参数。");
                }
                return 0;
            }
        }

        private int GetInt(string stringValue, string message = "")
        {
            if (int.TryParse(stringValue, out var value))
                return value;
            else
            {
                if (message != "")
                {
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Shutdown();
                    MessageRecorder.RecordError($"读取int参数失败。", "检查输入参数。");
                }
                return 0;
            }
        }
        #endregion

        #region 校准
        private void BTN_回零校准_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(TB_AxisCode.Text, out var axisCode))
                {
                    if (CB_回零方向.Checked)
                        card.Axes[axisCode].HomeCorrect();
                    else
                        card.Axes[axisCode].HomeCorrect(3);
                }
                else
                {
                    MessageBox.Show("输入正确轴号", "校准", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageRecorder.RecordError($"读取轴号失败。", "输入正确轴号进行回零校准。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("回零失败。" + ex.Message, "校准", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageRecorder.RecordError($"回零校准失败。{ex.Message}", "检查回零设置。");
            }
        }

        private void BTN_位置清零_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(TB_AxisCode.Text, out var axisCode))
                {
                    Zmcaux.ZAux_Direct_SetDpos(card.G_handle, axisCode, 0);
                    MessageBox.Show("完成", "校准", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("输入正确轴号", "校准", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("清零失败。" + ex.Message, "校准", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_校准停止_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(TB_AxisCode.Text, out var axisCode))
                {
                    card.Axes[axisCode].Stop();
                }
                else
                {
                    MessageBox.Show("输入正确轴号", "校准", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("停止失败。" + ex.Message, "校准", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 自动
        private void BTN_连接_Click(object sender, EventArgs e)
        {
            try
            {
                if (card.Connect(TB_IP.Text))
                {
                    MessageBox.Show("控制器链接成功!", "提示");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败。" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_断开_Click(object sender, EventArgs e)
        {
            try
            {
                if (card.Close())
                {
                    MessageBox.Show("控制器断开成功!", "提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("断开失败。" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_自动模式_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否切换自动模式？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                isAuto = true;
            }
        }

        private void BTN_手动模式_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否切换手动模式？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                card.Start();
                isAuto = false;
            }
        }

        private void BTN_自动运行_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否自动运行？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                card.Start();
                if (BGW_Auto.IsBusy)
                {
                    MessageBox.Show("运行中。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (isAuto)
                    BGW_Auto.RunWorkerAsync();
                else
                    MessageBox.Show("现为手动模式。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BTN_自动停止_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否停止自动？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (BGW_Auto.IsBusy) BGW_Auto.CancelAsync();
            }
        }

        private void BTN_初始化_Click(object sender, EventArgs e)
        {
            try
            {
                isLaserWork = false;
                if (card.Axes[0].IsMoving)
                {
                    MessageBox.Show("X轴运动中");
                }
                else
                {
                    card.Axes[0].Home();
                }
                if (card.Axes[1].IsMoving)
                {
                    MessageBox.Show("Y轴运动中");
                }
                else
                {
                    card.Axes[1].Home();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("初始化失败");
            }
        }

        private void BTN_停止_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否停止？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Shutdown();
            }
        }

        private void BTN_暂停_Click(object sender, EventArgs e)
        {
            if (isSuspend)
            {
                BTN_暂停.BackColor = Color.YellowGreen;
                BTN_暂停.Text = "继续";
                suspend.Reset();
                isSuspend = false;
            }
            else
            {
                BTN_暂停.BackColor = Color.Transparent;
                BTN_暂停.Text = "暂停";
                suspend.Set();
                isSuspend = true;
            }
        }
        #endregion

        #region 手动
        private void BTN_X回原点_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                if (card.Axes[0].IsMoving)
                {
                    MessageBox.Show("X轴运动中");
                }
                else
                {
                    card.Axes[0].Home();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("X轴回零失败");
            }
        }

        private void BTN_Y回原点_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                if (card.Axes[1].IsMoving)
                {
                    MessageBox.Show("Y轴运动中");
                }
                else
                {
                    card.Axes[1].Home();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Y轴回零失败");
            }
        }

        private void BTN_X相对运动_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                if (float.TryParse(TB_X相对运动.Text, out var x))
                    card.Axes[0].RelativeMove(x);
            }
            catch (Exception ex)
            {
                MessageBox.Show("运行失败。" + ex.Message, "手动控制");
            }
        }

        private void BTN_X绝对运动_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                if (float.TryParse(TB_X绝对运动.Text, out var x))
                    card.Axes[0].AbsoluteMove(x);
            }
            catch (Exception ex)
            {
                MessageBox.Show("运行失败。" + ex.Message, "手动控制");
            }
        }

        private void BTN_X左_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                card.Axes[0].Direction = -1;
                card.Axes[0].ContinuousMove();
            }
            catch (Exception ex)
            {
                MessageBox.Show("运行失败。" + ex.Message, "手动控制");
            }
        }

        private void BTN_XStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                card.Axes[0].Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("运行失败。" + ex.Message, "手动控制");
            }
            
        }

        private void BTN_X右_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                card.Axes[0].Direction = 1;
                card.Axes[0].ContinuousMove();
            }
            catch (Exception ex)
            {
                MessageBox.Show("运行失败。" + ex.Message, "手动控制");
            }
            
        }

        private void BNT_Y相对运动_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                if (float.TryParse(TB_Y相对运动.Text, out var y))
                    card.Axes[1].RelativeMove(y);
            }
            catch (Exception ex)
            {
                MessageBox.Show("运行失败。" + ex.Message, "手动控制");
            }
        }

        private void BTN_Y绝对运动_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                if (float.TryParse(TB_Y绝对运动.Text, out var y))
                    card.Axes[1].AbsoluteMove(y);
            }
            catch (Exception ex)
            {
                MessageBox.Show("运行失败。" + ex.Message, "手动控制");
            }
        }

        private void BNT_Y左_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                card.Axes[1].Direction = -1;
                card.Axes[1].ContinuousMove();
            }
            catch (Exception ex)
            {
                MessageBox.Show("运行失败。" + ex.Message, "手动控制");
            }
        }

        private void BTN_YStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                card.Axes[1].Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("运行失败。" + ex.Message, "手动控制");
            }
        }

        private void BTN_Y右_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                card.Axes[1].Direction = 1;
                card.Axes[1].ContinuousMove();
            }
            catch (Exception ex)
            {
                MessageBox.Show("运行失败。" + ex.Message, "手动控制");
            }
        }

        private void BTN_回原点_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                isLaserWork = false;
                card.Axes[0].Direction = 1;
                card.Axes[1].Direction = 1;
                card.Axes[0].Home();
                card.Axes[1].Home();
                card.Axes[0].Wait();
                card.Axes[1].Wait();
                
            }
            catch (Exception)
            {
                MessageBox.Show("回原点失败");
            }
        }

        private void BTN_手动运行_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                isLaserWork = true;
                card.Axes[1].Direction = 1;
                card.Axes[1].AbsoluteMove(Convert.ToSingle(TB_终止位置.Text));
                card.Axes[1].Wait();
                card.Axes[0].RelativeMove(Convert.ToSingle(TB_切割间隔.Text));
                card.Axes[0].Wait();
                isLaserWork = false;
                card.Axes[1].Direction = -1;
                card.Axes[1].AbsoluteMove(0);
                card.Axes[1].Wait();
            }
            catch (Exception)
            {
                MessageBox.Show("运行失败");
            }
        }

        private void BTN_手动X轴移动_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                card.Axes[0].RelativeMove(Convert.ToSingle(TB_切割间隔.Text));
                card.Axes[0].Wait();
            }
            catch (Exception)
            {
                MessageBox.Show("运行失败");
            }
        }

        private void BTN_手动初始位置_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAuto) { MessageBox.Show("自动运行模式。", "提示"); return; }
                isLaserWork = false;
                card.Axes[0].Direction = 1;
                card.Axes[1].Direction = 1;
                card.Axes[0].Home();
                card.Axes[1].Home();
                card.Axes[0].Wait();
                card.Axes[1].Wait();
                card.Axes[0].AbsoluteMove(Convert.ToSingle(TB_起始位置.Text));
                card.Axes[0].Wait();
            }
            catch (Exception)
            {
                MessageBox.Show("初始化失败");
            }
        }

        #endregion

        #region 设置
        private void BTN_设置_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeAxesConfig();
                MessageBox.Show("设置完成。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置失败。" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_保存设置_Click(object sender, EventArgs e)
        {
            try
            {
                SaveConfig();
                MessageBox.Show("保存完成。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败。" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 测试
        private void BTN_Test_Click(object sender, EventArgs e)
        {
            card.Start();
            if (float.TryParse(TB_X绝对运动.Text, out var x))
                card.Axes[0].AbsoluteMove(x);
            if (float.TryParse(TB_Y绝对运动.Text, out var y))
                card.Axes[1].AbsoluteMove(y);
        }
        #endregion
    }
}
