using Tarefas.Models;

namespace Tarefas.Services
{
    public interface ITarefasService
    {
        List<TarefasModel> GetTarefas();
        TarefasModel GetTarefasById(int id);
        void CriarTarefas(TarefasModel tarefas);
        void Finalizartarefa(int id);
        void DeletarTarefas(int id);
    }
}
