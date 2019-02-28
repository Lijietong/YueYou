using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YueYou.Model;

namespace YueYou.UI.Models
{
    public class UserCenterViewModel
    {
        public UserInfo userinfo { get; set; }
        public UserInfo user { get; set; }  //用来修改资料
        public IEnumerable<view_comment> viewcomment { get; set; }
        public IEnumerable<view_order> vieworder { get; set; }
        public IEnumerable<view_collection> viewcollection { get; set; }
    }
}