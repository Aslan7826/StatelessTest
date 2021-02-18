using System;
using System.Collections.Generic;
using System.Text;

namespace StateDesignPatterns
{
    public class OpeningState : LiftState
    {
        public override void Close()
        {
            base.context.SetLiftState(Context.CloseingState);
            base.context.GetLiftState().Close();
        }

        public override void Open()
        {
            Console.WriteLine("電梯開門~!");
        }

        public override void Run()
        {
            
        }

        public override void Stop()
        {
            
        }
    }
}
                                                                                            