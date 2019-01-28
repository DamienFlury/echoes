import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from '../model/subject';
import { SubjectsService } from '../subjects.service';

@Component({
  selector: 'app-subject-detail',
  templateUrl: './subject-detail.component.html',
  styleUrls: ['./subject-detail.component.css']
})
export class SubjectDetailComponent implements OnInit {
  constructor(
    private subjectsService: SubjectsService,
    private route: ActivatedRoute,
  ) {}

  showError = false;

  subject: Subject;
  ngOnInit() {
    this.route.params.subscribe(params =>
      this.subjectsService.getSubject(+params['id']).subscribe(subject => {
        this.subject = subject;
      })
    );
  }
}
