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
    public partial class NoticeBLL:BaseBLL<Notice>,INoticeBLL
    {
        private INoticeDAL NoticeDAL = Container.Resolve<INoticeDAL>();
        public override void SetDal()
        {
            Dal = NoticeDAL;
        }
    }
}
