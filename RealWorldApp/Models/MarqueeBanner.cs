using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldApp.Models
{
    public class MarqueeBanner
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string BannerContent { get; set; }
        public string Image { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsEnable { get; set; }
        public int Seq { get; set; }
        public string FullImageUrl => AppSettings.ApiUrl + Image;
    }

}
