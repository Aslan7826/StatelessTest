using Stateless;
using System;
using System.Collections.Generic;

namespace StatelessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var lightManager = new LightManager();
            lightManager.Connect(false,Light.Green);
            lightManager.Connect(false,Light.GreenTimeOut);
            lightManager.Connect(true, Light.Yellow);
            lightManager.Connect(true, Light.YellowTimeOut);
            lightManager.Connect(true, Light.Gray);

            lightManager.DicConnect(false);
            lightManager.DicConnect(false);
            lightManager.DicConnect(true);
            lightManager.DicConnect(true);
        }
    }


}
