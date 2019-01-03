import { Component, OnInit } from '@angular/core';
import { Assignment } from '../model/assignment';
import { AssignmentsComponent } from '../assignments/assignments.component';
import { AssignmentsService } from '../assignments.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-assignment',
  templateUrl: './create-assignment.component.html',
  styleUrls: ['./create-assignment.component.css']
})
export class CreateAssignmentComponent implements OnInit {

  constructor(private route: ActivatedRoute, private assignmentsService: AssignmentsService) { }

  assignment = new Assignment();

  ngOnInit() {
    this.route.queryParams.subscribe(params => this.assignment.classId = params['classId']);
  }

  onSubmit() {
    this.assignmentsService.createAssignment(this.assignment).subscribe(console.log);
  }

}
