using IDAL;
using YueYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class GuideDAL : BaseDAL<Guide>, IGuideDAL
    {
        YueYouEntities db = new YueYouEntities();
        public IQueryable<Guide>GetTop12()
        {
            var guide = dbContext.Set<Guide>().Include("GuideDetails").OrderByDescending(u => u.Guide_id).Skip(0).Take(12);
            return guide;
        }
        public IEnumerable<view_area> GetCategoryofGuideArea()
        {
            var type = db.view_area;
            return type;
        }
        public IEnumerable<view_guide> GetGuideInfo()
        {
            var guideinfo = db.view_guide;
            return guideinfo;
        }
        public IQueryable<view_guide> GetGuideInfobyArea(string area)
        {
            var guideinfo1 = db.view_guide.Where(u => u.Guide_area == area);
            return guideinfo1;
        }
        public IEnumerable<Guide> SearchGuideByArea(string area)
        {
            var gd = from s in db.Guide
                     where s.Guide_area.Contains(area)
                     select s;
            return gd;
        }
    }
}
