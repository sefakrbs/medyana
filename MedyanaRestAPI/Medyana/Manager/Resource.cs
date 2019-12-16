using Resource;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Web;

namespace Medyana.Manager
{
    public class Resource
    {
        public string GetResource(string key)
        {
            return Global.ResourceManager.GetString(key);
        }

        //public string GetExceptionResource(string key)
        //{
        //    return Global.ResourceManager.GetString("Exception." + key);
        //}
    }
}