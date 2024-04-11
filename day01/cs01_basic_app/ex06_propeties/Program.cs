using Microsoft.VisualBasic;

namespace ex06_propeties
{
    class Kiturami
    {
        private int temperature; // 온도

        private int year; // 제작년도
        public int Year{
            get { return year; }
            set { year = value; }
        }//일반 프로퍼티

        public string Name { get; set; } // 자동 프로퍼티 GET/SET에서 특별한 로직이 없으면 생략가능

        // Rosalyn VS 개발서포터 
        public int Temperature
        {
            get 
            { 
                // 값을 리턴하니까 특별한 기능이 없음              
                return temperature; 
            }
            set
            {
                // 잘못된 값이 들어오면 안 되기 때문에 여러 제약을 걸어줌
                if(value < 10) 
                {
                    temperature = 20; // 10도 이하는 허용 안 함
                }
                else if(value > 70)
                {
                    temperature = 50; // 70도 초과는 허용 안 함               
                }
                else 
                temperature = value;
            }
        }

        // 생성자


        //public void SetTemperature(int temp)
        //{
        //    if (temp > 70)
        //    {
        //        Console.WriteLine("온도가 너무 높습니다. 50도로 조정합니다.");
        //        this.temperature = 50;
        //    }
        //    else if (temp < 10)
        //    {
        //        Console.WriteLine("온도가 너무 낮습니다. 20도로 조정합니다.");
        //        this.temperature = 20;
        //    }

        //    this.temperature = temp;
        //}

        //public int GetTemperature()
        //{
        //    return this.temperature;
        //}

        public void On()
        {
            Console.WriteLine("보일러 On");
        }

        public void Off()
        {
            Console.WriteLine("보일러 Off");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("보일러 시작!");
            //Kiturami boiler = new Kiturami();
            ////boiler.temperature = 400; // 막아버림 public은 사용하면 안 됨
            ////Console.WriteLine($"보일러 온도는 {boiler.temperature}도"); // 막아버림
            ////boiler.SetTemperature(400);
            ////Console.WriteLine($"보일러 온도는 {boiler.GetTemperature()}도");
            //boiler.Temperature = 400;
            //Console.WriteLine($"보일러 온도는 {boiler.Temperature}도");
            //boiler.On();

            //boiler.Name = "귀뚜라미";
            //Console.WriteLine($"보일러 이름은 {boiler.Name}");

            Kiturami kiturami = new Kiturami(name: "라미", temperature: 25, year: 2023);
            Console.WriteLine(kiturami.Name);   
            Console.WriteLine($"제작년도: {kiturami.Year}");
            kiturami.Temperature = 180;
            Console.WriteLine(kiturami.Name) 현재온도는 ;

        }
    }
}
