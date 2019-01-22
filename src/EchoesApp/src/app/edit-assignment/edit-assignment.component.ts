import { Component, OnInit, Input } from '@angular/core';
import { Assignment } from '../model/assignment';

@Component({
  selector: 'app-edit-assignment',
  templateUrl: './edit-assignment.component.html',
  styleUrls: ['./edit-assignment.component.css']
})
export class EditAssignmentComponent implements OnInit {

  constructor() { }

  @Input() assignment: Assignment;

  ngOnInit() {
  }

}
