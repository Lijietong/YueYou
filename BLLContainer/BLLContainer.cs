using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using Autofac;
using BLL;

namespace BLLContainer
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
            builder.RegisterType<UserInfoBLL>().As<IUserInfoBLL>().InstancePerLifetimeScope();
            builder.RegisterType<Routing_arrangementBLL>().As<IRouting_arrangementBLL>().InstancePerLifetimeScope();
            builder.RegisterType<ReplyBLL>().As<IReplyBLL>().InstancePerLifetimeScope();
            builder.RegisterType<OrderDetailsBLL>().As<IOrderDetailsBLL>().InstancePerLifetimeScope();
            builder.RegisterType<OrdersBLL>().As<IOrdersBLL>().InstancePerLifetimeScope();
            builder.RegisterType<NoticeBLL>().As<INoticeBLL>().InstancePerLifetimeScope();
            builder.RegisterType<NewsBLL>().As<INewsBLL>().InstancePerLifetimeScope();
            builder.RegisterType<LunboBLL>().As<ILunboBLL>().InstancePerLifetimeScope();
            builder.RegisterType<GuideBLL>().As<IGuideBLL>().InstancePerLifetimeScope();
            builder.RegisterType<GuideDetailsBLL>().As<IGuideDetailsBLL>().InstancePerLifetimeScope();
            builder.RegisterType<CommentBLL>().As<ICommentBLL>().InstancePerLifetimeScope();
            builder.RegisterType<CollectionBLL>().As<ICollectionBLL>().InstancePerLifetimeScope();
            builder.RegisterType<AdminBLL>().As<IAdminBLL>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
