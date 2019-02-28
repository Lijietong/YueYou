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
    public partial class GuideBLL:BaseBLL<Guide>,IGuideBLL
    {
        private IGuideDAL GuideDAL = Container.Resolve<IGuideDAL>();
        public override void SetDal()
        {
            Dal = GuideDAL;
        }
        public IQueryable<Guide> GetTop12()
        {
            var guide = GuideDAL.GetTop12();
            return guide;
        }
        public IEnumerable<view_area> GetCategoryofGuideArea()
        {
            var type = GuideDAL.GetCategoryofGuideArea();
            return type;
        }
        public IEnumerable<view_guide> GetGuideInfo()
        {
            var guideinfo = GuideDAL.GetGuideInfo();
            return guideinfo;
        }
        public IQueryable<view_guide> GetGuideInfoByArea(string area)
        {
            var guideinfo1 = GuideDAL.GetGuideInfobyArea(area);
            return guideinfo1;
        }
        public IEnumerable<Guide>SearchGuideByArea(string area)
        {
            var gd = GuideDAL.SearchGuideByArea(area);
            return gd;
        }
    }
}
