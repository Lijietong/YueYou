using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using YueYou.Model;
using YueYou.UI.Models;

namespace YueYou.UI.Controllers
{
    public class GuideDetailsController : Controller
    {
        private readonly IUserInfoBLL iuserbll = BLLContainer.Container.Resolve<IUserInfoBLL>();
        private IGuideBLL iguidebll = BLLContainer.Container.Resolve<IGuideBLL>();
        private IGuideDetailsBLL iguidedetailsbll = BLLContainer.Container.Resolve<IGuideDetailsBLL>();
        private IReplyBLL ireplybll = BLLContainer.Container.Resolve<IReplyBLL>();
        private ICommentBLL icommentbll = BLLContainer.Container.Resolve<ICommentBLL>();
        private IOrdersBLL iorderbll = BLLContainer.Container.Resolve<IOrdersBLL>();
        // GET: GuideDetails

        public ActionResult GuideDetails(int id)
        {
            Session["Guide_id"] = id;           
            //var user = iuserbll.GetAll();
            var guide = iguidebll.GetAll();
            var comment = icommentbll.GetAll();
            var reply = ireplybll.GetAll();
            var guidedetails = iguidedetailsbll.GetAll();
            var guidedetails1 = iguidebll.GetById(id);
            var viewcomment = icommentbll.GetCommentsByGuideId(id);
            GuideDetailsViewModel guidedetailsvm = new GuideDetailsViewModel
            {
                //guidedetailsvm.user = user;
                guide = guide,
                comment = comment,
                reply = reply,
                guidedetails = guidedetails,
                guidedetails1 = guidedetails1,
                viewcomment = viewcomment
            };
            return View(guidedetailsvm);
        }
        public ActionResult Comments()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Comments(Comment comment)
        {
            int guideid = Convert.ToInt32(Session["Guide_id"]);
            int userid = Convert.ToInt32(Session["User_id"]);
            string textarea = Request["pingluntextarea"];
            var result = iorderbll.GuideCommentOrder(userid, guideid);
            if (ModelState.IsValid)
            {
                if (result > 0)
                {
                    if (textarea != "")
                    {
                        comment.User_id = userid;
                        comment.Guide_id = guideid;
                        comment.Comment_time = System.DateTime.Now;
                        comment.Comment_contents = textarea;
                        icommentbll.Add(comment);
                        return Content("<script>alert('评论成功');window.open('"+Url.Action("GuideDetails","GuideDetails",new { id=guideid})+"','_self')</script>");
                    }
                    else
                    {
                        return Content("<script>alert('评论不能为空！');history.go(-1)</script>");
                    }
                }
                else
                {
                    return Content("<script>alert('您未预约过该向导，不能评论！');history.go(-1)</script>");
                }
            }
            return Content("<script>alert('评论成功！');window.open('" + Url.Action("GuideDetails", "GuideDetails", new { id = guideid }) + "', '_self')</script>");
        }
        public ActionResult ReplyComments()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReplyComments(int commentid,Reply reply)
        {
            string replytext = Request.Form["textarea1"];
            if (replytext == "")
            {
                return Content("<script>;alert('回复不能为空');history.go(-1)</script>");
            }
            else
            {
                int guideid = Convert.ToInt32(Session["Guide_id"]);
                int userid = Convert.ToInt32(Session["User_id"]);
                reply.Guide_id = guideid;
                reply.Comment_id = commentid;
                reply.User_id = userid;
                reply.Reply_contents = replytext;
                reply.Reply_time = DateTime.Now;
                ireplybll.Add(reply);
                return Content("<script>alert('回复成功');window.open('" + Url.Action("GuideDetails", "GuideDetails", new { id = guideid }) + "', '_self')</script>");
            }
        }
    }   
}