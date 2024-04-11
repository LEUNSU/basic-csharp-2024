namespace ex03_loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            
            foreach (var item in arr) 
            { 
                Console.WriteLine($"현재 수 : {item}");
            }
        }
    }
}
