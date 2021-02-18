using System;
using System.Collections.Generic;
using System.Text;

namespace StateDesignPatterns
{
    public class RunningState : LiftState
    {
        public override void Close()
        {
            base.context.SetLiftState(Context.CloseingState);
            base.context.GetLiftState().Close();
        }

        public override void Open()
        {
            
        }

        public override void Run()
        {
            Console.WriteLine("上或下");
        }

        public override void Stop()
        {
            base.context.SetLiftState(Context.StoppingState);
            base.context.GetLiftState().Stop();
        }
    }
}
