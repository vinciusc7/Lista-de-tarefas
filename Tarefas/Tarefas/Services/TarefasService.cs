using Tarefas.Models;
using Tarefas.Repository;

namespace Tarefas.Services
{
    public class TarefasService : ITarefasService
    {
        private readonly ITarefasRepository _repository;

        public TarefasService(ITarefasRepository repository)
        {
            _repository = repository;
        }

        public void CriarTarefas(TarefasModel tarefas) => _repository.CriarTarefas(tarefas);

        public void DeletarTarefas(int id) => _repository.DeletarTarefas(id);

        public void Finalizartarefa(int id) => _repository.Finalizartarefa(id);

        public List<TarefasModel> GetTarefas() => _repository.GetTarefas();

        public TarefasModel GetTarefasById(int id) => _repository.GetTarefasById(id);
    }
}
