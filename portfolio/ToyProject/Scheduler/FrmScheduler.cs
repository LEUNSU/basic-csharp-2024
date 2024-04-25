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

        private void Form1_Load(object sender, EventArgs e)
        {
            TodayDate();  // 폼 로드시 TodayDate 메서드를 호출해서 오늘의 일정 표시
        }

        /* private void CreateDirectory() // 안 돼서 c:\ 디렉터리에 미리 'MyDiary' 폴더 만든 후 실행
        {
            DirectoryInfo dir = new DirectoryInfo(@"c:\");
            dir.CreateSubdirectory("MyDiary");
        }
        */

        private void TodayDate() // 오늘 날짜에 보관된 데이터 불러오기

        {
            date = DateTime.Now.ToString("yyyy-MM-dd"); 
            path = string.Format(@"c:\MyDiary\{0}.txt", date);

            try
            {
                if (File.Exists(path))
                {
                    string text = File.ReadAllText(path);
                    ScheduleList.Text = text; // 파일이 있으면 해당 파일의 내용을 ScheduleList 텍스트박스에 표시
                }
                else
                {
                    ScheduleList.Text = ""; // 파일이 없으면 내용을 빈 문자열로 표시
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("오류" + ex.Message);
            }
        }
        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e) // 날짜 선택했을 때
        {
            // 선택한 날짜 일정 표시 
            date = e.Start.ToShortDateString(); // 선택한 날짜를 가져와 date에 저장
            path = Path.Combine(@"c:\MyDiary", $"{date}.txt"); // 선택한 날짜에 해당하는 파일 경로 생성

            try
            {
                if (File.Exists(path))
                {
                    string text = File.ReadAllText(path);
                    ScheduleList.Text = text;
                }
                else
                {
                    ScheduleList.Text = "";
                    MessageBox.Show("해당 날짜의 일정이 없습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("파일을 읽어오는 동안 오류가 발생했습니다: " + ex.Message);
            }

        }
        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e) // 달력에서 날짜가 변경되었을 때
        {
            DateTimePicker.Value = MonthCalendar.SelectionStart; // MonthCalendar의 선택된 날짜로 DateTimePicker 값 업데이트

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
        private void DateTimePicker_ValueChanged(object sender, EventArgs e) // 날짜 선택기에서 날짜가 변경되었을 때
        {
            MonthCalendar.SetDate(DateTimePicker.Value); // DateTimePicker의 값으로 MonthCalendar 선택 날짜 업데이트

            TxtDate.Text = DateTimePicker.Value.ToString("yyyy-MM-dd");
        }

        private void BtnSave_Click(object sender, EventArgs e) // 저장 버튼 눌렀을 때
        {
            try
            {
                // 날짜가 하나인지 여러개인지 구분
                var tempDate = TxtDate.Text;
                if (tempDate.IndexOf("~") > -1)
                {
                    var dates = tempDate.Split('~');
                    //MessageBox.Show(dates[0], dates[1]);
                    var startDate = DateTime.Parse(dates[0]);
                    var endDate = DateTime.Parse(dates[1]);

                    TimeSpan dateDiff = endDate - startDate;
                    int diffDay = dateDiff.Days + 1;
                    for (int i = 0; i < diffDay; i++)
                    {
                        var curDate = startDate.AddDays(i);
                        //MessageBox.Show(curDate.ToString()); // 여기 밑에 저장하면 됨
                        var dateString = curDate.ToString("yyyy-MM-dd");
                        var path = Path.Combine(@"c:\MyDiary", $"{dateString}.txt");

                        try
                        {
                            string newText = ScheduleList.Text; // 텍스트 박스 내용을 저장할 텍스트로 설정
                            File.WriteAllText(path, newText);
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show($"파일을 저장하는 동안 오류가 발생했습니다: {ex.Message}");
                        }
                    }

                    MessageBox.Show("일정이 성공적으로 저장되었습니다.");
                }
                else // 하루일 경우
                {
                    path = string.Format(@"c:\MyDiary\{0}.txt", date);

                    try

                    {
                        string newText = ScheduleList.Text;
                        File.WriteAllText(path, newText);
                        MessageBox.Show("일정이 성공적으로 저장되었습니다.");

                    }

                    catch
                    {
                        MessageBox.Show("오류");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류가 발생했습니다: {ex.Message}");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e) // 삭제 버튼 눌렀을 때
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    MessageBox.Show("일정이 성공적으로 삭제되었습니다.");
                    ScheduleList.Text = ""; // 파일 삭제 후 텍스트박스 내용 초기화
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

    }
}

/*TODO
1.약속시간설정기능 추가
2.텍스트박스를 체크드리스트박스로 바꿔서 할 수 있을까.. 너무 복잡해지는데..
3.디자인도 좀 예쁘게 바꿔야지.. 지금은 너무 핵똥구리다..
4.디렉토리생성 왜 안 되는지도 알아보고..
5.
*/