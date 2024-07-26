import { Component } from '@angular/core';
import { TarefasServiceService } from './services/tarefas/tarefas-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Tarefas-front';
  tarefa: string = '';
  tarefas: any[] = [];

  constructor(private TarefasServiceService: TarefasServiceService){}

  ngOnInit() {
    this.obterTarefas();
  }
  onSubmit() {
    const tarefaData = {
      tarefa: this.tarefa,
      status: false
    };

    this.TarefasServiceService.adicionarTarefa(tarefaData).subscribe(response => {
      console.log('Tarefa adicionada com sucesso', response);
      this.obterTarefas();
    }, error => {
      console.log('Erro ao adicionar a tarefa', error);
    });

    this.tarefa = '';
  }

  obterTarefas(){
    this.TarefasServiceService.obterTarefas().subscribe(data => {
      this.tarefas = data;
    }, error => {
      console.log('Erro ao obter as tarefas: ', error)
    })
  }

  atualizarTarefa(tarefaId: number){
    this.TarefasServiceService.atualizarStatus(tarefaId).subscribe(() => {
      console.log(tarefaId);
      console.log('Tarefa atualizada com sucesso');
      this.obterTarefas();
    }, error => {
      console.log("Erro ao atualizar a tarefa", error);
    })
  };
  deletarTarefa(tarefaId: number){
    this.TarefasServiceService.deletarTarefa(tarefaId).subscribe(() => {
      console.log(tarefaId)
      console.log('Tarefa deletada com sucesso');
      this.obterTarefas();
    }, error => {
      console.log('Erro ao deletar tarefa', error);
    })
  }

}
