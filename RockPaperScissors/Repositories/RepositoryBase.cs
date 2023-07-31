using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Data;
using RockPaperScissors.Models;
using RockPaperScissors.Repositories.Interfaces;
using System.Linq.Expressions;

namespace RockPaperScissors.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : ModelBase, new()
    {
        protected readonly DataContext Context;
        protected readonly IMapper Mapper;

        protected DbSet<TEntity> Table => Context.Set<TEntity>();
        protected IQueryable<TEntity> Entities => Context.Set<TEntity>().AsNoTracking();
        protected IQueryable<TEntity> AllEntities => Context.Set<TEntity>().IgnoreQueryFilters().AsNoTracking();

        protected RepositoryBase(DataContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(string navigationPropertyPath)
        {
            return await Entities.Include(navigationPropertyPath).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(params string[] navigationPropertyPaths)
        {
            var query = navigationPropertyPaths.Aggregate(Entities, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy)
        {
            var query = orderStrategy(Entities);
            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath)
        {
            var query = orderStrategy(Entities.Include(navigationPropertyPath));
            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths)
        {
            var query = navigationPropertyPaths.Aggregate(Entities, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            query = orderStrategy(query);
            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query)
        {
            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, string navigationPropertyPath)
        {
            return await query.Include(navigationPropertyPath).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, params string[] navigationPropertyPaths)
        {
            var queryNext = navigationPropertyPaths.Aggregate(query, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            return await queryNext.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy)
        {
            var queryNext = orderStrategy(query);
            return await queryNext.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath)
        {
            var queryNext = orderStrategy(query.Include(navigationPropertyPath));
            return await queryNext.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths)
        {
            var queryNext = navigationPropertyPaths.Aggregate(query, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            queryNext = orderStrategy(queryNext);
            return await queryNext.ToListAsync();
        }

        public async Task<List<T>> GetAllProjectToAsync<T>()
        {
            return await Entities.ProjectTo<T>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<T>> GetAllProjectToAsync<T>(string navigationPropertyPath)
        {
            return await Entities.Include(navigationPropertyPath).ProjectTo<T>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<T>> GetAllProjectToAsync<T>(params string[] navigationPropertyPaths)
        {
            var query = navigationPropertyPaths.Aggregate(Entities, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            return await query.ProjectTo<T>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<T>> GetAllProjectToAsync<T>(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy)
        {
            var query = orderStrategy(Entities);
            return await query.ProjectTo<T>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<T>> GetAllProjectToAsync<T>(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath)
        {
            var query = orderStrategy(Entities.Include(navigationPropertyPath));
            return await query.ProjectTo<T>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<T>> GetAllProjectToAsync<T>(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths)
        {
            var query = navigationPropertyPaths.Aggregate(Entities, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            query = orderStrategy(query);
            return await query.ProjectTo<T>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllWithDeletedAsync()
        {
            return await AllEntities.ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await Entities.Where(where).ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, string navigationPropertyPath)
        {
            return await Entities.Include(navigationPropertyPath).Where(where).ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths)
        {
            var query = navigationPropertyPaths.Aggregate(Entities, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            return await query.Where(where).ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy)
        {
            var query = orderStrategy(Entities.Where(where));
            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath)
        {
            var query = orderStrategy(Entities.Include(navigationPropertyPath).Where(where));
            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths)
        {
            var query = navigationPropertyPaths.Aggregate(Entities, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            query = orderStrategy(query.Where(where));
            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where)
        {
            return await query.Where(where).ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, string navigationPropertyPath)
        {
            return await query.Include(navigationPropertyPath).Where(where).ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths)
        {
            var queryNext = navigationPropertyPaths.Aggregate(query, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            return await queryNext.Where(where).ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy)
        {
            var queryNext = orderStrategy(query.Where(where));
            return await queryNext.ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath)
        {
            var queryNext = orderStrategy(query.Include(navigationPropertyPath).Where(where));
            return await queryNext.ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths)
        {
            var queryNext = navigationPropertyPaths.Aggregate(query, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            queryNext = orderStrategy(queryNext.Where(where));
            return await queryNext.ToListAsync();
        }

        public async Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where)
        {
            return await Entities.Where(where).ProjectTo<T>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, string navigationPropertyPath)
        {
            return await Entities.Include(navigationPropertyPath).Where(where).ProjectTo<T>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths)
        {
            var query = navigationPropertyPaths.Aggregate(Entities, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            return await query.Where(where).ProjectTo<T>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy)
        {
            var query = orderStrategy(Entities.Where(where));
            return await query.ProjectTo<T>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath)
        {
            var query = orderStrategy(Entities.Include(navigationPropertyPath).Where(where));
            return await query.ProjectTo<T>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths)
        {
            var query = navigationPropertyPaths.Aggregate(Entities, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            query = orderStrategy(query.Where(where));
            return await query.ProjectTo<T>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where)
        {
            return await Entities.FirstOrDefaultAsync(where);
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, string navigationPropertyPath)
        {
            return await Entities.Include(navigationPropertyPath).FirstOrDefaultAsync(where);
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths)
        {
            var query = navigationPropertyPaths.Aggregate(Entities, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            return await query.FirstOrDefaultAsync(where);
        }

        public async Task<TEntity> GetSingleAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where)
        {
            return await query.FirstOrDefaultAsync(where);
        }

        public async Task<TEntity> GetSingleAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, string navigationPropertyPath)
        {
            return await query.Include(navigationPropertyPath).FirstOrDefaultAsync(where);
        }

        public async Task<TEntity> GetSingleAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths)
        {
            var queryNext = navigationPropertyPaths.Aggregate(query, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            return await queryNext.FirstOrDefaultAsync(where);
        }

        public async Task<T> GetSingleProjectToAsync<T>(Expression<Func<TEntity, bool>> where)
        {
            return await Entities.Where(where).ProjectTo<T>(Mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<T> GetSingleProjectToAsync<T>(Expression<Func<TEntity, bool>> where, string navigationPropertyPath)
        {
            return await Entities.Include(navigationPropertyPath).Where(where).ProjectTo<T>(Mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<T> GetSingleProjectToAsync<T>(Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths)
        {
            var query = navigationPropertyPaths.Aggregate(Entities, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            return await query.Where(where).ProjectTo<T>(Mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetWithDeletedAsync(Expression<Func<TEntity, bool>> where)
        {
            return await AllEntities.Where(where).ToListAsync();
        }

        public async Task InsertAsync(TEntity model)
        {
            await Table.AddAsync(model);
            await Context.SaveChangesAsync();
        }

        public async Task InsertAsync(IEnumerable<TEntity> models)
        {
            await Table.AddRangeAsync(models);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity model)
        {
            Table.Update(model);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IEnumerable<TEntity> models)
        {
            Table.UpdateRange(models);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> where)
        {
            return await Entities.AnyAsync(where);
        }

        public async Task ForcedDeleteAsync(TEntity model)
        {
            Table.Remove(model);
            await Context.SaveChangesAsync();
        }

        public async Task ForcedDeleteAsync(IEnumerable<TEntity> models)
        {
            Table.RemoveRange(models);
            await Context.SaveChangesAsync();
        }
    }
}
