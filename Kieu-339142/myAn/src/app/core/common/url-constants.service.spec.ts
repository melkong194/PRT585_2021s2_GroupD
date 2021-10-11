import { TestBed } from '@angular/core/testing';

import { UrlConstantsService } from './url-constants.service';

describe('UrlConstantsService', () => {
  let service: UrlConstantsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UrlConstantsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
