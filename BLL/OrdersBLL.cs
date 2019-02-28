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
    public partial class OrdersBLL:BaseBLL<Orders>,IOrdersBLL
    {
        private IOrdersDAL OrdersDAL = Container.Resolve<IOrdersDAL>();
        public override void SetDal()
        {
            Dal = OrdersDAL;
        }
        public int GuideCommentOrder(int userid,int guideid)
        {
            var date = OrdersDAL.GuideCommentOrder(userid, guideid);
            return date;
        }
    }
}
