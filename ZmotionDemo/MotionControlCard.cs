using cszmcaux;
using System;
using System.Collections.Generic;

namespace ZmotionDemo
{
    public class MotionControlCard
    {
        public IntPtr G_handle;
        public List<Axis> Axes = new List<Axis>();

        public MotionControlCard() { }

        public bool Connect()
        {
            //链接控制器 
            Zmcaux.ZAux_OpenEth("127.0.0.1", out G_handle);
            if (G_handle != (IntPtr)0)
                return true;
            else
                return false;
        }

        public void Close()
        {
            G_handle = (IntPtr)0;
            Zmcaux.ZAux_Close(G_handle);
        }

        public void AddAxis(int type, int number)
        {
            Axes.Add(new Axis(type, number, G_handle));
        }
    }

    public class Axis
    {
        public int AxisType { get; set; }
        public int AxisNumber { get; set; }
        public IntPtr Handle { get; private set; }
        public int Direction { get; set; } = 1;

        public Axis(int type, int number, IntPtr handle)
        {
            AxisType = type;
            AxisNumber = number;
            Handle = handle;
            Zmcaux.ZAux_Direct_SetAtype(Handle, AxisNumber, AxisType);
        }

        /// <summary>
        /// 初始化轴参数
        /// </summary>
        /// <param name="arg">参数，依次为脉冲当量、速度、加速度、减速度、S曲线（选用 爬行速度、初始速度）</param>
        public void Initialize(params string[] arg)
        {
            if (arg == null || arg.Length < 5) return;
            Zmcaux.ZAux_Direct_SetUnits(Handle, AxisNumber, Convert.ToSingle(arg[0]));
            Zmcaux.ZAux_Direct_SetSpeed(Handle, AxisNumber, Convert.ToSingle(arg[1]));
            Zmcaux.ZAux_Direct_SetAccel(Handle, AxisNumber, Convert.ToSingle(arg[2]));
            Zmcaux.ZAux_Direct_SetDecel(Handle, AxisNumber, Convert.ToSingle(arg[3]));
            Zmcaux.ZAux_Direct_SetSramp(Handle, AxisNumber, Convert.ToSingle(arg[4]));
            if (arg.Length > 5)
                Zmcaux.ZAux_Direct_SetCreep(Handle, AxisNumber, Convert.ToSingle(arg[5]));
            if (arg.Length > 6)
                Zmcaux.ZAux_Direct_SetLspeed(Handle, AxisNumber, Convert.ToSingle(arg[6]));
        }
        /// <summary>
        /// 设置原点信号
        /// </summary>
        /// <param name="inNumber">信号输入口号</param>
        /// <param name="isInvert">信号是否反转</param>
        public void InitializeDatum(int inNumber, bool isInvert = false)
        {
            Zmcaux.ZAux_Direct_SetDatumIn(Handle, AxisNumber, inNumber); //配置原点信号。ZMC系列默认OFF时信号有效，常开传感器需要反转输入口为ON
            if (isInvert)
                Zmcaux.ZAux_Direct_SetInvertIn(Handle, inNumber, 1);
        }
        /// <summary>
        /// 设置限位信号
        /// </summary>
        /// <param name="forward">正信号输入口</param>
        /// <param name="reverse">负信号输入口</param>
        public void SetLimitSignal(int forward = -1, int reverse = -1)
        {
            if (forward >= 0)
                Zmcaux.ZAux_Direct_SetFwdIn(Handle, AxisNumber, forward);
            if (reverse >= 0)
                Zmcaux.ZAux_Direct_SetRevIn(Handle, AxisNumber, reverse);
        }

        public int HomeCorrect(int mode = 4)
        {
            return Zmcaux.ZAux_Direct_Single_Datum(Handle, AxisNumber, mode);
        }
        /// <summary>
        /// 回原点
        /// </summary>
        /// <param name="mode">回零模式：
        /// 0清除轴错误状态；
        /// 3正向回0；
        /// 4负向回0；
        /// </param>
        /// <returns></returns>
        public int Home()
        {
            int status = 0; float position = 0;
            Zmcaux.ZAux_Direct_GetIfIdle(Handle, AxisNumber, ref status);
            if (status == 0) return 0;
            Zmcaux.ZAux_Direct_GetDpos(Handle, AxisNumber, ref position);
            if (position > 0)
            {
                return Zmcaux.ZAux_Direct_Single_Datum(Handle, AxisNumber, 4);
            }
            else
            {
                return Zmcaux.ZAux_Direct_Single_Datum(Handle, AxisNumber, 3);
            }
        }
        /// <summary>
        /// 更改运动方向
        /// </summary>
        public void ChangeDirection()
        {
            Direction = -Direction;
        }
        /// <summary>
        /// 连续运动
        /// </summary>
        /// <returns></returns>
        public int Jog()
        {
            return Zmcaux.ZAux_Direct_Single_Vmove(Handle, AxisNumber, Direction);
        }
        /// <summary>
        /// 相对运动
        /// </summary>
        /// <param name="distance">相对运动距离</param>
        /// <returns></returns>
        public int RelativeMove(float distance)
        {
            return Zmcaux.ZAux_Direct_Single_Move(Handle, AxisNumber, Direction * distance);
        }
        /// <summary>
        /// 绝对运动
        /// </summary>
        /// <param name="distance">运动距离</param>
        /// <returns></returns>
        public int AbsoluteMove(float distance)
        {
            return Zmcaux.ZAux_Direct_Single_MoveAbs(Handle, AxisNumber, distance);
        }
        /// <summary>
        /// 停止运动
        /// </summary>
        /// <param name="mode">模式：
        /// 0（缺省）取消当前运动；
        /// 1 取消缓冲的运动；
        /// 2 取消当前运动和缓冲运动；
        /// 3 立即中断脉冲发送；
        /// </param>
        /// <returns></returns>
        public int Stop(int mode = 2)
        {
            return Zmcaux.ZAux_Direct_Single_Cancel(Handle, AxisNumber, mode);
        }
    }
}
