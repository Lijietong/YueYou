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
    public partial class Routing_arrangementBLL:BaseBLL<Routing_arrangement>,IRouting_arrangementBLL
    {
        private IRouting_arrangementDAL Routing_arrangementDAL = Container.Resolve<IRouting_arrangementDAL>();
        public override void SetDal()
        {
            Dal = Routing_arrangementDAL;
        }
    }
}
