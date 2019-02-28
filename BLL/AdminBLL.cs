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
    public partial class AdminBLL:BaseBLL<Admin>,IAdminBLL
    {
        private IAdminDAL AdminDAL = Container.Resolve<IAdminDAL>();
        public override void SetDal()
        {
            Dal = AdminDAL;
        }
    }
}
