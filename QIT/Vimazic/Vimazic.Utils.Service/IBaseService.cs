using EPS.Utils.Repository;
using EPS.Utils.Repository.Audit;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EPS.Utils.Service
{
    public interface IBaseService : IDisposable
    {
        IQueryable<TDto> All<TEntity, TDto>()
            where TEntity : class;

        int Count<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        Task<int> CountAsync<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        TDto Find<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        TDto Find<TEntity, TDto>(object id)
            where TEntity : class;

        Task<TDto> FindAsync<TEntity, TDto>(object id)
            where TEntity : class;

        Task<TDto> FindAsync<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        IQueryable<TDto> Filter<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        IQueryable<TDto> FilterEntity<TEntity, TDto>(params Expression<Func<TEntity, bool>>[] predicates)
            where TEntity : class;

        PagingResult<TDto> FilterPaged<TEntity, TDto>(PagingParams<TDto> pagingParams, params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        Task<PagingResult<TDto>> FilterPagedAsync<TEntity, TDto>(PagingParams<TDto> pagingParams, params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        PagingResult<TDto> FilterEntityPaged<TEntity, TDto>(PagingParams<TEntity> pagingParams, params Expression<Func<TEntity, bool>>[] predicates)
            where TEntity : class;

        Task<PagingResult<TDto>> FilterEntityPagedAsync<TEntity, TDto>(PagingParams<TEntity> pagingParams, params Expression<Func<TEntity, bool>>[] predicates)
            where TEntity : class;

        bool Contain<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        Task<bool> ContainAsync<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        void Create<TEntity, TDto>(params TDto[] dtos)
            where TEntity : class
            where TDto : class;

        Task CreateAsync<TEntity, TDto>(params TDto[] dtos)
            where TEntity : class
            where TDto : class;

        int Delete<TEntity, TKey>(TKey id)
            where TEntity : class;

        int Delete<TEntity, TKey>(TKey[] ids)
            where TEntity : class;

        int Delete<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        Task<int> DeleteAsync<TEntity, TKey>(TKey id)
            where TEntity : class;

        Task<int> DeleteAsync<TEntity, TKey>(TKey[] ids)
            where TEntity : class;

        Task<int> DeleteAsync<TEntity, TDto>(params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class;

        int Update<TEntity, TDto>(object id, TDto dto)
            where TEntity : class
            where TDto : class;

        Task<int> UpdateAsync<TEntity, TDto>(object id, TDto dto)
            where TEntity : class
            where TDto : class;

        int Update<TEntity, TDto, TKey>(params TDto[] dtos)
            where TEntity : class
            where TDto : class, IIdentifier<TKey>;

        Task<int> UpdateAsync<TEntity, TDto, TKey>(params TDto[] dtos)
            where TEntity : class
            where TDto : class, IIdentifier<TKey>;

        int ExecuteNonQuery(string sql, params object[] sqlParams);

        TContext GetDbContext<TContext>() where TContext : class;

        IDbContextTransaction BeginTransaction();

        IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel);
    }

}
