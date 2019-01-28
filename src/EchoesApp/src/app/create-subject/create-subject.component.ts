import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from '../model/subject';
import { SubjectsService } from '../subjects.service';

@Component({
  selector: 'app-create-subject',
  templateUrl: './create-subject.component.html',
  styleUrls: ['./create-subject.component.css']
})
export class CreateSubjectComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private subjectsService: SubjectsService,
    private router: Router
  ) {}

  subject = new Subject();

  ngOnInit() {
    this.route.queryParams.subscribe(
      params => (this.subject.classId = params['classId'])
    );
  }

  onSubmit() {
    this.subjectsService
      .createSubject(this.subject)
      .subscribe(response =>
        this.router.navigate(['/classes/' + this.subject.classId])
      );
  }
}
