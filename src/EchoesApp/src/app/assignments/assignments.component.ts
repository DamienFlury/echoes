import { Component, OnInit } from '@angular/core';
import { AssignmentsService } from '../assignments.service';
import { Assignment } from '../assignment';

@Component({
  selector: 'app-assignments',
  templateUrl: './assignments.component.html',
  styleUrls: ['./assignments.component.css']
})
export class AssignmentsComponent implements OnInit {
  constructor(private assignmentsService: AssignmentsService) {}

  assignments: Assignment[];

  ngOnInit() {
    this.assignmentsService
      .getAssignments()
      .subscribe(data => this.assignments = data);
  }
}