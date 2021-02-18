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
            lightManager.Connect(false, new List<string>());
            lightManager.Connect(false, new List<string>() { "cpu", "Hd" });
            lightManager.Connect(true, new List<string>());
            lightManager.Connect(true, new List<string>() { "cpu", "Hd" });

            lightManager.DicConnect(false);
            lightManager.DicConnect(true);
            lightManager.DicConnect(true);
        }
    }


}
