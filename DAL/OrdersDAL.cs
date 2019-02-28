using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using YueYou.Model;

namespace DAL
{
    public partial class OrdersDAL : BaseDAL<Orders>, IOrdersDAL
    {
        public int GuideCommentOrder(int userid,int guideid)
        {
            var count = dbContext.Set<Orders>().Where(u => u.Guide_id == guideid && u.User_id == userid).Count();
            return count;
        }
    }
}
