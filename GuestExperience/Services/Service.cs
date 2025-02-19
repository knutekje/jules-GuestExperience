using System.Collections.Generic;
using System.Threading.Tasks;
using GuestExperience.Repositories;

namespace GuestExperience.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<TEntity>> GetAllAsync() => _repository.GetAllAsync();
        public Task<TEntity> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task<TEntity> CreateAsync(TEntity entity) => _repository.CreateAsync(entity);
        public Task<TEntity> UpdateAsync(TEntity entity) => _repository.UpdateAsync(entity);
        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}