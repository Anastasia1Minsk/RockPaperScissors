namespace RockPaperScissors.Services.Interfaces
{
    public interface IService<TEntity> : IServiceBase<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<bool> ExistsByIdAsync(int id);
    }
}
