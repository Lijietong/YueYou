using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YueYou.Model;

namespace IDAL
{
    public partial interface IOrdersDAL:IBaseDAL<Orders>
    {
        int GuideCommentOrder(int userid, int guideid);
    }
}
