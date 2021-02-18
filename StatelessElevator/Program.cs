using System;

namespace StatelessElevator
{
    /// <summary>
    /// 使用Statetless套件實作電梯
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context(State.Close);
            context.Open();
            context.Close();
            context.Run();
            context.Stop();
        }
    }
}
