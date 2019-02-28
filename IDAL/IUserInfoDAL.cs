using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YueYou.Model;

namespace IDAL
{
    public partial interface IUserInfoDAL : IBaseDAL<UserInfo>
    {
        UserInfo Denglu(string name,string pwd);
        int Denglu1(UserInfo userinfo);
        UserInfo GetUserByUserId(int User_id);
        IEnumerable<view_comment> GetCommentByUserId(int User_id);
        IEnumerable<view_collection> GetCollectionByUserId(int User_id);
        IEnumerable<view_order> GetOrderByUserId(int User_id);
    }
}
