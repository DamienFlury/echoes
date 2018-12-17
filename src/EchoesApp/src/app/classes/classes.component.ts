import { Component, OnInit } from '@angular/core';
import { ClassesService } from '../classes.service';

@Component({
  selector: 'app-classes',
  templateUrl: './classes.component.html',
  styleUrls: ['./classes.component.css']
})
export class ClassesComponent implements OnInit {

  constructor(private classesService: ClassesService) { }

  ngOnInit() {
    this.classesService.getClasses().subscribe(classes => console.log(classes));
  }

}
