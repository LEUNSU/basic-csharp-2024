namespace Scheduler
{
    public partial class FrmScheduler : Form
    {
        private string? date; // 날짜 저장 변수
        private string? path; // 파일 경로 저장 변수

        public FrmScheduler()
        {
            InitializeComponent();
        }

        /*private void CreateDirectory() // !!!!!!!!안 돼서 c:\ 디렉터리에 미리 'MyDiary' 폴더 만든 후 실행!!!!!!!!!
        {
            DirectoryInfo dir = new DirectoryInfo(@"c:\");
            dir.CreateSubdirectory("MyDiary");
        }
        */

        private void FrmSchedular_Load(object sender, EventArgs e)
        {
            //CreateDirectory();
            TodayDate();  // 폼 로드시 TodayDate 메서드를 호출해서 오늘의 일정 표시
        }


        private void TodayDate() // 오늘 날짜에 보관된 데이터 불러오기
        {
            date = DateTime.Now.ToString("yyyy-MM-dd");
            path = string.Format(@"c:\MyDiary\{0}.txt", date);

            try
            {
                if (File.Exists(path))
                {
                    string text = File.ReadAllText(path);
                    AddItemsToListBox(text);
                }
                else
                {
                    // 파일이 없을 때 초기화
                    ScheduleList.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류" + ex.Message);
            }
        }

        private void AddItemsToListBox(string text)
        {
            // 텍스트를 줄 단위로 분할하여 ListBox에 아이템 추가
            ScheduleList.Rows.Clear();
            string[] items = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
                ScheduleList.Rows.Add(item);
            }
        }

        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTimePicker.Value = MonthCalendar.SelectionStart; // MonthCalender의 선택된 날짜로 DateTimePicker 값 업데이트

            // 선택한 날짜 TxtDate 텍스트박스에 표시
            if (MonthCalendar.SelectionRange.Start == MonthCalendar.SelectionRange.End)
            {
                TxtDate.Text = MonthCalendar.SelectionRange.Start.ToString("yyyy-MM-dd");
            }
            else
            {
                TxtDate.Text = MonthCalendar.SelectionRange.Start.ToString("yyyy-MM-dd") + "~" + MonthCalendar.SelectionRange.End.ToString("yyyy-MM-dd");
            }
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            date = e.Start.ToShortDateString(); // 선택한 날짜를 가져와 date에 저장
            path = Path.Combine(@"c:\MyDiary", $"{date}.txt"); // 선택한 날짜에 해당하는 파일 경로 생성

            try
            {
                if (File.Exists(path))
                {
                    string text = File.ReadAllText(path);
                    AddItemsToListBox(text);

                }
                else
                {
                    ScheduleList.Rows.Clear();
                    MessageBox.Show("해당 날짜의 일정이 없습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("파일을 읽어오는 동안 오류가 발생했습니다: " + ex.Message);
            }
        }
        private void DateTimePicker_ValueChanged(object sender, EventArgs e) // 날짜 선택기에서 날짜가 변경되었을 때
        {
            MonthCalendar.SetDate(DateTimePicker.Value); // DateTimePicker의 값으로 MonthCalendar 선택 날짜 업데이트

            TxtDate.Text = DateTimePicker.Value.ToString("yyyy-MM-dd");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSchedule.Text))
            {
                MessageBox.Show("일정을 입력하세요.");
                return;
            }

            ScheduleList.Rows.Add(TxtSchedule.Text, false);
            TxtSchedule.Text = "";

            try
            {
                var tempDate = TxtDate.Text;
                if (tempDate.IndexOf("~") > -1) // 날짜가 범위인 경우
                {
                    var dates = tempDate.Split('~');
                    var startDate = DateTime.Parse(dates[0]);
                    var endDate = DateTime.Parse(dates[1]);

                    for (DateTime curDate = startDate; curDate <= endDate; curDate = curDate.AddDays(1))
                    {
                        var path = Path.Combine(@"c:\MyDiary", $"{curDate.ToString("yyyy-MM-dd")}.txt");

                        // DataGridView의 모든 행을 텍스트로 변환하여 저장
                        string newText = "";
                        foreach (DataGridViewRow row in ScheduleList.Rows)
                        {
                            newText += row.Cells[0].Value?.ToString() + Environment.NewLine;
                        }
                        File.WriteAllText(path, newText);
                    }

                    MessageBox.Show("일정이 성공적으로 저장되었습니다.");
                }
                else // 단일 날짜인 경우
                {
                    var path = Path.Combine(@"c:\MyDiary", $"{date}.txt");

                    // DataGridView의 모든 행을 텍스트로 변환하여 저장
                    string newText = "";
                    foreach (DataGridViewRow row in ScheduleList.Rows)
                    {
                        newText += row.Cells[0].Value?.ToString() + Environment.NewLine;
                    }
                    File.WriteAllText(path, newText);

                    MessageBox.Show("일정이 성공적으로 저장되었습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류가 발생했습니다: {ex.Message}");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (ScheduleList.SelectedRows.Count == 0)
            {
                MessageBox.Show("삭제할 일정을 선택하세요.");
                return;
            }

            foreach (DataGridViewRow row in ScheduleList.SelectedRows)
            {
                ScheduleList.Rows.Remove(row);
            }

            try
            {
                var path = Path.Combine(@"c:\MyDiary", $"{date}.txt");
                if (File.Exists(path))
                {
                    // DataGridView의 모든 행을 텍스트로 변환하여 저장
                    string newText = "";
                    foreach (DataGridViewRow row in ScheduleList.Rows)
                    {
                        newText += row.Cells[0].Value?.ToString() + Environment.NewLine;
                    }
                    File.WriteAllText(path, newText);

                    MessageBox.Show("일정이 성공적으로 삭제되었습니다.");
                }
                else
                {
                    MessageBox.Show("삭제할 파일이 존재하지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("파일을 삭제하는 동안 오류가 발생했습니다: " + ex.Message);
            }
        }
        private void ScheduleList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ScheduleList.CurrentCell != null)
            {
                if ((bool)ScheduleList.SelectedRows[0].Cells[1].Value == true)
                    ScheduleList.SelectedRows[0].Cells[1].Value = false;
                else
                    ScheduleList.SelectedRows[0].Cells[1].Value = true;
            }
        }
    }
}

/*TODO
 * 체크리스트 예외처리
 * 개핵똥방구디자인 고치기
*/