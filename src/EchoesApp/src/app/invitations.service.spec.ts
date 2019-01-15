import { TestBed } from '@angular/core/testing';

import { InvitationsService } from './invitations.service';

describe('InvitationsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: InvitationsService = TestBed.get(InvitationsService);
    expect(service).toBeTruthy();
  });
});
