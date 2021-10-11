import { TestBed } from '@angular/core/testing';

import { StaffAuthenService } from './staff-authen.service';

describe('StaffAuthenService', () => {
  let service: StaffAuthenService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StaffAuthenService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
