using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using YueYou.Model;

namespace DAL
{
    public partial class UserInfoDAL:BaseDAL<UserInfo>,IUserInfoDAL
    {
        YueYouEntities db = new YueYouEntities();

        public UserInfo Denglu(string name,string pwd)
        {
            var userinfo = db.UserInfo.Where(x => x.User_name == name).Where( x=>x.User_pwd == pwd).FirstOrDefault();
            return userinfo;
        }
        public int Denglu1(UserInfo userinfo)
        {
            var a = db.UserInfo.Where(x => x.User_name == userinfo.User_name && x.User_pwd == userinfo.User_pwd);
            int result = a.Count();
            return result;
        }
        public UserInfo GetUserByUserId(int User_id)
        {
            var userinfo = db.UserInfo.Where(u => u.User_id == User_id).FirstOrDefault();
            return userinfo;
        }
        public IEnumerable<view_comment> GetCommentByUserId(int User_id)
        {
            var viewcomment = db.view_comment.Where(u => u.User_id == User_id);
            return viewcomment;
        }
        public IEnumerable<view_collection>GetCollectionByUserId(int User_id)
        {
            var viewcollection = db.view_collection.Where(u => u.User_id == User_id);
            return viewcollection;
        }
        public IEnumerable<view_order>GetOrderByUserId(int User_id)
        {
            var vieworder = db.view_order.Where(u => u.User_id == User_id);
            return vieworder;
        }
    }
}
