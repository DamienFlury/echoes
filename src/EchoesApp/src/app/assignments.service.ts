import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Assignment } from './model/assignment';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class AssignmentsService {
  constructor(private http: HttpClientService) {}

  getAssignments(): Observable<Assignment[]> {
    return this.http.get<Assignment[]>('/api/Assignments');
  }

  getActiveAssignments(): Observable<Assignment[]> {
    return this.http.get<Assignment[]>('/api/Assignments/Active');
  }
  getInactiveAssignments(): Observable<Assignment[]> {
    return this.http.get<Assignment[]>('/api/Assignments/Inactive');
  }
  getAssignment(id: number): Observable<Assignment> {
    return this.http.get<Assignment>('/api/Assignments/' + id);
  }
  createAssignment(assignment: Assignment) {
    return this.http.post('/api/Assignments', assignment);
  }
  deleteAssignment(id: number) {
    return this.http.delete('/api/Assignments/', id);
  }
  setAssignmentToDone(id: number) {
    return this.http.post('/api/Assignments/Done', id);
  }
  updateAssignment(id: number, assignment: Assignment) {
    return this.http.put('/api/Assignments/' + id, assignment);
  }
}
