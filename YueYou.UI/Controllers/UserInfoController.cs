using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YueYou.Model;
using IBLL;
using YueYou.UI.Models;
using System.Data.SqlClient;

namespace YueYou.UI.Controllers
{
    public class UserInfoController : Controller
    {
        YueYouEntities db = new YueYouEntities();
        private ICommentBLL icommentbll = BLLContainer.Container.Resolve<ICommentBLL>();
        private IReplyBLL ireplybll = BLLContainer.Container.Resolve<IReplyBLL>();
        private IUserInfoBLL iuserbll = BLLContainer.Container.Resolve<IUserInfoBLL>();
        private IGuideBLL iguidebll = BLLContainer.Container.Resolve<IGuideBLL>();
        UserCenterViewModel ucvm = new UserCenterViewModel();
        //UserBLL userbll = new UserBLL();
        public ActionResult Index(int User_id)
        {
            Session["User_id"]=User_id;
            ucvm.user = db.UserInfo.Find(User_id);
            ucvm.userinfo = iuserbll.GetUserByUserId(User_id);
            ucvm.viewcomment = iuserbll.GetCommentByUserId(User_id);
            ucvm.viewcollection = iuserbll.GetCollectionByUserId(User_id);
            ucvm.vieworder = iuserbll.GetOrderByUserId(User_id);
            return View(ucvm);
        }

        // GET: User
        public ActionResult Login()
        {
            return View();
        }


        //登录账号
        [HttpPost]
        public string Login([Bind(Include ="User_name,User_pwd")] string User_name,string User_pwd)
        {
            try
            {
                var users = iuserbll.Denglu(User_name, User_pwd);
                if (users != null)
                {
                    //保存到Session HttpContext.
                    //Session["User_name"] = User_name;
                    //Session["User_image"] = iuserbll.GetUserByUserName(User_name).User_image;
                    Session["User_name"] = users.User_name;
                    Session["User_id"] = users.User_id;
                    Session["User_image"] = users.User_image;
                    string data = "登录成功";
                    return data;
                }
                else
                {
                    string data = "登录失败";
                    return data;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                string data = "错误";
                return data;
            }
            
        }

        //注销账号
        public ActionResult LoginOut()
        {
            Session["UserName"] = null;
            Session["User_image"] = null;
            Session["User_id"] = null;
            return Content("<script>alert('注销成功！');window.open('" + Url.Content("~/Home/Index") + "','_self');</script>");
        }

        //注册用户 GET
        public ActionResult Register()
        {
            return View();
        }

        //注册用户 POST
        [HttpPost]
        public ActionResult Register( UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                iuserbll.Add(userinfo);
                return Content("<script>alert('用户注册成功！');window.open('" + Url.Content("~/Home/Index") + "', '_self')</script>");
            }
            else
            {
                return Content("<script>;alert('注册失败！');window.open('" + Url.Content("~/User/Register") + "', '_self')</script>");
            }

        }
        //编辑个人资料
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInfo(UserInfo user)
        {
            UserInfo u = db.UserInfo.Find(Session["User_id"]);
            HttpPostedFileBase userImage = Request.Files["User_image"];
            if (userImage.FileName != "")
            {
                string filePath = userImage.FileName;
                    /*string filename = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") +
                                      filePath.Substring(filePath.LastIndexOf("\\") + 1);*/
                string serverpath = Server.MapPath(@"\images\userphoto\") + filePath;
                string relativepath = @"/images/userphoto/" + filePath;
                userImage.SaveAs(serverpath);
                user.User_image = relativepath;
            }
            else
            {
                user.User_image = db.UserInfo.Find(Session["User_id"]).User_image;
            }
            if (ModelState.IsValid)
            {
                u.User_name = user.User_name;
                u.User_image = user.User_image;
                u.User_phone = user.User_phone;
                u.User_mail = user.User_mail;
                u.User_sex = user.User_sex;
                u.Sign = user.Sign;
                iuserbll.Update(u);
                //return RedirectToAction("Index", "UserInfo", new { User_id = userinfo.User_id });
                return Content("<script>;alert('修改成功！');window.open('" + Url.Action("Index", "UserInfo", new { User_id = Session["User_id"] }) + "', '_self')</script>");
            }
            else
            {                    
                return Content("<script>;alert('修改失败！');window.history.go(-1);window.location.reload();</script>");
            }
        }
        public ActionResult DeleteComments(int commentid)
        {
            //int userid = Convert.ToInt32(Session["User_id"]);
            //int count = ireplybll.GetCountofReply(commentid);
            //Comment comment = icommentbll.DeleteByCommentId(commentid);           
            //if (count>0)
            //{
            //    var result = db.Comment.SqlQuery("exec proc_delete_reply_comment @commentid", commentid);
            //    return Content(" <script>;alert('删除成功！'); window.open('" + Url.Action("Index", "UserInfo", new { User_id = userid }) + "', '_self') </ script > ");
            //}
            //else
            //{
            //    icommentbll.Delete(comment);
            //    return Content("<script>;alert('删除成功！');window.open('" + Url.Action("Index", "UserInfo", new { User_id = userid }) + "', '_self')</script>");
            //}
            int a = icommentbll.GetCount();
            int userid = Convert.ToInt32(Session["User_id"]);
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@commentid", commentid);
            db.Database.ExecuteSqlCommand("exec proc_delete_reply_comment @commentid", param);
            int b = icommentbll.GetCount();
            return Content("<script>alert('删除成功！！');window.open('" + Url.Action("Index", "UserInfo", new { User_id=userid }) + "','_self')</script>");
        }
    }
}