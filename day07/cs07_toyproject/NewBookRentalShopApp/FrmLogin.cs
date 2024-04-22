using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace NewBookRentalShopApp
{
    public partial class FrmLogin : MetroForm
    {
        private bool isLogin = false;
        private string connString = "Data Source=localhost;"+
                                    "Initial Catalog=BookRentalShop2024;"+
                                    "Persist Security Info=True;"+
                                    "User ID=sa;Encrypt=False;Password=mssql_p@ss";

        public bool IsLogin{ // 로그인 성공여부 저장 변수
            get { return isLogin; }
            set { isLogin = value; }

        }
        public FrmLogin()
        {
            InitializeComponent();
            
            TxtUserId.Text = string.Empty;
            TxtPassword.Text = string.Empty;  
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Application.Exit(); // 종료시 종료를 물어보는 다이얼로그가 나타남
            Environment.Exit(0); // 무조건 종료
        }

        // 로그인 버튼 클릭 이벤트핸들러
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            bool isFail = false;
            string errMsg = string.Empty;

            if (string.IsNullOrEmpty(TxtUserId.Text))
            {
                isFail = true;
                errMsg += "아이디를 입력하세요.\n";
            }

            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                isFail = true;
                errMsg += "패스워드를 입력하세요.\n";
            }

            if (isFail == true)
            {
                MessageBox.Show(errMsg, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // DB연계
            IsLogin = LoginProcess(); // 로그인이 성공하면 True, 실패하면 False 리턴
            if (IsLogin) this.Close(); // 현재 로그인 창 닫기
        }

        // 로그인 DB 처리 시작 !
        private bool LoginProcess()
        {
            var md5Hash = MD5.Create();

            string userId = TxtUserId.Text; // 현재 DB로 넘기는 값
            string password = TxtPassword.Text;
            string chkUserId = string.Empty; // DB에서 넘어온 값
            string chkPassword = string.Empty;  

            /*
             * 1. Connection 생성, 오픈
             * 2. 쿼리 문자열 작성
             * 3. SqlCommand 명령용 객체 생성
             * 4. SqlParameter 객체 생성
             * 5. Select SqlDataReader, SqlDataSet 객체 사용
             * 6. CUD 작업 SqlCommand.ExecuteQuery()
             * 7. Connection 닫기
             */
            // 연결문자열(ConnectionString)
            // Data Source=localhost;Initial Catalog=BookRentalShop2024;Persist Security Info=True;User ID=sa;Encrypt=False;Password=mssql_p@ss
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // @userId, @password 쿼리문 외부에서 변수값을 안전하게 주입함
                string query = @"SELECT userId  
                                      , [password]
                                   FROM usertbl
                                  WHERE userId = @userId
                                    AND [password] = @password"; 
                SqlCommand cmd = new SqlCommand(query, conn);
                // @userId, @password 파라미터 할당
                SqlParameter prmUserId = new SqlParameter("@userId", userId);
                SqlParameter prmPassword = new SqlParameter("@password", GetMd5Hash(md5Hash, password));
                cmd.Parameters.Add(prmUserId);
                cmd.Parameters.Add(prmPassword);
                
                SqlDataReader reader = cmd.ExecuteReader(); // 

                if (reader.Read())
                {
                    chkUserId = reader["userId"] != null ? reader["userId"].ToString() : "-"; // 유저아이디가 null일 때 -로 변경
                    chkPassword = reader["password"] != null ? reader["password"].ToString() : "-"; // 패스워드가 null이면 -로 변경

                    return true;
                }
                else
                {
                    MessageBox.Show("로그인 정보가 없습니다", "DB오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

            } // using을 사용하면 conn.Close()가 필요없음
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // 13 = 엔터키
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void TxtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                TxtPassword.Focus();
            }
        }

        // MD5 해시 알고리즘 암호화
        // 1234 --> 01011011 -> 110010101101011 -> x65xAEx11
        string GetMd5Hash(MD5 md5Hash, string input)
        {
            // 입력문자열을 byte배열로 변환한 뒤 MD5 해시 처리
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder(); // 문자열을 좀 더 쉽게 쓰게 만들어주는 클래스
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2")); // 16진수 문자로 각 글자를 전부 변환
            }

            return builder.ToString();
        }
    }
}
