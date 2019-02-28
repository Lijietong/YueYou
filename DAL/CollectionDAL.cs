using IDAL;
using YueYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class CollectionDAL : BaseDAL<Collection>, ICollectionDAL
    {
        YueYouEntities db = new YueYouEntities();
        public int GetCount(int userid,int guideid)
        {
            var num = db.Collection.Where(u => u.User_id == userid && u.Guide_id == guideid).Count();
            return num;
        }
    }
}
