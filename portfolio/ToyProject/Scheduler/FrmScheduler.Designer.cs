namespace Scheduler
{
    partial class FrmScheduler
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            ScheduleList = new TextBox();
            TxtDate = new TextBox();
            BtnDelete = new Button();
            BtnSave = new Button();
            MonthCalendar = new MonthCalendar();
            DateTimePicker = new DateTimePicker();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ScheduleList);
            groupBox1.Controls.Add(TxtDate);
            groupBox1.Controls.Add(BtnDelete);
            groupBox1.Controls.Add(BtnSave);
            groupBox1.Controls.Add(MonthCalendar);
            groupBox1.Controls.Add(DateTimePicker);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(473, 310);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Schedule";
            // 
            // ScheduleList
            // 
            ScheduleList.Location = new Point(244, 76);
            ScheduleList.Multiline = true;
            ScheduleList.Name = "ScheduleList";
            ScheduleList.Size = new Size(213, 162);
            ScheduleList.TabIndex = 7;
            // 
            // TxtDate
            // 
            TxtDate.Location = new Point(244, 38);
            TxtDate.Multiline = true;
            TxtDate.Name = "TxtDate";
            TxtDate.Size = new Size(213, 23);
            TxtDate.TabIndex = 4;
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(353, 261);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(90, 33);
            BtnDelete.TabIndex = 3;
            BtnDelete.Text = "삭제";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(257, 261);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(90, 33);
            BtnSave.TabIndex = 3;
            BtnSave.Text = "저장";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // MonthCalendar
            // 
            MonthCalendar.Location = new Point(12, 76);
            MonthCalendar.Name = "MonthCalendar";
            MonthCalendar.TabIndex = 1;
            MonthCalendar.DateChanged += MonthCalendar_DateChanged;
            MonthCalendar.DateSelected += MonthCalendar_DateSelected;
            // 
            // DateTimePicker
            // 
            DateTimePicker.Location = new Point(12, 38);
            DateTimePicker.Name = "DateTimePicker";
            DateTimePicker.Size = new Size(220, 23);
            DateTimePicker.TabIndex = 0;
            DateTimePicker.ValueChanged += DateTimePicker_ValueChanged;
            // 
            // FrmScheduler
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 334);
            Controls.Add(groupBox1);
            Name = "FrmScheduler";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private MonthCalendar MonthCalendar;
        private DateTimePicker DateTimePicker;
        private Button BtnDelete;
        private Button BtnSave;
        private TextBox TxtDate;
        private TextBox ScheduleList;
    }
}
