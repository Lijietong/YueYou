using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YueYou.Model;
using YueYou.UI.Models;
using BLL;
using IBLL;

namespace YueYou.UI.Controllers
{
    public class HomeController : Controller
    {
        private ILunboBLL ilunbobll = BLLContainer.Container.Resolve<ILunboBLL>();
        private IGuideBLL iguidebll = BLLContainer.Container.Resolve<IGuideBLL>();
        private ICommentBLL icommentbll = BLLContainer.Container.Resolve<ICommentBLL>();
        public ActionResult Index()
        {
            var lunbo = ilunbobll.GetTop3();
            var guide = iguidebll.GetTop12();
            var comment = icommentbll.GetTop6();
            HomeViewModel homevm = new HomeViewModel();
            homevm.lunbo = lunbo;
            homevm.guide = guide;
            homevm.comment = comment;
            return View(homevm);
        }
        //定制旅行
        public ActionResult MakeTravel()
        {
            return View();
        }
    }
}