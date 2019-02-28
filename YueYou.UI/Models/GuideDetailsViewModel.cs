using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YueYou.Model;

namespace YueYou.UI.Models
{
    public class GuideDetailsViewModel
    {
        public IEnumerable<UserInfo> userinfo { get; set; }
        public IEnumerable<Comment> comment { get; set; }
        public IEnumerable<Reply> reply { get; set; }
        public IEnumerable<Guide> guide { get; set; }
        public IEnumerable<GuideDetails> guidedetails { get; set; }
        public Guide guidedetails1 { get; set; }
        public IEnumerable<view_comment> viewcomment { get; set; }
    }

}