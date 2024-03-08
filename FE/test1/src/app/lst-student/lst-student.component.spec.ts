import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LstStudentComponent } from './lst-student.component';

describe('LstStudentComponent', () => {
  let component: LstStudentComponent;
  let fixture: ComponentFixture<LstStudentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LstStudentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LstStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
