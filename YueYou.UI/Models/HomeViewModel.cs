using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YueYou.Model;

namespace YueYou.UI.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Guide> guide { get; set; }
        public IEnumerable<Lunbo> lunbo { get; set; }
        public IEnumerable<Comment> comment { get; set; }

    }
}