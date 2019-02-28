using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using IDAL;
using Autofac;

namespace DALContainer
{
    public class Container
    {
        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IContainer container = null;

        /// <summary>
        /// 获取 IDal 的实例化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            try
            {
                if (container == null)
                {
                    Initialise();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("IOC实例化出错!" + ex.Message);
            }

            return container.Resolve<T>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            //格式：builder.RegisterType<xxxx>().As<Ixxxx>().InstancePerLifetimeScope();
            builder.RegisterType<UserInfoDAL>().As<IUserInfoDAL>().InstancePerLifetimeScope();
            builder.RegisterType<Routing_arrangementDAL>().As<IRouting_arrangementDAL>().InstancePerLifetimeScope();
            builder.RegisterType<ReplyDAL>().As<IReplyDAL>().InstancePerLifetimeScope();
            builder.RegisterType<OrderDetailsDAL>().As<IOrderDetailsDAL>().InstancePerLifetimeScope();
            builder.RegisterType<OrdersDAL>().As<IOrdersDAL>().InstancePerLifetimeScope();
            builder.RegisterType<NoticeDAL>().As<INoticeDAL>().InstancePerLifetimeScope();
            builder.RegisterType<NewsDAL>().As<INewsDAL>().InstancePerLifetimeScope();
            builder.RegisterType<LunboDAL>().As<ILunboDAL>().InstancePerLifetimeScope();
            builder.RegisterType<GuideDAL>().As<IGuideDAL>().InstancePerLifetimeScope();
            builder.RegisterType<GuideDetailsDAL>().As<IGuideDetailsDAL>().InstancePerLifetimeScope();
            builder.RegisterType<CommentDAL>().As<ICommentDAL>().InstancePerLifetimeScope();
            builder.RegisterType<CollectionDAL>().As<ICollectionDAL>().InstancePerLifetimeScope();
            builder.RegisterType<AdminDAL>().As<IAdminDAL>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}


