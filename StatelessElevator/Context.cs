using Stateless;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatelessElevator
{
    public class Context
    {
        StateMachine<State, Trigger> _machine;
        public Context(State state = State.Close) 
        {
            _machine = new StateMachine<State, Trigger>(() => state, s => state = s);

            _machine.Configure(State.Close)
                .Permit(Trigger.Opening, State.Open)
                .Permit(Trigger.Running, State.Run)
                .Permit(Trigger.Stopping, State.Stop)
                .OnEntry(o => Console.WriteLine("電梯關門~!"));
            _machine.Configure(State.Open)
                .Permit(Trigger.Closeing, State.Close)
                .OnEntry(o => Console.WriteLine("電梯開門~!"));
            _machine.Configure(State.Run)
                .Permit(Trigger.Closeing, State.Close)
                .Permit(Trigger.Stopping, State.Stop)
                .OnEntry(o => Console.WriteLine("上或下"));
            _machine.Configure(State.Stop)
                .Permit(Trigger.Opening, State.Open)
                .Permit(Trigger.Running, State.Run)
                .OnEntry(o => Console.WriteLine("電梯關門~!"));
        }

        /// <summary>
        /// 開門
        /// </summary>
        public void Open()
        {
            _machine.Fire(Trigger.Opening);
        }
        /// <summary>
        /// 關閉
        /// </summary>
        public void Close()
        {
            _machine.Fire(Trigger.Closeing);
        }
        /// <summary>
        /// 電梯上下
        /// </summary>
        public void Run()
        {
            _machine.Fire(Trigger.Running);
        }
        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            _machine.Fire(Trigger.Stopping);
        }

    }
}
