import { Component, OnInit } from '@angular/core';
import { ClassesService } from '../classes.service';
import { Class } from '../model/class';

@Component({
  selector: 'app-classes',
  templateUrl: './classes.component.html',
  styleUrls: ['./classes.component.css']
})
export class ClassesComponent implements OnInit {

  constructor(private classesService: ClassesService) { }

  public classes: Class[];

  ngOnInit() {
    this.classesService.getClasses().subscribe(classes => this.classes = classes);
  }

}
