using System;
using System.Collections.Generic;
using System.Text;

namespace StateDesignPatterns
{
    /// <summary>
    /// 統一入口用
    /// </summary>
    public class Context
    {
        public static CloseingState CloseingState = new CloseingState();
        public static StoppingState StoppingState = new StoppingState();
        public static OpeningState OpeningState = new OpeningState();
        public static RunningState RunningState = new RunningState();
        private LiftState liftState;
        public LiftState GetLiftState() 
        {
            return liftState;
        }
        /// <summary>
        /// 設定初始化資料
        /// </summary>
        /// <param name="liftState"></param>
        public void SetLiftState(LiftState liftState) 
        {
            this.liftState = liftState;
            this.liftState.SetContext(this);
        }
        /// <summary>
        /// 開門
        /// </summary>
        public void Open() 
        {
            this.liftState.Open();
        }
        /// <summary>
        /// 關閉
        /// </summary>
        public void Close() 
        {
            this.liftState.Close();
        }
        /// <summary>
        /// 電梯上下
        /// </summary>
        public void Run() 
        {
            this.liftState.Run();
        }
        /// <summary>
        /// 停止
        /// </summary>
        public void Stop() 
        {
            this.liftState.Stop();
        }
    }
}
