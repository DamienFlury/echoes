import { Component, OnInit } from '@angular/core';
import { AssignmentsService } from '../assignments.service';
import { Assignment } from '../model/assignment';

@Component({
  selector: 'app-active-assignments',
  templateUrl: './active-assignments.component.html',
  styleUrls: ['./active-assignments.component.css']
})
export class ActiveAssignmentsComponent implements OnInit {
  constructor(private assignmentsService: AssignmentsService) {}

  assignments: Assignment[];

  ngOnInit() {
    this.assignmentsService
      .getActiveAssignments()
      .subscribe(data => this.assignments = data);
  }
}
