using Microsoft.EntityFrameworkCore;
using Tarefas.Context;
using Tarefas.Models;

namespace Tarefas.Repository
{
    public class TarefasRepository : ITarefasRepository
    {
        private readonly AppDbContext _context;

        public TarefasRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<TarefasModel> GetTarefas()
        {
            try
            {
                var tarefas = _context.Tarefas.OrderBy(t => t.Status).ToList();
                return tarefas;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar as tarefas: " + ex.Message);
            }
            return new List<TarefasModel>();
        }
        public TarefasModel GetTarefasById(int id)
        {
            try
            {
                var tarefa = _context.Tarefas.FirstOrDefault(t => t.TarefaId == id);
                if (tarefa != null)
                {
                    return tarefa;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tarefa não encontrada: " + ex.Message);
            }
            return new TarefasModel();
        }

        public void CriarTarefas(TarefasModel tarefas)
        {
            try
            {
                _context.Tarefas.Add(tarefas);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir a tarefa no banco de dados: " + ex.Message);
            }
        }
        public void Finalizartarefa(int id)
        {
            var tarefa = GetTarefasById(id);

            if (tarefa != null)
            {
                if (tarefa.Status)
                {
                    try
                    {
                        tarefa.Status = false;
                        _context.Entry(tarefa).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro ao atualizar o status de uma tarefa: " + ex.Message);
                    }
                    
                }
                else
                {
                    try
                    {
                        tarefa.Status = true;
                        _context.Entry(tarefa).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro ao atualizar o status de uma tarefa: " + ex.Message);
                    }
                }
            }
        }

        public void DeletarTarefas(int id)
        {
            var tarefa = GetTarefasById(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges();
            }
        }
    }
}
