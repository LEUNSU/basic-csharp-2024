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
            Schedule = new GroupBox();
            ScheduleList = new DataGridView();
            ColContent = new DataGridViewTextBoxColumn();
            ColYn = new DataGridViewCheckBoxColumn();
            TxtSchedule = new TextBox();
            BtnDelete = new Button();
            BtnSave = new Button();
            TxtDate = new TextBox();
            DateTimePicker = new DateTimePicker();
            MonthCalendar = new MonthCalendar();
            Schedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ScheduleList).BeginInit();
            SuspendLayout();
            // 
            // Schedule
            // 
            Schedule.Controls.Add(ScheduleList);
            Schedule.Controls.Add(TxtSchedule);
            Schedule.Controls.Add(BtnDelete);
            Schedule.Controls.Add(BtnSave);
            Schedule.Controls.Add(TxtDate);
            Schedule.Controls.Add(DateTimePicker);
            Schedule.Controls.Add(MonthCalendar);
            Schedule.Location = new Point(12, 12);
            Schedule.Name = "Schedule";
            Schedule.Size = new Size(504, 320);
            Schedule.TabIndex = 0;
            Schedule.TabStop = false;
            Schedule.Text = "Schedule";
            // 
            // ScheduleList
            // 
            ScheduleList.AllowUserToAddRows = false;
            ScheduleList.AllowUserToDeleteRows = false;
            ScheduleList.BackgroundColor = SystemColors.ControlLight;
            ScheduleList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ScheduleList.Columns.AddRange(new DataGridViewColumn[] { ColContent, ColYn });
            ScheduleList.Location = new Point(244, 68);
            ScheduleList.Name = "ScheduleList";
            ScheduleList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ScheduleList.Size = new Size(249, 174);
            ScheduleList.TabIndex = 7;
            ScheduleList.CellClick += ScheduleList_CellClick;
            // 
            // ColContent
            // 
            ColContent.HeaderText = "내용";
            ColContent.Name = "ColContent";
            ColContent.ReadOnly = true;
            ColContent.Width = 150;
            // 
            // ColYn
            // 
            ColYn.FalseValue = "false";
            ColYn.HeaderText = "실행";
            ColYn.Name = "ColYn";
            ColYn.ReadOnly = true;
            ColYn.Resizable = DataGridViewTriState.False;
            ColYn.SortMode = DataGridViewColumnSortMode.Automatic;
            ColYn.TrueValue = "true";
            ColYn.Width = 60;
            // 
            // TxtSchedule
            // 
            TxtSchedule.Location = new Point(244, 248);
            TxtSchedule.Name = "TxtSchedule";
            TxtSchedule.Size = new Size(249, 23);
            TxtSchedule.TabIndex = 6;
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(371, 279);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(81, 28);
            BtnDelete.TabIndex = 5;
            BtnDelete.Text = "삭제";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(284, 279);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(81, 28);
            BtnSave.TabIndex = 4;
            BtnSave.Text = "저장";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // TxtDate
            // 
            TxtDate.BackColor = Color.FromArgb(224, 224, 224);
            TxtDate.Location = new Point(244, 33);
            TxtDate.Name = "TxtDate";
            TxtDate.Size = new Size(249, 23);
            TxtDate.TabIndex = 2;
            // 
            // DateTimePicker
            // 
            DateTimePicker.Location = new Point(12, 33);
            DateTimePicker.Name = "DateTimePicker";
            DateTimePicker.Size = new Size(220, 23);
            DateTimePicker.TabIndex = 1;
            DateTimePicker.ValueChanged += DateTimePicker_ValueChanged;
            // 
            // MonthCalendar
            // 
            MonthCalendar.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            MonthCalendar.Location = new Point(12, 74);
            MonthCalendar.Name = "MonthCalendar";
            MonthCalendar.TabIndex = 0;
            MonthCalendar.DateChanged += MonthCalendar_DateChanged;
            MonthCalendar.DateSelected += MonthCalendar_DateSelected;
            // 
            // FrmScheduler
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 344);
            Controls.Add(Schedule);
            Name = "FrmScheduler";
            Text = "Scheduler";
            Schedule.ResumeLayout(false);
            Schedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ScheduleList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox Schedule;
        private Button BtnDelete;
        private Button BtnSave;
        private TextBox TxtDate;
        private DateTimePicker DateTimePicker;
        private MonthCalendar MonthCalendar;
        private TextBox TxtSchedule;
        private DataGridView ScheduleList;
        private DataGridViewTextBoxColumn ColContent;
        private DataGridViewCheckBoxColumn ColYn;
    }
}
