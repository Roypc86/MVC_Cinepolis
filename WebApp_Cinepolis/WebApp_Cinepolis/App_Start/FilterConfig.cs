﻿using System.Web;
using System.Web.Mvc;

namespace WebApp_Cinepolis
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
