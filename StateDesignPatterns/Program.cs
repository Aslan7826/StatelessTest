using System;
using System.Collections.Generic;
using System.Text;

namespace StateDesignPatterns
{
    class Program
    {
        /// <summary>
        /// 狀態機設計模式
        /// 實作"設計之禪"內的電梯練習
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            Context context = new Context();
            context.SetLiftState(new CloseingState());
            context.Open();
            context.Close();
            context.Run();
            context.Stop();

        }
    }

}
