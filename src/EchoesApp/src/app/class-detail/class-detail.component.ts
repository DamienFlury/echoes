import { Component, OnInit } from '@angular/core';
import { Class } from '../model/class';
import { ClassesService } from '../classes.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-class-detail',
  templateUrl: './class-detail.component.html',
  styleUrls: ['./class-detail.component.css']
})
export class ClassDetailComponent implements OnInit {
  constructor(
    private classesService: ClassesService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  cls: Class;

  ngOnInit() {
    this.route.params.subscribe(params =>
      this.classesService
        .getClassById(+params['id'])
        .subscribe(cls => (this.cls = cls))
    );
  }

  leaveClass() {
    this.classesService.leaveClass(this.cls.id).subscribe(data => this.router.navigate(['/classes']));
  }
}
