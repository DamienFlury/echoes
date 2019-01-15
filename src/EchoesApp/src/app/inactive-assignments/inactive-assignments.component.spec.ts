import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InactiveAssignmentsComponent } from './inactive-assignments.component';

describe('InactiveAssignmentsComponent', () => {
  let component: InactiveAssignmentsComponent;
  let fixture: ComponentFixture<InactiveAssignmentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InactiveAssignmentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InactiveAssignmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
