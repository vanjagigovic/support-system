﻿using System.Web;
using System.Web.Mvc;

namespace SUPORT_SYSTEM
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
