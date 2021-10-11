import { TestBed } from '@angular/core/testing';

import { AdminAuthenService } from './admin-authen.service';

describe('AdminAuthenService', () => {
  let service: AdminAuthenService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdminAuthenService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
