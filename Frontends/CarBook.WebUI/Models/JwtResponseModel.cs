﻿using NuGet.Common;

namespace CarBook.WebUI.Models
{
    public class JwtResponseModel
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}