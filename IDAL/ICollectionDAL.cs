using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YueYou.Model;

namespace IDAL
{
    public partial interface ICollectionDAL:IBaseDAL<Collection>
    {
        int GetCount(int userid, int guideid);
    }
}
