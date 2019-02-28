using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YueYou.Model;

namespace IDAL
{
    public partial interface IGuideDAL:IBaseDAL<Guide>
    {
        IQueryable<Guide> GetTop12();
        IEnumerable<view_area> GetCategoryofGuideArea();
        IEnumerable<view_guide> GetGuideInfo();
        IQueryable<view_guide> GetGuideInfobyArea(string area);
        IEnumerable<Guide> SearchGuideByArea(string area);
    }
}
