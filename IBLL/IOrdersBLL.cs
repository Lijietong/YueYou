using YueYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public partial interface IOrdersBLL:IBaseBLL<Orders>
    {
        int GuideCommentOrder(int userid, int guideid);
    }
}
