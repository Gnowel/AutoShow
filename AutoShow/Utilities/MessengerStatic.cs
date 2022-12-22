using AutoShow.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoShow.Utilities
{
    public static class MessengerStatic
    {
        public static event Action<EmployeeModel> Bus;
        public static object CurrentElement;
        public static void Send(EmployeeModel data) => Bus?.Invoke(data);
    }
}
