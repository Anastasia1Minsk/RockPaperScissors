﻿using System.Linq.Expressions;

namespace RockPaperScissors.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(string navigationPropertyPath);
        Task<List<TEntity>> GetAllAsync(params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy);
        Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath);
        Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query);
        Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, string navigationPropertyPath);
        Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy);
        Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath);
        Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths);
        Task<List<T>> GetAllProjectToAsync<T>();
        Task<List<T>> GetAllProjectToAsync<T>(string navigationPropertyPath);
        Task<List<T>> GetAllProjectToAsync<T>(params string[] navigationPropertyPaths);
        Task<List<T>> GetAllProjectToAsync<T>(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy);
        Task<List<T>> GetAllProjectToAsync<T>(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath);
        Task<List<T>> GetAllProjectToAsync<T>(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetAllWithDeletedAsync();
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, string navigationPropertyPath);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where);
        Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, string navigationPropertyPath);
        Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy);
        Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath);
        Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths);
        Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where);
        Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, string navigationPropertyPath);
        Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths);
        Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy);
        Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath);
        Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, string navigationPropertyPath);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths);
        Task<TEntity> GetSingleAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where);
        Task<TEntity> GetSingleAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, string navigationPropertyPath);
        Task<TEntity> GetSingleAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths);
        Task<T> GetSingleProjectToAsync<T>(Expression<Func<TEntity, bool>> where);
        Task<T> GetSingleProjectToAsync<T>(Expression<Func<TEntity, bool>> where, string navigationPropertyPath);
        Task<T> GetSingleProjectToAsync<T>(Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetWithDeletedAsync(Expression<Func<TEntity, bool>> where);
        Task InsertAsync(TEntity model);
        Task InsertAsync(IEnumerable<TEntity> models);
        Task UpdateAsync(TEntity model);
        Task UpdateAsync(IEnumerable<TEntity> models);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> where);
        Task ForcedDeleteAsync(TEntity model);
        Task ForcedDeleteAsync(IEnumerable<TEntity> models);
    }
}
