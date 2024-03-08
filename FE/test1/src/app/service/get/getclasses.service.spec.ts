import { TestBed } from '@angular/core/testing';

import { GetclassesService } from './getclasses.service';

describe('GetclassesService', () => {
  let service: GetclassesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetclassesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
