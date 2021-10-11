import { TestBed } from '@angular/core/testing';

import { SystemConstantsService } from './system-constants.service';

describe('SystemConstantsService', () => {
  let service: SystemConstantsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SystemConstantsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
