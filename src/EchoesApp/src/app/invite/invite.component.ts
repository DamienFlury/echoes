import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InvitationsService } from '../invitations.service';

@Component({
  selector: 'app-invite',
  templateUrl: './invite.component.html',
  styleUrls: ['./invite.component.css']
})
export class InviteComponent implements OnInit {

  constructor(private route: ActivatedRoute, private invitationsService: InvitationsService) { }

  classId: number;
  email: string;

  ngOnInit() {
    this.route.queryParams.subscribe(params => this.classId = +params['classId']);
  }

  invite() {
    this.invitationsService.invite(this.classId, this.email).subscribe();
  }

}
