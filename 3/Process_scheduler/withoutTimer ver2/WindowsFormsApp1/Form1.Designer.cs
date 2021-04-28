using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
/**
 *  작성자: 오차영
 *  내용  : windowForm을 이용하여 다양한 디자인의 프로퍼티를 설정
 **/
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.inputArrivalTime = new System.Windows.Forms.TextBox();
            this.inputBurstTime = new System.Windows.Forms.TextBox();
            this.input = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.processList = new System.Windows.Forms.ListView();
            this.processId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.arrivalTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.burstTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priorityColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.watingTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.turnaroundTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nomalizedTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.schedulerList = new System.Windows.Forms.ListView();
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processor1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processor2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processor3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processor4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dummyImageList = new System.Windows.Forms.ImageList(this.components);
            this.start = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.schedulers = new System.Windows.Forms.ComboBox();
            this.colors = new System.Windows.Forms.ComboBox();
            this.processorNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rrNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.processNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.priority = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // inputArrivalTime
            // 
            this.inputArrivalTime.Location = new System.Drawing.Point(767, 47);
            this.inputArrivalTime.Name = "inputArrivalTime";
            this.inputArrivalTime.Size = new System.Drawing.Size(117, 25);
            this.inputArrivalTime.TabIndex = 0;
            // 
            // inputBurstTime
            // 
            this.inputBurstTime.Location = new System.Drawing.Point(767, 81);
            this.inputBurstTime.Name = "inputBurstTime";
            this.inputBurstTime.Size = new System.Drawing.Size(117, 25);
            this.inputBurstTime.TabIndex = 1;
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(907, 30);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(125, 28);
            this.input.TabIndex = 2;
            this.input.Text = "input";
            this.input.UseVisualStyleBackColor = true;
            this.input.Click += new System.EventHandler(this.input_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(907, 64);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(125, 28);
            this.reset.TabIndex = 7;
            this.reset.Text = "reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11F);
            this.label1.Location = new System.Drawing.Point(665, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "arrival time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11F);
            this.label2.Location = new System.Drawing.Point(678, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "bust time";
            // 
            // processList
            // 
            this.processList.BackColor = System.Drawing.SystemColors.Window;
            this.processList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.processId,
            this.arrivalTime,
            this.burstTime,
            this.priorityColumn,
            this.watingTime,
            this.turnaroundTime,
            this.nomalizedTT});
            this.processList.FullRowSelect = true;
            this.processList.GridLines = true;
            this.processList.HideSelection = false;
            this.processList.Location = new System.Drawing.Point(12, 152);
            this.processList.Name = "processList";
            this.processList.Size = new System.Drawing.Size(709, 495);
            this.processList.TabIndex = 15;
            this.processList.TabStop = false;
            this.processList.UseCompatibleStateImageBehavior = false;
            this.processList.View = System.Windows.Forms.View.Details;
            // 
            // processId
            // 
            this.processId.Text = "process Id";
            this.processId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.processId.Width = 75;
            // 
            // arrivalTime
            // 
            this.arrivalTime.Text = "arrival Time";
            this.arrivalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.arrivalTime.Width = 80;
            // 
            // burstTime
            // 
            this.burstTime.Text = "Burst Time";
            this.burstTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.burstTime.Width = 78;
            // 
            // priorityColumn
            // 
            this.priorityColumn.DisplayIndex = 6;
            this.priorityColumn.Text = "priority";
            this.priorityColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.priorityColumn.Width = 80;
            // 
            // watingTime
            // 
            this.watingTime.DisplayIndex = 3;
            this.watingTime.Text = "Wating Time";
            this.watingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.watingTime.Width = 84;
            // 
            // turnaroundTime
            // 
            this.turnaroundTime.DisplayIndex = 4;
            this.turnaroundTime.Text = "turnaroundTime";
            this.turnaroundTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.turnaroundTime.Width = 110;
            // 
            // nomalizedTT
            // 
            this.nomalizedTT.DisplayIndex = 5;
            this.nomalizedTT.Text = "Normalized TT";
            this.nomalizedTT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nomalizedTT.Width = 105;
            // 
            // schedulerList
            // 
            this.schedulerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.time,
            this.processor1,
            this.processor2,
            this.processor3,
            this.processor4});
            this.schedulerList.Font = new System.Drawing.Font("굴림", 10F);
            this.schedulerList.GridLines = true;
            this.schedulerList.HideSelection = false;
            this.schedulerList.Location = new System.Drawing.Point(727, 152);
            this.schedulerList.Name = "schedulerList";
            this.schedulerList.Size = new System.Drawing.Size(305, 495);
            this.schedulerList.SmallImageList = this.dummyImageList;
            this.schedulerList.TabIndex = 10;
            this.schedulerList.TabStop = false;
            this.schedulerList.UseCompatibleStateImageBehavior = false;
            this.schedulerList.View = System.Windows.Forms.View.Details;
            // 
            // time
            // 
            this.time.Text = "time";
            this.time.Width = 45;
            // 
            // processor1
            // 
            this.processor1.Text = "p1";
            this.processor1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.processor1.Width = 50;
            // 
            // processor2
            // 
            this.processor2.Text = "p2";
            this.processor2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.processor2.Width = 50;
            // 
            // processor3
            // 
            this.processor3.Text = "p3";
            this.processor3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.processor3.Width = 50;
            // 
            // processor4
            // 
            this.processor4.Text = "p4";
            this.processor4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.processor4.Width = 50;
            // 
            // dummyImageList
            // 
            this.dummyImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.dummyImageList.ImageSize = new System.Drawing.Size(1, 9);
            this.dummyImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(907, 98);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(125, 28);
            this.start.TabIndex = 6;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 20F);
            this.label4.Location = new System.Drawing.Point(12, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(468, 46);
            this.label4.TabIndex = 20;
            this.label4.Text = "2조 이기조 OS Team Project ";
            // 
            // schedulers
            // 
            this.schedulers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.schedulers.FormattingEnabled = true;
            this.schedulers.Items.AddRange(new object[] {
            "FCFS",
            "RR",
            "SPN",
            "SRTN",
            "HRRN",
            "TeamScheduler"});
            this.schedulers.Location = new System.Drawing.Point(109, 115);
            this.schedulers.Name = "schedulers";
            this.schedulers.Size = new System.Drawing.Size(237, 23);
            this.schedulers.TabIndex = 3;
            this.schedulers.SelectedIndexChanged += new System.EventHandler(this.schedulerList_SelectedIndexChanged);
            // 
            // colors
            // 
            this.colors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colors.FormattingEnabled = true;
            this.colors.Location = new System.Drawing.Point(109, 80);
            this.colors.Name = "colors";
            this.colors.Size = new System.Drawing.Size(237, 26);
            this.colors.TabIndex = 22;
            this.colors.TabStop = false;
            this.colors.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.colors_DrawItem);
            this.colors.SelectedIndexChanged += new System.EventHandler(this.colors_SelectedIndexChanged);
            // 
            // processorNum
            // 
            this.processorNum.Location = new System.Drawing.Point(767, 115);
            this.processorNum.Name = "processorNum";
            this.processorNum.Size = new System.Drawing.Size(117, 25);
            this.processorNum.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 11F);
            this.label5.Location = new System.Drawing.Point(617, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 19);
            this.label5.TabIndex = 24;
            this.label5.Text = "processor Count";
            // 
            // rrNum
            // 
            this.rrNum.Location = new System.Drawing.Point(439, 115);
            this.rrNum.Name = "rrNum";
            this.rrNum.ReadOnly = true;
            this.rrNum.Size = new System.Drawing.Size(125, 25);
            this.rrNum.TabIndex = 4;
            this.rrNum.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 11F);
            this.label6.Location = new System.Drawing.Point(390, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 19);
            this.label6.TabIndex = 26;
            this.label6.Text = "RR";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 11F);
            this.label7.Location = new System.Drawing.Point(15, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 19);
            this.label7.TabIndex = 27;
            this.label7.Text = "scheduler";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 11F);
            this.label8.Location = new System.Drawing.Point(47, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 19);
            this.label8.TabIndex = 28;
            this.label8.Text = "Color";
            // 
            // processNum
            // 
            this.processNum.Location = new System.Drawing.Point(519, 80);
            this.processNum.Name = "processNum";
            this.processNum.ReadOnly = true;
            this.processNum.Size = new System.Drawing.Size(45, 25);
            this.processNum.TabIndex = 29;
            this.processNum.TabStop = false;
            this.processNum.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 11F);
            this.label3.Location = new System.Drawing.Point(390, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 19);
            this.label3.TabIndex = 30;
            this.label3.Text = "process Num";
            // 
            // priority
            // 
            this.priority.Location = new System.Drawing.Point(767, 16);
            this.priority.Name = "priority";
            this.priority.ReadOnly = true;
            this.priority.Size = new System.Drawing.Size(117, 25);
            this.priority.TabIndex = 14;
            this.priority.TabStop = false;
            this.priority.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 11F);
            this.label9.Location = new System.Drawing.Point(693, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 19);
            this.label9.TabIndex = 100;
            this.label9.Text = "priority";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(426, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 39);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1043, 660);
            this.Controls.Add(this.inputArrivalTime);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.priority);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.processNum);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rrNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.processorNum);
            this.Controls.Add(this.colors);
            this.Controls.Add(this.schedulers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.start);
            this.Controls.Add(this.schedulerList);
            this.Controls.Add(this.processList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.input);
            this.Controls.Add(this.inputBurstTime);
            this.Name = "Form1";
            this.Text = "Process_Schduler_Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputArrivalTime;
       
        private System.Windows.Forms.TextBox inputBurstTime;
        private System.Windows.Forms.Button input;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView processList;

        private System.Windows.Forms.ColumnHeader processId;
        private System.Windows.Forms.ColumnHeader arrivalTime;
        private System.Windows.Forms.ColumnHeader burstTime;
        private System.Windows.Forms.ColumnHeader watingTime;
        private System.Windows.Forms.ColumnHeader turnaroundTime;
        private System.Windows.Forms.ColumnHeader nomalizedTT;
        private ListView schedulerList;
        private ColumnHeader time;
        private ColumnHeader processor1;
        private ColumnHeader processor2;
        private ColumnHeader processor3;
        private ColumnHeader processor4;
        private Button start;
        private Label label4;
        private System.Windows.Forms.ImageList dummyImageList;
        private ComboBox schedulers;
        private ComboBox colors;
        private List<Process> processes = new List<Process>();
        private Scheduler scheduler;
        private TextBox processorNum;
        private Label label5;
        private TextBox rrNum;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox processNum;
        private Label label3;
        private Color currentColor;
        private bool stop = false;
        private TextBox priority;
        private Label label9;
        private PictureBox pictureBox1;
        private ColumnHeader priorityColumn;
        private Bitmap picture;
    }

}

