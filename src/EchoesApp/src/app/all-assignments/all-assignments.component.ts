import { Component, OnInit } from '@angular/core';
import { AssignmentsService } from '../assignments.service';
import { Assignment } from '../model/assignment';

@Component({
  selector: 'app-all-assignments',
  templateUrl: './all-assignments.component.html',
  styleUrls: ['./all-assignments.component.css']
})
export class AllAssignmentsComponent implements OnInit {
  constructor(private assignmentsService: AssignmentsService) {}

  assignments: Assignment[];

  ngOnInit() {
    this.assignmentsService
      .getAssignments()
      .subscribe(data => this.assignments = data);
  }
}
