import { Component, OnInit } from '@angular/core';
import { Assignment } from '../model/assignment';
import { AssignmentsComponent } from '../assignments/assignments.component';
import { AssignmentsService } from '../assignments.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-assignment',
  templateUrl: './create-assignment.component.html',
  styleUrls: ['./create-assignment.component.css']
})
export class CreateAssignmentComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private assignmentsService: AssignmentsService,
    private router: Router
  ) {}

  assignment = new Assignment();

  ngOnInit() {
    this.route.queryParams.subscribe(
      params => (this.assignment.subjectId = params['subjectId'])
    );
  }

  onSubmit() {
    this.assignmentsService
      .createAssignment(this.assignment)
      .subscribe(response =>
        this.router.navigate(['/subjects/' + this.assignment.subjectId])
      );
  }
}
