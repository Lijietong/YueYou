using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YueYou.Model;

namespace IDAL
{
    public partial interface ILunboDAL:IBaseDAL<Lunbo>
    {
        IQueryable<Lunbo> GetTop3();
    }
}
