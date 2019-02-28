using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using YueYou.Model;

namespace DAL
{
   public partial class ReplyDAL : BaseDAL<Reply>, IReplyDAL
    {
        YueYouEntities db = new YueYouEntities();
        public Reply GetCommentofReply(int commentid)
        {
            var reply = db.Reply.Where(u => u.Comment_id == commentid).FirstOrDefault();
            return reply;
        }
        public int GetCountofReply(int commentid)
        {
            var count = db.Reply.Where(u => u.Comment_id == commentid).Count();
            return count;
        }
    }
}
