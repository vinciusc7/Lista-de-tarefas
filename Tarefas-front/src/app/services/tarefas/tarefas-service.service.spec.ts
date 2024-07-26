import { TestBed } from '@angular/core/testing';

import { TarefasServiceService } from './tarefas-service.service';

describe('TarefasServiceService', () => {
  let service: TarefasServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TarefasServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
