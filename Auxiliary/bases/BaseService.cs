using Academy.DDD.Domain.Entities;
using Academy.DDD.Domain.Interfaces.Repositories;
using Academy.DDD.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace Academy.DDD.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<List<T>> ObterTodosAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.ListAsync(expression);
        }

        public async Task<T> ObterAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.FindAsync(expression);
        }

        public async Task<List<T>> ObterTodosAsync()
        {
            return await _repository.ListAsync(x => x.Ativo);
        }

        public async Task<T> ObterPorIdAsync(int id)
        {
            return await _repository.FindAsync(x => x.Id == id && x.Ativo);
        }

        public async Task AdicionarAsync(T entity)
        {
            entity.DataInclusao = DateTime.Now;
            await _repository.AddAsync(entity);
        }

        public async Task DeletarAsync(int id)
        {
            var entity = await _repository.FindAsync(id);
            entity.DataAlteracao = DateTime.Now;
            entity.Ativo = false;
            await _repository.EditAsync(entity);
        }

        public async Task AlterarAsync(T entity)
        {
            var find = await _repository.FindAsNoTrackingAsync(x => x.Id == entity.Id && x.Ativo);
            entity.DataInclusao = find.DataInclusao;
            entity.DataAlteracao = DateTime.Now;
            await _repository.EditAsync(entity);
        }
    }
}
