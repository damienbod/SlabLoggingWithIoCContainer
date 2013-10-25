using System;
using System.Collections.Generic;
using Damienbod.Slab.Loggers;
using Microsoft.Build.Framework;

namespace Damienbod.Slab
{
    public class WebLogger : ISlabLogger
    {
        public WebLogger()
        {
            RegisterLog();
        }

        private readonly Dictionary<int, Action<string>> _exectueLogDict = new Dictionary<int, Action<string>>();

        private void RegisterLog()
        {
            GlobalLogger.RegisterLogger(_exectueLogDict);
            ControllerLogger.RegisterLogger(_exectueLogDict);
        }


        public void Log(int log, string message)
        {
            if (_exectueLogDict.ContainsKey(log))
            {
                _exectueLogDict[log].Invoke(message);
                return;
            }
            
            //GlobalLogger.Logger.Warning("log Id does not exist: " + log);
        }
    }
}
