using YueYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public partial interface IGuideBLL:IBaseBLL<Guide>
    {
        IQueryable<Guide> GetTop12();
        IEnumerable<view_area> GetCategoryofGuideArea();
        IEnumerable<view_guide> GetGuideInfo();
        IQueryable<view_guide> GetGuideInfoByArea(string area);
        IEnumerable<Guide> SearchGuideByArea(string area);
    }
}
