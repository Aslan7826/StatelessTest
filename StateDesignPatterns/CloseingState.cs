using System;
using System.Collections.Generic;
using System.Text;

namespace StateDesignPatterns
{
    public class CloseingState : LiftState
    {
        public override void Close()
        {
            Console.WriteLine("電梯關門~!");
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
            base.context.SetLiftState(Context.StoppingState);
            base.context.GetLiftState().Stop();
        }
    }
}
