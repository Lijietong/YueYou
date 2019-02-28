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
    public partial class OrderDetailsBLL:BaseBLL<OrderDetails>,IOrderDetailsBLL
    {
        private IOrderDetailsDAL OrderDetailsDAL = Container.Resolve<IOrderDetailsDAL>();
        public override void SetDal()
        {
            Dal = OrderDetailsDAL;
        }
    }
}
