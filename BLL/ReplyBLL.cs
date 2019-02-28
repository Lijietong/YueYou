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
    public partial class ReplyBLL:BaseBLL<Reply>,IReplyBLL
    {
        private IReplyDAL ReplyDAL = Container.Resolve<IReplyDAL>();
        public override void SetDal()
        {
            Dal = ReplyDAL;
        }
        public Reply GetCommentofReply(int commentid)
        {
            var reply = ReplyDAL.GetCommentofReply(commentid);
            return reply;
        }
        public int GetCountofReply(int commentid)
        {
            var count = ReplyDAL.GetCountofReply(commentid);
            return count;
        }
    }
}
