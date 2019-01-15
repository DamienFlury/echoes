import { Component, OnInit } from '@angular/core';
import { Assignment } from '../model/assignment';
import { AssignmentsService } from '../assignments.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-assignment-detail',
  templateUrl: './assignment-detail.component.html',
  styleUrls: ['./assignment-detail.component.css']
})
export class AssignmentDetailComponent implements OnInit {
  constructor(
    private assignmentsService: AssignmentsService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  showError = false;

  assignment: Assignment;
  ngOnInit() {
    this.route.params.subscribe(params =>
      this.assignmentsService
        .getAssignment(+params['id'])
        .subscribe(assignment => (this.assignment = assignment))
    );
  }

  delete() {
    this.assignmentsService
      .deleteAssignemnt(this.assignment.id)
      .subscribe(
        result => this.router.navigate(['/assignments/active']),
        error => (this.showError = true)
      );
  }

  setToDone() {
    this.assignmentsService.setAssignmentToDone(this.assignment.id).subscribe(console.log);
  }
}
