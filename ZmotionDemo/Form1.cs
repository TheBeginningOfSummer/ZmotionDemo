using cszmcaux;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ZmotionDemo
{
    public partial class Form1 : Form
    {
        readonly MotionControlCard card = new MotionControlCard();

        public Form1()
        {
            InitializeComponent();
            try
            {
                if (card.Connect())
                    MessageBox.Show("控制器链接成功!", "提示");
                else
                    MessageBox.Show("控制器链接失败，请检测IP地址!", "警告");

                if (int.TryParse(TB_AxisType.Text, out var axisType))
                    InitializeAxes(axisType);
                else
                    MessageBox.Show("初始化轴参数失败。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show("连接失败。" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //断开链接
                //timer1.Enabled = false;
                card.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败。" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InitializeAxes(int axisType = 1)
        {
            card.AddAxis(axisType, 0);
            card.AddAxis(axisType, 1);
            card.Axes[0].Initialize(TB_X脉冲当量.Text, TB_X运行速度.Text, TB_X加速度.Text, TB_X减速度.Text, TB_XS曲线.Text);
            card.Axes[1].Initialize(TB_Y脉冲当量.Text, TB_Y运行速度.Text, TB_Y加速度.Text, TB_Y减速度.Text, TB_YS曲线.Text);
            card.Axes[0].InitializeDatum(int.Parse(TB_原点信号X.Text));
            card.Axes[1].InitializeDatum(int.Parse(TB_原点信号Y.Text));
            card.Axes[0].SetLimitSignal(int.Parse(TB_正限位信号X.Text), int.Parse(TB_负限位信号X.Text));
            card.Axes[1].SetLimitSignal(int.Parse(TB_正限位信号Y.Text), int.Parse(TB_负限位信号Y.Text));
        }

        #region 自动
        private void BTN_连接_Click(object sender, EventArgs e)
        {

        }

        private void BTN_自动模式_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否切换自动模式？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                
            }
        }

        private void BTN_手动模式_Click(object sender, EventArgs e)
        {

        }

        private void BTN_自动运行_Click(object sender, EventArgs e)
        {

        }

        private void BTN_自动停止_Click(object sender, EventArgs e)
        {

        }

        private void BTN_初始化_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TB_AxisType.Text, out var axisType))
                InitializeAxes(axisType);
        }
        #endregion

        private void BTN_保存设置_Click(object sender, EventArgs e)
        {

        }

        #region 手动
        private void BTN_X回原点_Click(object sender, EventArgs e)
        {
            try
            {
                card.Axes[0].Home();
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
                card.Axes[1].Home();
            }
            catch (Exception)
            {
                MessageBox.Show("Y轴回零失败");
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("回零失败。" + ex.Message, "校准", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_位置清零_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(TB_AxisCode.Text, out var axisCode))
                {
                    Zmcaux.ZAux_Direct_SetDpos(card.G_handle, axisCode, 0);
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


    }
}
