using Stateless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatelessTest
{
    public class LightManager
    {
        StateMachine<Light, Trigger> _machine;
        //由外部傳入參數觸發
        //傳入參數有兩個
        StateMachine<Light, Trigger>.TriggerWithParameters<bool, List<string>> _IsTimeOut;
        //傳入參數為1個
        StateMachine<Light, Trigger>.TriggerWithParameters<bool> _IsTimeOutDic;
        Light _light = Light.Gray;

        public LightManager()
        {
            _machine = new StateMachine<Light, Trigger>(() => _light, s => _light = s);
            _IsTimeOut = _machine.SetTriggerParameters<bool, List<string>>(Trigger.Connect);
            _IsTimeOutDic = _machine.SetTriggerParameters<bool>(Trigger.DisConnect);
            _machine.Configure(Light.Gray)
                .PermitIf(_IsTimeOut, Light.Green, (t, e) => t && e.Count == 0)
                .PermitIf(_IsTimeOut, Light.GreenTimeOut, (t, e) => !t && e.Count == 0)
                .PermitIf(_IsTimeOut, Light.Yellow, (t, e) => t && e.Count > 0)
                .PermitIf(_IsTimeOut, Light.YellowTimeOut, (t, e) => !t && e.Count > 0)
                .PermitIf(_IsTimeOutDic, Light.Red, o => o)
                .PermitIf(_IsTimeOutDic, Light.RedTimeOut, o => !o)
                ;
            _machine.Configure(Light.Green)
                .PermitIf(_IsTimeOut, Light.GreenTimeOut, (t, e) => !t && e.Count == 0)
                .PermitIf(_IsTimeOut, Light.Yellow, (t, e) => t && e.Count > 0)
                .PermitIf(_IsTimeOut, Light.YellowTimeOut, (t, e) => !t && e.Count > 0)
                .PermitIf(_IsTimeOutDic, Light.Red, o => o)
                .PermitIf(_IsTimeOutDic, Light.RedTimeOut, o => !o)
                ;
            _machine.Configure(Light.GreenTimeOut)
                .PermitIf(_IsTimeOut, Light.Green, (t, e) => t && e.Count == 0)
                .PermitIf(_IsTimeOut, Light.Yellow, (t, e) => t && e.Count > 0)
                .PermitIf(_IsTimeOut, Light.YellowTimeOut, (t, e) => !t && e.Count > 0)
                .PermitIf(_IsTimeOutDic, Light.Red, o => o)
                .PermitIf(_IsTimeOutDic, Light.RedTimeOut, o => !o)
                ;
            _machine.Configure(Light.Yellow)
                .PermitIf(_IsTimeOut, Light.Green, (t, e) => t && e.Count == 0)
                .PermitIf(_IsTimeOut, Light.GreenTimeOut, (t, e) => !t && e.Count == 0)
                .PermitIf(_IsTimeOut, Light.YellowTimeOut, (t, e) => !t && e.Count > 0)
                .PermitIf(_IsTimeOutDic, Light.Red, o => o)
                .PermitIf(_IsTimeOutDic, Light.RedTimeOut, o => !o)
                ;
            _machine.Configure(Light.YellowTimeOut)
                .PermitIf(_IsTimeOut, Light.Green, (t, e) => t && e.Count == 0)
                .PermitIf(_IsTimeOut, Light.GreenTimeOut, (t, e) => !t && e.Count == 0)
                .PermitIf(_IsTimeOut, Light.Yellow, (t, e) => t && e.Count > 0)
                .PermitIf(_IsTimeOutDic, Light.Red, o => o)
                .PermitIf(_IsTimeOutDic, Light.RedTimeOut, o => !o)
                ;
            _machine.Configure(Light.Red)
                .PermitIf(_IsTimeOut, Light.Green, (t, e) => t && e.Count == 0)
                .PermitIf(_IsTimeOut, Light.GreenTimeOut, (t, e) => !t && e.Count == 0)
                .PermitIf(_IsTimeOut, Light.Yellow, (t, e) => t && e.Count > 0)
                .PermitIf(_IsTimeOut, Light.YellowTimeOut, (t, e) => !t && e.Count > 0)
                .PermitIf(_IsTimeOutDic, Light.RedTimeOut, o => !o)
                .OnEntry(o=>Console.WriteLine(123))
                ;
            _machine.Configure(Light.RedTimeOut)
                .PermitIf(_IsTimeOut, Light.Green, (t, e) => t && e.Count == 0)
                .PermitIf(_IsTimeOut, Light.GreenTimeOut, (t, e) => !t && e.Count == 0)
                .PermitIf(_IsTimeOut, Light.Yellow, (t, e) => t && e.Count > 0)
                .PermitIf(_IsTimeOut, Light.YellowTimeOut, (t, e) => !t && e.Count > 0)
                .PermitIf(_IsTimeOutDic, Light.Red, o => o)
                ;

            //忽略沒設定到的轉換錯誤
            _machine.OnUnhandledTrigger((light, trigger) => { });
        }
        public void Connect(bool timeOut,List<string> scanModel )
        {
            _machine.Fire(_IsTimeOut, timeOut, scanModel);
            Console.WriteLine(_light);
            Console.WriteLine("----------------------------");
        }
        public void DicConnect(bool timeOut)
        {
            _machine.Fire(_IsTimeOutDic, timeOut);
            Console.WriteLine(_light);
            Console.WriteLine("----------------------------");
        }
    }
}
