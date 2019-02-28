using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq.Expressions;

namespace DAL
{
    public abstract  class BaseDAL<T> where T : class, new()  //定义一个抽象类 并且T需要为引用类型
    {
        public DbContext dbContext = DbContextFactory.Create();

        //添加数据
        public void Add(T t)
        {
            dbContext.Set<T>().Add(t);
        }


        //删除数据
        public void Delete(T t)
        {
            dbContext.Set<T>().Remove(t);
        }

        //更新数据
        public void Update(T t)
        {
            dbContext.Set<T>().AddOrUpdate(t);
        }


        //查找某条数据
        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda);
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        //Expression<Func<>>为抽象方法 无具体方法体 返回具体值
        {
            //是否升序
            if (isAsc)
            {
                return dbContext.Set<T>().Where(WhereLambda).OrderBy(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return dbContext.Set<T>().Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

        //查询表中所有数据
        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        //根据id查找
        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }
    }
}
