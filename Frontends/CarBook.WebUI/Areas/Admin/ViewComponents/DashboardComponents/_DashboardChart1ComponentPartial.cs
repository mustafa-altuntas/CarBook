﻿using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _DashboardChart1ComponentPartial: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}