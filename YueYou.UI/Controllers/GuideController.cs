using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using YueYou.Model;
using YueYou.UI.Models;
using PagedList;

namespace YueYou.UI.Controllers
{
    public class GuideController : Controller
    {
        private ICollectionBLL icollectionbll = BLLContainer.Container.Resolve<ICollectionBLL>();
        private IGuideBLL iguidebll = BLLContainer.Container.Resolve<IGuideBLL>();
        private IGuideDetailsBLL iguidedetailsbll = BLLContainer.Container.Resolve<IGuideDetailsBLL>();
        GuideViewModel svm = new GuideViewModel();
        // GET: Search
        public ActionResult Index()
        {
            var guidearea = iguidebll.GetCategoryofGuideArea().ToList();
            var guideinfo = iguidebll.GetGuideInfo();
            svm.viewarea = guidearea;
            svm.viewguide = guideinfo;
            return View(svm);
        }
        public ActionResult GuidePage(string area,string currentFilter,int?page)
        {
            var guides = iguidebll.GetGuideInfo();

            if (area != null)
            {
                page = 1;
            }
            else
            {
                area = currentFilter;
            }
            ViewBag.CurrentFilter = area;
            if (!String.IsNullOrEmpty(area))
            {
                guides = guides.Where(x => x.Guide_area == area);
            }
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            Session["Guide_area"] = area;
            return PartialView(guides.OrderBy(u=>u.Guide_id).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Search(string area)
        {
            Session["Search"] = area;
            var p = iguidebll.SearchGuideByArea(area);
            return View(svm);
        }      
        public ActionResult Collection(int guideid)
        {           
            int userid = Convert.ToInt32(Session["User_id"]);           
            if (Session["User_id"]==null)
            {
                return Content("<script>alert('请先登录！');window.open('" + Url.Action("GuideDetails", "GuideDetails", new { id = guideid }) + "','_self')</script>");
            }
            else
            {
                int count = icollectionbll.GetCount(userid, guideid);
                if (count > 0)
                {
                    return Content("<script>alert('您已经关注过了，快去个人中心的收藏板块看看吧！');window.open('" + Url.Action("GuideDetails", "GuideDetails", new { id = guideid }) + "','_self')</script>");
                }
                else
                {
                    Collection C = new Collection
                    {
                        Guide_id = guideid,
                        User_id = userid,
                        Collection_time = DateTime.Now
                    };
                    icollectionbll.Add(C);
                    return Content("<script>alert('关注成功！');window.open('" + Url.Action("GuideDetails", "GuideDetails", new { id = guideid }) + "','_self')</script>");
                }
                
            }
            
        }
    }
}