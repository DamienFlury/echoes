import { Component, OnInit } from '@angular/core';
import { InvitationsService } from '../invitations.service';

@Component({
  selector: 'app-invitations',
  templateUrl: './invitations.component.html',
  styleUrls: ['./invitations.component.css']
})
export class InvitationsComponent implements OnInit {

  constructor(private invitationsService: InvitationsService) { }

  ngOnInit() {
    this.invitationsService.getInvitedClasses().subscribe(console.log);
  }

}
