import { TestBed } from '@angular/core/testing';

import { ActAPIService } from './act-api.service';

describe('ActAPIService', () => {
  let service: ActAPIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ActAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
