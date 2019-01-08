import { Component, OnInit } from '@angular/core';
import { InvitationsService } from '../invitations.service';
import { Class } from '../model/class';

@Component({
  selector: 'app-invitations',
  templateUrl: './invitations.component.html',
  styleUrls: ['./invitations.component.css']
})
export class InvitationsComponent implements OnInit {
  constructor(private invitationsService: InvitationsService) {}

  public classes: Class[];

  ngOnInit() {
    this.invitationsService
      .getReceivedClasses()
      .subscribe(classes => (this.classes = classes));
  }

  accept(classId: number) {
    this.invitationsService.accept(classId).subscribe(classes => this.classes = classes);
  }
}
