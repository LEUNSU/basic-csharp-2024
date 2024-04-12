using System.ComponentModel;

namespace ex11_events
{
    delegate int MyDelegate(int a, int b);
    delegate void EventHandler(string message); // 이벤트핸들러 대리자(어떠한 메서드를 대신 호출)

    class CustomNotifier // 미리 만들어져 있다
    {
        // 이벤트 등록, event라는 키워드쓰면 기본적으로 EventHandler 이름을 일반적으로 사용
        public event EventHandler SomethingHappened;

        public void DoSomething(int number)
        {
            int temp = number % 10;

            if (temp != 0 && temp % 3 == 0)
            {
                // 3, 6, 9 등의 상태가 되면 짝! 하는 이벤트를 발생시키겠다
                SomethingHappened($"{number} : 짝!"); // SomethingHappened가 처리할 로직이 포함되어 있지않음
                // 이벤트핸들러 발생, 자신의 메서드가 아닌 외부에서 만들어진 메서드를 대신 실행
            }
        }
    } // 우리가 구현하는 게 아니라, 원래부터 만들어져 있는 것
    internal class Program
    {
        public static void MyHandler(string message)
        {
            //Console.WriteLine($"다른 일을 처리합니다.");
            //Console.ReadLine();
            //Console.Clear();
            Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] : {message}");
        }
    
        static void Main(string[] args)
        {
            CustomNotifier notifier = new CustomNotifier();
            notifier.SomethingHappened += new EventHandler(MyHandler);

            for (int i = 0; i < 30; i = i + 2)
            {
                notifier.DoSomething(i); // 내장된 클래스의 어떠한 메서드 호출
            }
            //notifier.SomethingHappened(30); //이벤트 핸들러는 함수가 아니기 때문에 호출 불가

            #region "익명 메서드"
            MyDelegate callback; // 대리자
            // 메서드 이름이 존재 X
            // 익명 메서드. 한 번 사용이후 다시 호출할 필요가 없을 때 사용
            callback = delegate (int a, int b)
            {
                return a + b;
            };
            var result = callback(10, 4);
            #endregion
        }
    }
}
