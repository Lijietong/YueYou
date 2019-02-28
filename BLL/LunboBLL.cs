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
    public partial class LunboBLL:BaseBLL<Lunbo>,ILunboBLL
    {
        private ILunboDAL LunboDAL = Container.Resolve<ILunboDAL>();
        public override void SetDal()
        {
            Dal = LunboDAL;
        }
        public IQueryable<Lunbo> GetTop3()
        {
            var lunbotu = LunboDAL.GetTop3();
            return lunbotu;
        }
    }
}
