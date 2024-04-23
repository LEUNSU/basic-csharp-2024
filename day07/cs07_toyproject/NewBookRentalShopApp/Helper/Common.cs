using System.Security.Cryptography;
using System.Text;

namespace NewBookRentalShopApp.Helper
{
    public class Common
    {
        // 정적으로 만드는 공통 연결 문자열
        public static string ConnString = "Data Source=localhost;" +
                                          "Initial Catalog=BookRentalShop2024;" +
                                          "Persist Security Info=True;" +
                                          "User ID=sa;Encrypt=False;Password=mssql_p@ss";

        // MD5 해시 알고리즘 암호화
        // 1234 --> 01011011 -> 110010101101011 -> x65xAEx11
        public static string GetMd5Hash(MD5 md5Hash, string input)
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
