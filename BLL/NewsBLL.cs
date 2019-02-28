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
    public partial class NewsBLL:BaseBLL<News>,INewsBLL
    {
        private INewsDAL NewsDAL = Container.Resolve<INewsDAL>();
        public override void SetDal()
        {
            Dal = NewsDAL;
        }
    }
}
