using YueYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public partial interface ILunboBLL:IBaseBLL<Lunbo>
    {
        IQueryable<Lunbo> GetTop3();
    }
}
