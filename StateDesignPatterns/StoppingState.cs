using System;
using System.Collections.Generic;
using System.Text;

namespace StateDesignPatterns
{
    public class StoppingState : LiftState
    {
        public override void Close()
        {
            
        }

        public override void Open()
        {
            base.context.SetLiftState(Context.OpeningState);
            base.context.GetLiftState().Open();
        }

        public override void Run()
        {
            base.context.SetLiftState(Context.RunningState);
            base.context.GetLiftState().Run();
        }

        public override void Stop()
        {
            Console.WriteLine("電梯停止");
        }
    }
}
