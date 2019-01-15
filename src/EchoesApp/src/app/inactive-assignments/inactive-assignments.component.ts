import { Component, OnInit } from '@angular/core';
import { AssignmentsService } from '../assignments.service';
import { Assignment } from '../model/assignment';

@Component({
  selector: 'app-inactive-assignments',
  templateUrl: './inactive-assignments.component.html',
  styleUrls: ['./inactive-assignments.component.css']
})
export class InactiveAssignmentsComponent implements OnInit {
  constructor(private assignmentsService: AssignmentsService) {}

  assignments: Assignment[];

  ngOnInit() {
    this.assignmentsService
      .getInactiveAssignments()
      .subscribe(data => this.assignments = data);
  }
}
