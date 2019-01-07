import { Component, OnInit } from '@angular/core';
import { Assignment } from '../model/assignment';
import { AssignmentsComponent } from '../assignments/assignments.component';
import { AssignmentsService } from '../assignments.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

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
  dueTo: NgbDateStruct;

  ngOnInit() {
    this.route.queryParams.subscribe(
      params => (this.assignment.classId = params['classId'])
    );
  }

  onSubmit() {
    console.log(this.dueTo);
    this.assignment.dueTo = new Date(this.dueTo.year, this.dueTo.month - 1, this.dueTo.day);
    console.log(this.assignment);
    this.assignmentsService
      .createAssignment(this.assignment)
      .subscribe(response =>
        this.router.navigate(['/classes/' + this.assignment.classId])
      );
  }
}
