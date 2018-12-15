import { Component, OnInit } from '@angular/core';
import { AssignmentsService } from '../assignments.service';
import { Assignment } from '../assignment';

@Component({
  selector: 'app-my-assignments',
  templateUrl: './my-assignments.component.html',
  styleUrls: ['./my-assignments.component.css']
})
export class MyAssignmentsComponent implements OnInit {
  constructor(private assignmentsService: AssignmentsService) {}

  assignments: Assignment[];

  ngOnInit() {
    this.assignmentsService
      .getAssignments()
      .subscribe(data => this.assignments = data);
  }
}
