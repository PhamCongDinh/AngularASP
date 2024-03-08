import { TestBed } from '@angular/core/testing';

import { EditstudentService } from './editstudent.service';

describe('EditstudentService', () => {
  let service: EditstudentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EditstudentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
