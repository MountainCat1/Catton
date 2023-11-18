import { TestBed } from '@angular/core/testing';

import { ConventionIdGetterService } from './convention-id-getter.service';

describe('ConventionIdGetterService', () => {
  let service: ConventionIdGetterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConventionIdGetterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
