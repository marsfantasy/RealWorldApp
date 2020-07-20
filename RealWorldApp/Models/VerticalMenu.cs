using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldApp.Models
{
    public class VerticalMenu
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string FullImageUrl => AppSettings.ApiUrl + ImageUrl;
    }

}
