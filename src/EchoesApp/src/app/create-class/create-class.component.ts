import { Component, OnInit } from '@angular/core';
import { ClassesService } from '../classes.service';
import { Class } from '../model/class';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-class',
  templateUrl: './create-class.component.html',
  styleUrls: ['./create-class.component.css']
})
export class CreateClassComponent implements OnInit {

  constructor(private classesService: ClassesService, private router: Router) { }

  cls = new Class();

  ngOnInit() {
  }

  onSubmit() {
    this.classesService.createClass(this.cls).subscribe(() => this.router.navigate(['/classes']));
  }
}
