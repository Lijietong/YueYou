using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YueYou.Model;

namespace YueYou.UI.Models
{
    public class GuideViewModel
    {
        public view_guide viewguide1 { get; set; }
        public IEnumerable<view_guide> viewguide { get; set; }
        public IEnumerable<view_area> viewarea { get; set; }
    }
}