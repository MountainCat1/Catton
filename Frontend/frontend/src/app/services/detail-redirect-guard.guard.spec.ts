import { TestBed } from '@angular/core/testing';

import { DetailRedirectGuardGuard } from './detail-redirect-guard.guard';

describe('DetailRedirectGuardGuard', () => {
  let guard: DetailRedirectGuardGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(DetailRedirectGuardGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
