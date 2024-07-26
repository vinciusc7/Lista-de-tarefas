using Tarefas.Models;

namespace Tarefas.Repository
{
    public interface ITarefasRepository
    {
        List<TarefasModel> GetTarefas();
        TarefasModel GetTarefasById(int id);
        void CriarTarefas(TarefasModel tarefas);
        void Finalizartarefa(int id);
        void DeletarTarefas(int id);

    }
}
