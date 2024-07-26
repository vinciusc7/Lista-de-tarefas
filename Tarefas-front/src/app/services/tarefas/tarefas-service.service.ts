import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class TarefasServiceService {

  private urlApi = 'https://localhost:7227/';
  constructor(private http: HttpClient) { }

    adicionarTarefa(tarefa: { tarefa: string, status: boolean }): Observable<any> {
      return this.http.post(this.urlApi + 'Tarefas/CriarTarefa', tarefa)
    };
    obterTarefas(): Observable<any[]> {
      return this.http.get<any[]>(this.urlApi + "Tarefas/GetTarefas");
    };
    atualizarStatus(tarefaId: number): Observable<void> {
      return this.http.put<void>(`${this.urlApi}Tarefas/AtualizarTarefa?id=${tarefaId}`, {});
    }
    deletarTarefa(tarefaId: number): Observable<void> {
      return this.http.delete<void>(`${this.urlApi}Tarefas/DeletarTarefa?id=${tarefaId}`);
    };
  }
