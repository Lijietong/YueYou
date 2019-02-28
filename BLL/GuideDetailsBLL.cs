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
    public partial class GuideDetailsBLL:BaseBLL<GuideDetails>,IGuideDetailsBLL
    {
        private IGuideDetailsDAL GuideDetailsDAL = Container.Resolve<IGuideDetailsDAL>();
        public override void SetDal()
        {
            Dal = GuideDetailsDAL;
        }
    }
}
