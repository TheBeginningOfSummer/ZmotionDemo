namespace ZmotionDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TP_自动 = new System.Windows.Forms.TabPage();
            this.BTN_初始化 = new System.Windows.Forms.Button();
            this.BTN_自动停止 = new System.Windows.Forms.Button();
            this.BTN_自动运行 = new System.Windows.Forms.Button();
            this.BTN_手动模式 = new System.Windows.Forms.Button();
            this.BTN_自动模式 = new System.Windows.Forms.Button();
            this.BTN_连接 = new System.Windows.Forms.Button();
            this.TP_手动 = new System.Windows.Forms.TabPage();
            this.GB_Y = new System.Windows.Forms.GroupBox();
            this.BTN_Y回原点 = new System.Windows.Forms.Button();
            this.GB_X = new System.Windows.Forms.GroupBox();
            this.BTN_X回原点 = new System.Windows.Forms.Button();
            this.TP_设置 = new System.Windows.Forms.TabPage();
            this.GB_切割设置 = new System.Windows.Forms.GroupBox();
            this.TB_间隔2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TB_间隔1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TB_AxisType = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.GB_Y轴设置 = new System.Windows.Forms.GroupBox();
            this.TB_YS曲线 = new System.Windows.Forms.TextBox();
            this.TB_Y减速度 = new System.Windows.Forms.TextBox();
            this.TB_Y加速度 = new System.Windows.Forms.TextBox();
            this.TB_Y运行速度 = new System.Windows.Forms.TextBox();
            this.TB_Y脉冲当量 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GB_X轴设置 = new System.Windows.Forms.GroupBox();
            this.TB_XS曲线 = new System.Windows.Forms.TextBox();
            this.TB_X减速度 = new System.Windows.Forms.TextBox();
            this.TB_X加速度 = new System.Windows.Forms.TextBox();
            this.TB_X运行速度 = new System.Windows.Forms.TextBox();
            this.TB_X脉冲当量 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.减速度 = new System.Windows.Forms.Label();
            this.加速度 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_保存设置 = new System.Windows.Forms.Button();
            this.TB_原点信号X = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TB_原点信号Y = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TB_正限位信号X = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TB_负限位信号X = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TB_负限位信号Y = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TB_正限位信号Y = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TP_校准 = new System.Windows.Forms.TabPage();
            this.LB_当前X轴位置 = new System.Windows.Forms.Label();
            this.LB_当前Y轴位置 = new System.Windows.Forms.Label();
            this.GB_零点校准 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TB_AxisCode = new System.Windows.Forms.TextBox();
            this.BTN_回零校准 = new System.Windows.Forms.Button();
            this.BTN_位置清零 = new System.Windows.Forms.Button();
            this.BTN_校准停止 = new System.Windows.Forms.Button();
            this.CB_回零方向 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.TP_自动.SuspendLayout();
            this.TP_手动.SuspendLayout();
            this.GB_Y.SuspendLayout();
            this.GB_X.SuspendLayout();
            this.TP_设置.SuspendLayout();
            this.GB_切割设置.SuspendLayout();
            this.GB_Y轴设置.SuspendLayout();
            this.GB_X轴设置.SuspendLayout();
            this.TP_校准.SuspendLayout();
            this.GB_零点校准.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TP_自动);
            this.tabControl1.Controls.Add(this.TP_手动);
            this.tabControl1.Controls.Add(this.TP_设置);
            this.tabControl1.Controls.Add(this.TP_校准);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // TP_自动
            // 
            this.TP_自动.Controls.Add(this.BTN_初始化);
            this.TP_自动.Controls.Add(this.BTN_自动停止);
            this.TP_自动.Controls.Add(this.BTN_自动运行);
            this.TP_自动.Controls.Add(this.BTN_手动模式);
            this.TP_自动.Controls.Add(this.BTN_自动模式);
            this.TP_自动.Controls.Add(this.BTN_连接);
            this.TP_自动.Location = new System.Drawing.Point(4, 22);
            this.TP_自动.Name = "TP_自动";
            this.TP_自动.Padding = new System.Windows.Forms.Padding(3);
            this.TP_自动.Size = new System.Drawing.Size(792, 424);
            this.TP_自动.TabIndex = 0;
            this.TP_自动.Text = "自动";
            this.TP_自动.UseVisualStyleBackColor = true;
            // 
            // BTN_初始化
            // 
            this.BTN_初始化.Location = new System.Drawing.Point(376, 214);
            this.BTN_初始化.Name = "BTN_初始化";
            this.BTN_初始化.Size = new System.Drawing.Size(75, 23);
            this.BTN_初始化.TabIndex = 5;
            this.BTN_初始化.Text = "初始化";
            this.BTN_初始化.UseVisualStyleBackColor = true;
            this.BTN_初始化.Click += new System.EventHandler(this.BTN_初始化_Click);
            // 
            // BTN_自动停止
            // 
            this.BTN_自动停止.Location = new System.Drawing.Point(569, 304);
            this.BTN_自动停止.Name = "BTN_自动停止";
            this.BTN_自动停止.Size = new System.Drawing.Size(75, 23);
            this.BTN_自动停止.TabIndex = 4;
            this.BTN_自动停止.Text = "自动停止";
            this.BTN_自动停止.UseVisualStyleBackColor = true;
            this.BTN_自动停止.Click += new System.EventHandler(this.BTN_自动停止_Click);
            // 
            // BTN_自动运行
            // 
            this.BTN_自动运行.Location = new System.Drawing.Point(474, 304);
            this.BTN_自动运行.Name = "BTN_自动运行";
            this.BTN_自动运行.Size = new System.Drawing.Size(75, 23);
            this.BTN_自动运行.TabIndex = 3;
            this.BTN_自动运行.Text = "自动运行";
            this.BTN_自动运行.UseVisualStyleBackColor = true;
            this.BTN_自动运行.Click += new System.EventHandler(this.BTN_自动运行_Click);
            // 
            // BTN_手动模式
            // 
            this.BTN_手动模式.Location = new System.Drawing.Point(376, 304);
            this.BTN_手动模式.Name = "BTN_手动模式";
            this.BTN_手动模式.Size = new System.Drawing.Size(75, 23);
            this.BTN_手动模式.TabIndex = 2;
            this.BTN_手动模式.Text = "手动模式";
            this.BTN_手动模式.UseVisualStyleBackColor = true;
            this.BTN_手动模式.Click += new System.EventHandler(this.BTN_手动模式_Click);
            // 
            // BTN_自动模式
            // 
            this.BTN_自动模式.Location = new System.Drawing.Point(279, 304);
            this.BTN_自动模式.Name = "BTN_自动模式";
            this.BTN_自动模式.Size = new System.Drawing.Size(75, 23);
            this.BTN_自动模式.TabIndex = 1;
            this.BTN_自动模式.Text = "自动模式";
            this.BTN_自动模式.UseVisualStyleBackColor = true;
            this.BTN_自动模式.Click += new System.EventHandler(this.BTN_自动模式_Click);
            // 
            // BTN_连接
            // 
            this.BTN_连接.Location = new System.Drawing.Point(177, 304);
            this.BTN_连接.Name = "BTN_连接";
            this.BTN_连接.Size = new System.Drawing.Size(75, 23);
            this.BTN_连接.TabIndex = 0;
            this.BTN_连接.Text = "连接";
            this.BTN_连接.UseVisualStyleBackColor = true;
            this.BTN_连接.Click += new System.EventHandler(this.BTN_连接_Click);
            // 
            // TP_手动
            // 
            this.TP_手动.Controls.Add(this.GB_Y);
            this.TP_手动.Controls.Add(this.GB_X);
            this.TP_手动.Location = new System.Drawing.Point(4, 22);
            this.TP_手动.Name = "TP_手动";
            this.TP_手动.Padding = new System.Windows.Forms.Padding(3);
            this.TP_手动.Size = new System.Drawing.Size(792, 424);
            this.TP_手动.TabIndex = 1;
            this.TP_手动.Text = "手动";
            this.TP_手动.UseVisualStyleBackColor = true;
            // 
            // GB_Y
            // 
            this.GB_Y.Controls.Add(this.LB_当前Y轴位置);
            this.GB_Y.Controls.Add(this.BTN_Y回原点);
            this.GB_Y.Location = new System.Drawing.Point(214, 6);
            this.GB_Y.Name = "GB_Y";
            this.GB_Y.Size = new System.Drawing.Size(200, 159);
            this.GB_Y.TabIndex = 1;
            this.GB_Y.TabStop = false;
            this.GB_Y.Text = "Y轴";
            // 
            // BTN_Y回原点
            // 
            this.BTN_Y回原点.Location = new System.Drawing.Point(119, 130);
            this.BTN_Y回原点.Name = "BTN_Y回原点";
            this.BTN_Y回原点.Size = new System.Drawing.Size(75, 23);
            this.BTN_Y回原点.TabIndex = 0;
            this.BTN_Y回原点.Text = "回原点";
            this.BTN_Y回原点.UseVisualStyleBackColor = true;
            this.BTN_Y回原点.Click += new System.EventHandler(this.BTN_Y回原点_Click);
            // 
            // GB_X
            // 
            this.GB_X.Controls.Add(this.LB_当前X轴位置);
            this.GB_X.Controls.Add(this.BTN_X回原点);
            this.GB_X.Location = new System.Drawing.Point(8, 6);
            this.GB_X.Name = "GB_X";
            this.GB_X.Size = new System.Drawing.Size(200, 159);
            this.GB_X.TabIndex = 0;
            this.GB_X.TabStop = false;
            this.GB_X.Text = "X轴";
            // 
            // BTN_X回原点
            // 
            this.BTN_X回原点.Location = new System.Drawing.Point(119, 130);
            this.BTN_X回原点.Name = "BTN_X回原点";
            this.BTN_X回原点.Size = new System.Drawing.Size(75, 23);
            this.BTN_X回原点.TabIndex = 0;
            this.BTN_X回原点.Text = "回原点";
            this.BTN_X回原点.UseVisualStyleBackColor = true;
            this.BTN_X回原点.Click += new System.EventHandler(this.BTN_X回原点_Click);
            // 
            // TP_设置
            // 
            this.TP_设置.Controls.Add(this.BTN_保存设置);
            this.TP_设置.Controls.Add(this.GB_切割设置);
            this.TP_设置.Controls.Add(this.TB_AxisType);
            this.TP_设置.Controls.Add(this.label9);
            this.TP_设置.Controls.Add(this.GB_Y轴设置);
            this.TP_设置.Controls.Add(this.GB_X轴设置);
            this.TP_设置.Location = new System.Drawing.Point(4, 22);
            this.TP_设置.Name = "TP_设置";
            this.TP_设置.Size = new System.Drawing.Size(792, 424);
            this.TP_设置.TabIndex = 2;
            this.TP_设置.Text = "设置";
            this.TP_设置.UseVisualStyleBackColor = true;
            // 
            // GB_切割设置
            // 
            this.GB_切割设置.Controls.Add(this.TB_间隔2);
            this.GB_切割设置.Controls.Add(this.label11);
            this.GB_切割设置.Controls.Add(this.TB_间隔1);
            this.GB_切割设置.Controls.Add(this.label10);
            this.GB_切割设置.Location = new System.Drawing.Point(510, 10);
            this.GB_切割设置.Name = "GB_切割设置";
            this.GB_切割设置.Size = new System.Drawing.Size(141, 156);
            this.GB_切割设置.TabIndex = 4;
            this.GB_切割设置.TabStop = false;
            this.GB_切割设置.Text = "切割设置";
            // 
            // TB_间隔2
            // 
            this.TB_间隔2.Location = new System.Drawing.Point(77, 42);
            this.TB_间隔2.Name = "TB_间隔2";
            this.TB_间隔2.Size = new System.Drawing.Size(46, 21);
            this.TB_间隔2.TabIndex = 15;
            this.TB_间隔2.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "间隔";
            // 
            // TB_间隔1
            // 
            this.TB_间隔1.Location = new System.Drawing.Point(77, 14);
            this.TB_间隔1.Name = "TB_间隔1";
            this.TB_间隔1.Size = new System.Drawing.Size(46, 21);
            this.TB_间隔1.TabIndex = 13;
            this.TB_间隔1.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "第一行间隔";
            // 
            // TB_AxisType
            // 
            this.TB_AxisType.Location = new System.Drawing.Point(436, 265);
            this.TB_AxisType.Name = "TB_AxisType";
            this.TB_AxisType.Size = new System.Drawing.Size(50, 21);
            this.TB_AxisType.TabIndex = 3;
            this.TB_AxisType.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(389, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "轴类型";
            // 
            // GB_Y轴设置
            // 
            this.GB_Y轴设置.Controls.Add(this.TB_负限位信号Y);
            this.GB_Y轴设置.Controls.Add(this.label16);
            this.GB_Y轴设置.Controls.Add(this.TB_正限位信号Y);
            this.GB_Y轴设置.Controls.Add(this.label17);
            this.GB_Y轴设置.Controls.Add(this.TB_原点信号Y);
            this.GB_Y轴设置.Controls.Add(this.label13);
            this.GB_Y轴设置.Controls.Add(this.TB_YS曲线);
            this.GB_Y轴设置.Controls.Add(this.TB_Y减速度);
            this.GB_Y轴设置.Controls.Add(this.TB_Y加速度);
            this.GB_Y轴设置.Controls.Add(this.TB_Y运行速度);
            this.GB_Y轴设置.Controls.Add(this.TB_Y脉冲当量);
            this.GB_Y轴设置.Controls.Add(this.label4);
            this.GB_Y轴设置.Controls.Add(this.label5);
            this.GB_Y轴设置.Controls.Add(this.label6);
            this.GB_Y轴设置.Controls.Add(this.label7);
            this.GB_Y轴设置.Controls.Add(this.label8);
            this.GB_Y轴设置.Location = new System.Drawing.Point(259, 10);
            this.GB_Y轴设置.Name = "GB_Y轴设置";
            this.GB_Y轴设置.Size = new System.Drawing.Size(245, 156);
            this.GB_Y轴设置.TabIndex = 1;
            this.GB_Y轴设置.TabStop = false;
            this.GB_Y轴设置.Text = "Y轴设置";
            // 
            // TB_YS曲线
            // 
            this.TB_YS曲线.Location = new System.Drawing.Point(65, 124);
            this.TB_YS曲线.Name = "TB_YS曲线";
            this.TB_YS曲线.Size = new System.Drawing.Size(50, 21);
            this.TB_YS曲线.TabIndex = 18;
            this.TB_YS曲线.Text = "0";
            // 
            // TB_Y减速度
            // 
            this.TB_Y减速度.Location = new System.Drawing.Point(65, 97);
            this.TB_Y减速度.Name = "TB_Y减速度";
            this.TB_Y减速度.Size = new System.Drawing.Size(50, 21);
            this.TB_Y减速度.TabIndex = 17;
            this.TB_Y减速度.Text = "1000";
            // 
            // TB_Y加速度
            // 
            this.TB_Y加速度.Location = new System.Drawing.Point(65, 70);
            this.TB_Y加速度.Name = "TB_Y加速度";
            this.TB_Y加速度.Size = new System.Drawing.Size(50, 21);
            this.TB_Y加速度.TabIndex = 16;
            this.TB_Y加速度.Text = "1000";
            // 
            // TB_Y运行速度
            // 
            this.TB_Y运行速度.Location = new System.Drawing.Point(65, 42);
            this.TB_Y运行速度.Name = "TB_Y运行速度";
            this.TB_Y运行速度.Size = new System.Drawing.Size(50, 21);
            this.TB_Y运行速度.TabIndex = 15;
            this.TB_Y运行速度.Text = "100";
            // 
            // TB_Y脉冲当量
            // 
            this.TB_Y脉冲当量.Location = new System.Drawing.Point(65, 14);
            this.TB_Y脉冲当量.Name = "TB_Y脉冲当量";
            this.TB_Y脉冲当量.Size = new System.Drawing.Size(50, 21);
            this.TB_Y脉冲当量.TabIndex = 11;
            this.TB_Y脉冲当量.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "S曲线";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "减速度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "加速度";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "运行速度";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "脉冲当量";
            // 
            // GB_X轴设置
            // 
            this.GB_X轴设置.Controls.Add(this.TB_负限位信号X);
            this.GB_X轴设置.Controls.Add(this.label15);
            this.GB_X轴设置.Controls.Add(this.TB_正限位信号X);
            this.GB_X轴设置.Controls.Add(this.label14);
            this.GB_X轴设置.Controls.Add(this.TB_原点信号X);
            this.GB_X轴设置.Controls.Add(this.label12);
            this.GB_X轴设置.Controls.Add(this.TB_XS曲线);
            this.GB_X轴设置.Controls.Add(this.TB_X减速度);
            this.GB_X轴设置.Controls.Add(this.TB_X加速度);
            this.GB_X轴设置.Controls.Add(this.TB_X运行速度);
            this.GB_X轴设置.Controls.Add(this.TB_X脉冲当量);
            this.GB_X轴设置.Controls.Add(this.label3);
            this.GB_X轴设置.Controls.Add(this.减速度);
            this.GB_X轴设置.Controls.Add(this.加速度);
            this.GB_X轴设置.Controls.Add(this.label2);
            this.GB_X轴设置.Controls.Add(this.label1);
            this.GB_X轴设置.Location = new System.Drawing.Point(8, 10);
            this.GB_X轴设置.Name = "GB_X轴设置";
            this.GB_X轴设置.Size = new System.Drawing.Size(245, 156);
            this.GB_X轴设置.TabIndex = 0;
            this.GB_X轴设置.TabStop = false;
            this.GB_X轴设置.Text = "X轴设置";
            // 
            // TB_XS曲线
            // 
            this.TB_XS曲线.Location = new System.Drawing.Point(65, 124);
            this.TB_XS曲线.Name = "TB_XS曲线";
            this.TB_XS曲线.Size = new System.Drawing.Size(50, 21);
            this.TB_XS曲线.TabIndex = 8;
            this.TB_XS曲线.Text = "0";
            // 
            // TB_X减速度
            // 
            this.TB_X减速度.Location = new System.Drawing.Point(65, 97);
            this.TB_X减速度.Name = "TB_X减速度";
            this.TB_X减速度.Size = new System.Drawing.Size(50, 21);
            this.TB_X减速度.TabIndex = 7;
            this.TB_X减速度.Text = "1000";
            // 
            // TB_X加速度
            // 
            this.TB_X加速度.Location = new System.Drawing.Point(65, 70);
            this.TB_X加速度.Name = "TB_X加速度";
            this.TB_X加速度.Size = new System.Drawing.Size(50, 21);
            this.TB_X加速度.TabIndex = 6;
            this.TB_X加速度.Text = "1000";
            // 
            // TB_X运行速度
            // 
            this.TB_X运行速度.Location = new System.Drawing.Point(65, 42);
            this.TB_X运行速度.Name = "TB_X运行速度";
            this.TB_X运行速度.Size = new System.Drawing.Size(50, 21);
            this.TB_X运行速度.TabIndex = 5;
            this.TB_X运行速度.Text = "100";
            // 
            // TB_X脉冲当量
            // 
            this.TB_X脉冲当量.Location = new System.Drawing.Point(65, 14);
            this.TB_X脉冲当量.Name = "TB_X脉冲当量";
            this.TB_X脉冲当量.Size = new System.Drawing.Size(50, 21);
            this.TB_X脉冲当量.TabIndex = 2;
            this.TB_X脉冲当量.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "S曲线";
            // 
            // 减速度
            // 
            this.减速度.AutoSize = true;
            this.减速度.Location = new System.Drawing.Point(6, 100);
            this.减速度.Name = "减速度";
            this.减速度.Size = new System.Drawing.Size(41, 12);
            this.减速度.TabIndex = 3;
            this.减速度.Text = "减速度";
            // 
            // 加速度
            // 
            this.加速度.AutoSize = true;
            this.加速度.Location = new System.Drawing.Point(6, 73);
            this.加速度.Name = "加速度";
            this.加速度.Size = new System.Drawing.Size(41, 12);
            this.加速度.TabIndex = 2;
            this.加速度.Text = "加速度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "运行速度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "脉冲当量";
            // 
            // BTN_保存设置
            // 
            this.BTN_保存设置.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_保存设置.Location = new System.Drawing.Point(709, 393);
            this.BTN_保存设置.Name = "BTN_保存设置";
            this.BTN_保存设置.Size = new System.Drawing.Size(75, 23);
            this.BTN_保存设置.TabIndex = 5;
            this.BTN_保存设置.Text = "保存";
            this.BTN_保存设置.UseVisualStyleBackColor = true;
            this.BTN_保存设置.Click += new System.EventHandler(this.BTN_保存设置_Click);
            // 
            // TB_原点信号X
            // 
            this.TB_原点信号X.Location = new System.Drawing.Point(187, 14);
            this.TB_原点信号X.Name = "TB_原点信号X";
            this.TB_原点信号X.Size = new System.Drawing.Size(50, 21);
            this.TB_原点信号X.TabIndex = 10;
            this.TB_原点信号X.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(121, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "原点信号";
            // 
            // TB_原点信号Y
            // 
            this.TB_原点信号Y.Location = new System.Drawing.Point(189, 14);
            this.TB_原点信号Y.Name = "TB_原点信号Y";
            this.TB_原点信号Y.Size = new System.Drawing.Size(50, 21);
            this.TB_原点信号Y.TabIndex = 20;
            this.TB_原点信号Y.Text = "3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(121, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 19;
            this.label13.Text = "原点信号";
            // 
            // TB_正限位信号X
            // 
            this.TB_正限位信号X.Location = new System.Drawing.Point(187, 42);
            this.TB_正限位信号X.Name = "TB_正限位信号X";
            this.TB_正限位信号X.Size = new System.Drawing.Size(50, 21);
            this.TB_正限位信号X.TabIndex = 12;
            this.TB_正限位信号X.Text = "1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(121, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 11;
            this.label14.Text = "正限位信号";
            // 
            // TB_负限位信号X
            // 
            this.TB_负限位信号X.Location = new System.Drawing.Point(187, 70);
            this.TB_负限位信号X.Name = "TB_负限位信号X";
            this.TB_负限位信号X.Size = new System.Drawing.Size(50, 21);
            this.TB_负限位信号X.TabIndex = 14;
            this.TB_负限位信号X.Text = "-1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(121, 73);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 13;
            this.label15.Text = "负限位信号";
            // 
            // TB_负限位信号Y
            // 
            this.TB_负限位信号Y.Location = new System.Drawing.Point(187, 70);
            this.TB_负限位信号Y.Name = "TB_负限位信号Y";
            this.TB_负限位信号Y.Size = new System.Drawing.Size(50, 21);
            this.TB_负限位信号Y.TabIndex = 24;
            this.TB_负限位信号Y.Text = "-1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(121, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 23;
            this.label16.Text = "负限位信号";
            // 
            // TB_正限位信号Y
            // 
            this.TB_正限位信号Y.Location = new System.Drawing.Point(187, 42);
            this.TB_正限位信号Y.Name = "TB_正限位信号Y";
            this.TB_正限位信号Y.Size = new System.Drawing.Size(50, 21);
            this.TB_正限位信号Y.TabIndex = 22;
            this.TB_正限位信号Y.Text = "4";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(121, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 21;
            this.label17.Text = "正限位信号";
            // 
            // TP_校准
            // 
            this.TP_校准.Controls.Add(this.GB_零点校准);
            this.TP_校准.Location = new System.Drawing.Point(4, 22);
            this.TP_校准.Name = "TP_校准";
            this.TP_校准.Size = new System.Drawing.Size(792, 424);
            this.TP_校准.TabIndex = 3;
            this.TP_校准.Text = "校准";
            this.TP_校准.UseVisualStyleBackColor = true;
            // 
            // LB_当前X轴位置
            // 
            this.LB_当前X轴位置.AutoSize = true;
            this.LB_当前X轴位置.Location = new System.Drawing.Point(6, 17);
            this.LB_当前X轴位置.Name = "LB_当前X轴位置";
            this.LB_当前X轴位置.Size = new System.Drawing.Size(65, 12);
            this.LB_当前X轴位置.TabIndex = 1;
            this.LB_当前X轴位置.Text = "当前位置：";
            // 
            // LB_当前Y轴位置
            // 
            this.LB_当前Y轴位置.AutoSize = true;
            this.LB_当前Y轴位置.Location = new System.Drawing.Point(6, 17);
            this.LB_当前Y轴位置.Name = "LB_当前Y轴位置";
            this.LB_当前Y轴位置.Size = new System.Drawing.Size(65, 12);
            this.LB_当前Y轴位置.TabIndex = 1;
            this.LB_当前Y轴位置.Text = "当前位置：";
            // 
            // GB_零点校准
            // 
            this.GB_零点校准.Controls.Add(this.CB_回零方向);
            this.GB_零点校准.Controls.Add(this.BTN_校准停止);
            this.GB_零点校准.Controls.Add(this.BTN_回零校准);
            this.GB_零点校准.Controls.Add(this.BTN_位置清零);
            this.GB_零点校准.Controls.Add(this.TB_AxisCode);
            this.GB_零点校准.Controls.Add(this.label18);
            this.GB_零点校准.Location = new System.Drawing.Point(8, 14);
            this.GB_零点校准.Name = "GB_零点校准";
            this.GB_零点校准.Size = new System.Drawing.Size(211, 115);
            this.GB_零点校准.TabIndex = 0;
            this.GB_零点校准.TabStop = false;
            this.GB_零点校准.Text = "零点校准";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 29);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "轴号";
            // 
            // TB_AxisCode
            // 
            this.TB_AxisCode.Location = new System.Drawing.Point(52, 26);
            this.TB_AxisCode.Name = "TB_AxisCode";
            this.TB_AxisCode.Size = new System.Drawing.Size(50, 21);
            this.TB_AxisCode.TabIndex = 1;
            this.TB_AxisCode.Text = "0";
            // 
            // BTN_回零校准
            // 
            this.BTN_回零校准.Location = new System.Drawing.Point(117, 24);
            this.BTN_回零校准.Name = "BTN_回零校准";
            this.BTN_回零校准.Size = new System.Drawing.Size(75, 23);
            this.BTN_回零校准.TabIndex = 2;
            this.BTN_回零校准.Text = "回零校准";
            this.BTN_回零校准.UseVisualStyleBackColor = true;
            this.BTN_回零校准.Click += new System.EventHandler(this.BTN_回零校准_Click);
            // 
            // BTN_位置清零
            // 
            this.BTN_位置清零.Location = new System.Drawing.Point(117, 53);
            this.BTN_位置清零.Name = "BTN_位置清零";
            this.BTN_位置清零.Size = new System.Drawing.Size(75, 23);
            this.BTN_位置清零.TabIndex = 3;
            this.BTN_位置清零.Text = "位置清零";
            this.BTN_位置清零.UseVisualStyleBackColor = true;
            this.BTN_位置清零.Click += new System.EventHandler(this.BTN_位置清零_Click);
            // 
            // BTN_校准停止
            // 
            this.BTN_校准停止.Location = new System.Drawing.Point(117, 82);
            this.BTN_校准停止.Name = "BTN_校准停止";
            this.BTN_校准停止.Size = new System.Drawing.Size(75, 23);
            this.BTN_校准停止.TabIndex = 1;
            this.BTN_校准停止.Text = "停止";
            this.BTN_校准停止.UseVisualStyleBackColor = true;
            this.BTN_校准停止.Click += new System.EventHandler(this.BTN_校准停止_Click);
            // 
            // CB_回零方向
            // 
            this.CB_回零方向.AutoSize = true;
            this.CB_回零方向.Checked = true;
            this.CB_回零方向.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_回零方向.Location = new System.Drawing.Point(30, 60);
            this.CB_回零方向.Name = "CB_回零方向";
            this.CB_回零方向.Size = new System.Drawing.Size(72, 16);
            this.CB_回零方向.TabIndex = 4;
            this.CB_回零方向.Text = "反向回零";
            this.CB_回零方向.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.TP_自动.ResumeLayout(false);
            this.TP_手动.ResumeLayout(false);
            this.GB_Y.ResumeLayout(false);
            this.GB_Y.PerformLayout();
            this.GB_X.ResumeLayout(false);
            this.GB_X.PerformLayout();
            this.TP_设置.ResumeLayout(false);
            this.TP_设置.PerformLayout();
            this.GB_切割设置.ResumeLayout(false);
            this.GB_切割设置.PerformLayout();
            this.GB_Y轴设置.ResumeLayout(false);
            this.GB_Y轴设置.PerformLayout();
            this.GB_X轴设置.ResumeLayout(false);
            this.GB_X轴设置.PerformLayout();
            this.TP_校准.ResumeLayout(false);
            this.GB_零点校准.ResumeLayout(false);
            this.GB_零点校准.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TP_自动;
        private System.Windows.Forms.TabPage TP_手动;
        private System.Windows.Forms.Button BTN_连接;
        private System.Windows.Forms.Button BTN_自动模式;
        private System.Windows.Forms.Button BTN_自动运行;
        private System.Windows.Forms.Button BTN_手动模式;
        private System.Windows.Forms.Button BTN_自动停止;
        private System.Windows.Forms.TabPage TP_设置;
        private System.Windows.Forms.GroupBox GB_X轴设置;
        private System.Windows.Forms.GroupBox GB_Y轴设置;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label 减速度;
        private System.Windows.Forms.Label 加速度;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_YS曲线;
        private System.Windows.Forms.TextBox TB_Y减速度;
        private System.Windows.Forms.TextBox TB_Y加速度;
        private System.Windows.Forms.TextBox TB_Y运行速度;
        private System.Windows.Forms.TextBox TB_Y脉冲当量;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_XS曲线;
        private System.Windows.Forms.TextBox TB_X减速度;
        private System.Windows.Forms.TextBox TB_X加速度;
        private System.Windows.Forms.TextBox TB_X运行速度;
        private System.Windows.Forms.TextBox TB_X脉冲当量;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTN_初始化;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TB_AxisType;
        private System.Windows.Forms.GroupBox GB_Y;
        private System.Windows.Forms.GroupBox GB_X;
        private System.Windows.Forms.Button BTN_Y回原点;
        private System.Windows.Forms.Button BTN_X回原点;
        private System.Windows.Forms.GroupBox GB_切割设置;
        private System.Windows.Forms.TextBox TB_间隔1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TB_间隔2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BTN_保存设置;
        private System.Windows.Forms.TextBox TB_原点信号Y;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TB_原点信号X;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TB_负限位信号X;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TB_正限位信号X;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TB_负限位信号Y;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TB_正限位信号Y;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage TP_校准;
        private System.Windows.Forms.Label LB_当前Y轴位置;
        private System.Windows.Forms.Label LB_当前X轴位置;
        private System.Windows.Forms.GroupBox GB_零点校准;
        private System.Windows.Forms.TextBox TB_AxisCode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button BTN_位置清零;
        private System.Windows.Forms.Button BTN_回零校准;
        private System.Windows.Forms.Button BTN_校准停止;
        private System.Windows.Forms.CheckBox CB_回零方向;
    }
}

