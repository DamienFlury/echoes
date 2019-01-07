import { Component, OnInit } from '@angular/core';
import { Assignment } from '../model/assignment';
import { AssignmentsService } from '../assignments.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-assignment-detail',
  templateUrl: './assignment-detail.component.html',
  styleUrls: ['./assignment-detail.component.css']
})
export class AssignmentDetailComponent implements OnInit {
  constructor(
    private assignmentsService: AssignmentsService,
    private route: ActivatedRoute
  ) {}

  assignment: Assignment;
  ngOnInit() {
    this.route.params.subscribe(params =>
      this.assignmentsService
        .getAssignment(+params['id'])
        .subscribe(assignment => (this.assignment = assignment))
    );
  }
}
