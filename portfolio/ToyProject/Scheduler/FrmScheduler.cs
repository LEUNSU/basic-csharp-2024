namespace Scheduler
{
    public partial class FrmScheduler : Form
    {
        private string? date; // ��¥ ���� ����
        private string? path; // ���� ��� ���� ����

        public FrmScheduler()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TodayDate();  // �� �ε�� TodayDate �޼��带 ȣ���ؼ� ������ ���� ǥ��
        }

        /* private void CreateDirectory() // �� �ż� c:\ ���͸��� �̸� 'MyDiary' ���� ���� �� ����
        {
            DirectoryInfo dir = new DirectoryInfo(@"c:\");
            dir.CreateSubdirectory("MyDiary");
        }
        */

        private void TodayDate() // ���� ��¥�� ������ ������ �ҷ�����

        {
            date = DateTime.Now.ToString("yyyy-MM-dd"); 
            path = string.Format(@"c:\MyDiary\{0}.txt", date);

            try
            {
                if (File.Exists(path))
                {
                    string text = File.ReadAllText(path);
                    ScheduleList.Text = text; // ������ ������ �ش� ������ ������ ScheduleList �ؽ�Ʈ�ڽ��� ǥ��
                }
                else
                {
                    ScheduleList.Text = ""; // ������ ������ ������ �� ���ڿ��� ǥ��
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("����" + ex.Message);
            }
        }
        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e) // ��¥ �������� ��
        {
            // ������ ��¥ ���� ǥ�� 
            date = e.Start.ToShortDateString(); // ������ ��¥�� ������ date�� ����
            path = Path.Combine(@"c:\MyDiary", $"{date}.txt"); // ������ ��¥�� �ش��ϴ� ���� ��� ����

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
                    MessageBox.Show("�ش� ��¥�� ������ �����ϴ�.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ �о���� ���� ������ �߻��߽��ϴ�: " + ex.Message);
            }

        }
        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e) // �޷¿��� ��¥�� ����Ǿ��� ��
        {
            DateTimePicker.Value = MonthCalendar.SelectionStart; // MonthCalendar�� ���õ� ��¥�� DateTimePicker �� ������Ʈ

            // ������ ��¥ TxtDate �ؽ�Ʈ�ڽ��� ǥ��
            if (MonthCalendar.SelectionRange.Start == MonthCalendar.SelectionRange.End)
            {
                TxtDate.Text = MonthCalendar.SelectionRange.Start.ToString("yyyy-MM-dd");
            }

            else
            {
                TxtDate.Text = MonthCalendar.SelectionRange.Start.ToString("yyyy-MM-dd") + "~" + MonthCalendar.SelectionRange.End.ToString("yyyy-MM-dd");
            }
        }
        private void DateTimePicker_ValueChanged(object sender, EventArgs e) // ��¥ ���ñ⿡�� ��¥�� ����Ǿ��� ��
        {
            MonthCalendar.SetDate(DateTimePicker.Value); // DateTimePicker�� ������ MonthCalendar ���� ��¥ ������Ʈ

            TxtDate.Text = DateTimePicker.Value.ToString("yyyy-MM-dd");
        }

        private void BtnSave_Click(object sender, EventArgs e) // ���� ��ư ������ ��
        {
            try
            {
                // ��¥�� �ϳ����� ���������� ����
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
                        //MessageBox.Show(curDate.ToString()); // ���� �ؿ� �����ϸ� ��
                        var dateString = curDate.ToString("yyyy-MM-dd");
                        var path = Path.Combine(@"c:\MyDiary", $"{dateString}.txt");

                        try
                        {
                            string newText = ScheduleList.Text; // �ؽ�Ʈ �ڽ� ������ ������ �ؽ�Ʈ�� ����
                            File.WriteAllText(path, newText);
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show($"������ �����ϴ� ���� ������ �߻��߽��ϴ�: {ex.Message}");
                        }
                    }

                    MessageBox.Show("������ ���������� ����Ǿ����ϴ�.");
                }
                else // �Ϸ��� ���
                {
                    path = string.Format(@"c:\MyDiary\{0}.txt", date);

                    try

                    {
                        string newText = ScheduleList.Text;
                        File.WriteAllText(path, newText);
                        MessageBox.Show("������ ���������� ����Ǿ����ϴ�.");

                    }

                    catch
                    {
                        MessageBox.Show("����");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ �߻��߽��ϴ�: {ex.Message}");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e) // ���� ��ư ������ ��
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    MessageBox.Show("������ ���������� �����Ǿ����ϴ�.");
                    ScheduleList.Text = ""; // ���� ���� �� �ؽ�Ʈ�ڽ� ���� �ʱ�ȭ
                }
                else
                {
                    MessageBox.Show("������ ������ �������� �ʽ��ϴ�.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ �����ϴ� ���� ������ �߻��߽��ϴ�: " + ex.Message);
            }
        }

    }
}

/*TODO
1.��ӽð�������� �߰�
2.�ؽ�Ʈ�ڽ��� üũ�帮��Ʈ�ڽ��� �ٲ㼭 �� �� ������.. �ʹ� ���������µ�..
3.�����ε� �� ���ڰ� �ٲ����.. ������ �ʹ� �ٶ˱�����..
4.���丮���� �� �� �Ǵ����� �˾ƺ���..
5.
*/