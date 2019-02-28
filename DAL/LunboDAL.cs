using IDAL;
using YueYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class LunboDAL : BaseDAL<Lunbo>, ILunboDAL
    {
        public IQueryable<Lunbo> GetTop3()
        {
            var lunbotu = dbContext.Set<Lunbo>().OrderByDescending(u => u.PublishTime).Skip(0).Take(3);
            return lunbotu;
        }
    }
}
