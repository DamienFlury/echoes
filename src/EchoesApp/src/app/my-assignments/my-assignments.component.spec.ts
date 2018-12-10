import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyAssignmentsComponent } from './my-assignments.component';

describe('MyAssignmentsComponent', () => {
  let component: MyAssignmentsComponent;
  let fixture: ComponentFixture<MyAssignmentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyAssignmentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyAssignmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
