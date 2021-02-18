using System;
using System.Collections.Generic;
using System.Text;

namespace StateDesignPatterns
{
    /// <summary>
    /// 使用抽象類別 讓繼承的資料建立專屬自己的動作
    /// </summary>
    public abstract class LiftState
    {
        protected Context context { get; set; }

        public void SetContext(Context context) 
        {
            this.context = context;
        }
        public abstract void Open();
        public abstract void Close();
        public abstract void Run();
        public abstract void Stop();
    }
}
