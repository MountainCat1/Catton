import { TestBed } from '@angular/core/testing';

import { SubdomainServiceService } from './subdomain-service.service';

describe('SubdomainServiceService', () => {
  let service: SubdomainServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SubdomainServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
