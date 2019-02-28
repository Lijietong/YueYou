using IBLL;
using IDAL;
using YueYou.Model;
using DALContainer;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class UserInfoBLL:BaseBLL<UserInfo>,IUserInfoBLL
    {
        private IUserInfoDAL UserDAL = Container.Resolve<IUserInfoDAL>();
        public override void SetDal()
        {
            Dal = UserDAL;
        }
        public UserInfo Denglu(string name,string pwd)
        {
            var userinfo = UserDAL.Denglu(name, pwd);
            return userinfo;
        }
        public int Denglu1(UserInfo userinfo)
        {
            var b = UserDAL.Denglu1(userinfo);
            return b;
        }
        public UserInfo GetUserByUserId(int User_id)
        {
            var userinfo = UserDAL.GetUserByUserId(User_id);
            return userinfo;
        }
        public IEnumerable<view_comment> GetCommentByUserId(int User_id)
        {
            var viewcomment = UserDAL.GetCommentByUserId(User_id);
            return viewcomment;
        }
        public IEnumerable<view_collection> GetCollectionByUserId(int User_id)
        {
            var viewcollection = UserDAL.GetCollectionByUserId(User_id);
            return viewcollection;
        }
        public IEnumerable<view_order> GetOrderByUserId(int User_id)
        {
            var vieworder = UserDAL.GetOrderByUserId(User_id);
            return vieworder;
        }
    }
}
