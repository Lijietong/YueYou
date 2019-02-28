using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IDAL;

namespace BLL
{
        public abstract partial class BaseBLL<T> where T : class, new() //泛型封装
        {
            public BaseBLL()
            {
                SetDal();
            }
            public IBaseDAL<T> Dal { get; set; }
            public abstract void SetDal();

        //添加数据
        public bool Add(T t)
            {
                Dal.Add(t);
                return Dal.SaveChanges();
            }

        //删除数据 
        public bool Delete(T t)
            {
                Dal.Delete(t);
                return Dal.SaveChanges();
            }

        //更新数据
        public bool Update(T t)
            {
                Dal.Update(t);
                return Dal.SaveChanges();
            }

        //查找某条数据
        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
            {
                return Dal.GetModels(whereLambda);
            }

        //分页操作
        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
                Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
            {
                return Dal.GetModelsByPage(pageSize, pageIndex, isAsc, OrderByLambda, WhereLambda);
            }

        //查询表中所有数据
        public IQueryable<T> GetAll()
            {
                return Dal.GetAll();
            }

        //根据id查找
        public T GetById(int id)
        {
            return Dal.GetById(id);
        }


    }
}

