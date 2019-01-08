import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActiveAssignmentsComponent } from './active-assignments.component';

describe('ActiveAssignmentsComponent', () => {
  let component: ActiveAssignmentsComponent;
  let fixture: ComponentFixture<ActiveAssignmentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActiveAssignmentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActiveAssignmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
