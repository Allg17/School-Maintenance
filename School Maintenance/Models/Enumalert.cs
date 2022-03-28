using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Maintenance.Models
{
    public class Enumalert
    {
        public enum NotificationType
        {
            error,
            success,
            warning,
            info
        }
    }
}