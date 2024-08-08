using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniRestaurantManagementSystem.Extensions
{
    public static class DevCode
    {
        public static string SerializeObject(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
