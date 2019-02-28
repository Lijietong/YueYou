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
    public partial class CollectionBLL:BaseBLL<Collection>,ICollectionBLL
    {
        private ICollectionDAL CollectionDAL = Container.Resolve<ICollectionDAL>();


        public override void SetDal()
        {
            Dal = CollectionDAL;
        }
        public int GetCount(int userid,int guideid)
        {
            var count = CollectionDAL.GetCount(userid, guideid);
            return count;
        }
    }
}
