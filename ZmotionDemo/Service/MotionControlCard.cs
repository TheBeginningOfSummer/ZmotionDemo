using cszmcaux;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ZmotionDemo
{
    public class MotionControlCard
    {
        public IntPtr G_handle;
        public List<Axis> Axes = new List<Axis>();

        public MotionControlCard() { }

        public bool Connect(string ip = "127.0.0.1")
        {
            //链接控制器 
            Zmcaux.ZAux_OpenEth(ip, out G_handle);
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

        public void AddAxis(int type, int number, float units)
        {
            Axes.Add(new Axis(type, number, units, G_handle));
        }

        public void SetOutput(int num, uint value)
        {
            Zmcaux.ZAux_Direct_SetOp(G_handle, num, value);
        }

        public uint GetOutput(int num)
        {
            uint value = 2;
            Zmcaux.ZAux_Direct_GetOp(G_handle, num, ref value);
            return value;
        }

        public uint GetInput(int num)
        {
            uint value = 2;
            Zmcaux.ZAux_Direct_GetIn(G_handle, num, ref value);
            return value;
        }
    }

    public class Axis
    {
        public int AxisType { get; set; }
        public int AxisNumber { get; set; }
        public float AxisUnits { get; private set; }
        public IntPtr Handle { get; private set; }
        public int Direction { get; set; } = 1;

        private bool isMoving = false;
        public bool IsMoving
        {
            get { return isMoving; }
            set
            {
                if (isMoving != value)
                {
                    isMoving = value;
                    Zmcaux.ZAux_Direct_GetDpos(Handle, AxisNumber, ref CurrentPosition);
                    MovingAction?.Invoke(CurrentPosition);
                }
            }
        }
        public float CurrentPosition;
        public Action<float> MovingAction;

        public Axis(int type, int number, float units, IntPtr handle)
        {
            AxisType = type;
            AxisNumber = number;
            AxisUnits = units;
            Handle = handle;
            Zmcaux.ZAux_Direct_SetAtype(Handle, AxisNumber, AxisType);
        }

        #region 初始化
        /// <summary>
        /// 初始化轴参数string
        /// </summary>
        /// <param name="arg">参数，依次为速度、加速度、减速度、S曲线（选用 爬行速度、初始速度）</param>
        public void Initialize(params string[] arg)
        {
            if (arg == null || arg.Length < 4) return;
            Zmcaux.ZAux_Direct_SetUnits(Handle, AxisNumber, AxisUnits);
            Zmcaux.ZAux_Direct_SetSpeed(Handle, AxisNumber, Convert.ToSingle(arg[0]) * AxisUnits);
            Zmcaux.ZAux_Direct_SetAccel(Handle, AxisNumber, Convert.ToSingle(arg[1]) * AxisUnits);
            Zmcaux.ZAux_Direct_SetDecel(Handle, AxisNumber, Convert.ToSingle(arg[2]) * AxisUnits);
            Zmcaux.ZAux_Direct_SetSramp(Handle, AxisNumber, Convert.ToSingle(arg[3]) * AxisUnits);
            if (arg.Length > 4)
                Zmcaux.ZAux_Direct_SetCreep(Handle, AxisNumber, Convert.ToSingle(arg[4]) * AxisUnits);
            if (arg.Length > 5)
                Zmcaux.ZAux_Direct_SetLspeed(Handle, AxisNumber, Convert.ToSingle(arg[5]) * AxisUnits);
            Task.Run(UpdateStatus);
        }
        /// <summary>
        /// 初始化轴参数float
        /// </summary>
        /// <param name="arg">参数，依次为速度、加速度、减速度、S曲线（选用 爬行速度、初始速度）</param>
        public void Initialize(params float[] arg)
        {
            if (arg == null || arg.Length < 4) return;
            Zmcaux.ZAux_Direct_SetUnits(Handle, AxisNumber, AxisUnits);
            Zmcaux.ZAux_Direct_SetSpeed(Handle, AxisNumber, arg[0] * AxisUnits);
            Zmcaux.ZAux_Direct_SetAccel(Handle, AxisNumber, arg[1] * AxisUnits);
            Zmcaux.ZAux_Direct_SetDecel(Handle, AxisNumber, arg[2] * AxisUnits);
            Zmcaux.ZAux_Direct_SetSramp(Handle, AxisNumber, arg[3] * AxisUnits);
            if (arg.Length > 4)
                Zmcaux.ZAux_Direct_SetCreep(Handle, AxisNumber, arg[4] * AxisUnits);
            if (arg.Length > 5)
                Zmcaux.ZAux_Direct_SetLspeed(Handle, AxisNumber, arg[5] * AxisUnits);
            Task.Run(UpdateStatus);
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
        /// <summary>
        /// 设置软限位
        /// </summary>
        /// <param name="forward">正限位距离</param>
        /// <param name="reverse">负限位距离</param>
        public void SetLimit(float forward = -1, float reverse = -1)
        {
            if (forward >= 0)
                Zmcaux.ZAux_Direct_SetFsLimit(Handle, AxisNumber, forward * AxisUnits);
            if (reverse >= 0)
                Zmcaux.ZAux_Direct_SetRsLimit(Handle, AxisNumber, reverse * AxisUnits);
        }
        #endregion

        #region 运动
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
            if (CurrentPosition > 0)
            {
                return Zmcaux.ZAux_Direct_Single_Datum(Handle, AxisNumber, 4);
            }
            else
            {
                return Zmcaux.ZAux_Direct_Single_Datum(Handle, AxisNumber, 3);
            }
        }
        /// <summary>
        /// 连续运动
        /// </summary>
        /// <returns></returns>
        public int ContinuousMove()
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
            return Zmcaux.ZAux_Direct_Single_Move(Handle, AxisNumber, distance * AxisUnits);
        }
        /// <summary>
        /// 绝对运动
        /// </summary>
        /// <param name="distance">运动距离</param>
        /// <returns></returns>
        public int AbsoluteMove(float distance)
        {
            return Zmcaux.ZAux_Direct_Single_MoveAbs(Handle, AxisNumber, distance * AxisUnits);
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

        public void Wait()
        {
            Thread.Sleep(500);
            do
            {
                Thread.Sleep(50);
            } while (IsMoving);
        }

        public bool Wait(double delay)
        {
            int i = 0;
            Thread.Sleep(500);
            do
            {
                i++;
                Thread.Sleep(50);
                if (i * 50 > delay)
                {
                    //超时报警，可用委托
                    return false;
                }
            } while (IsMoving);
            return true;
        }
        #endregion

        public float GetSpeed()
        {
            float speed = 0;
            Zmcaux.ZAux_Direct_GetSpeed(Handle, AxisNumber, ref speed);
            return speed / AxisUnits;
        }

        public float GetMSpeed()
        {
            float speed = 0;
            Zmcaux.ZAux_Direct_GetMspeed(Handle, AxisNumber, ref speed);
            return speed / AxisUnits;
        }
        /// <summary>
        /// 得到坐标
        /// </summary>
        /// <returns></returns>
        public float GetPosition()
        {
            float position = 0;
            Zmcaux.ZAux_Direct_GetDpos(Handle, AxisNumber, ref position);
            return position / AxisUnits;
        }
        /// <summary>
        /// 更新轴状态
        /// </summary>
        public void UpdateStatus()
        {
            int movingStatus = 0;
            float position = 0;
            while (true)
            {
                Thread.Sleep(100);
                Zmcaux.ZAux_Direct_GetIfIdle(Handle, AxisNumber, ref movingStatus);
                if (movingStatus == 0)
                    IsMoving = true;
                else if (movingStatus == -1)
                    IsMoving = false;
                if (IsMoving)
                {
                    Zmcaux.ZAux_Direct_GetDpos(Handle, AxisNumber, ref position);
                    CurrentPosition = position / AxisUnits;
                    MovingAction?.Invoke(CurrentPosition);
                }
            }
        }

        
    }
}
