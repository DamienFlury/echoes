import { Component, OnInit, Input } from '@angular/core';
import { Assignment } from '../model/assignment';

@Component({
  selector: 'app-assignments-list',
  templateUrl: './assignments-list.component.html',
  styleUrls: ['./assignments-list.component.css']
})
export class AssignmentsListComponent implements OnInit {

  constructor() { }
  @Input() assignments: Assignment[];

  ngOnInit() {
  }

}
