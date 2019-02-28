using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace IBLL
{
    public partial interface IBaseBLL<T> where T : class, new()
    {
        //添加数据
        bool Add(T t);

        //删除数据 按id
        bool Delete(T t);

        //更新数据
        bool Update(T t);

        //查找某条数据
        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda);

        //分页操作
        IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda);
       
        //查询表中所有数据
        IQueryable<T> GetAll();

        //根据id查找
         T GetById(int id);
    }
}
