import { Assignment } from './assignment';

export class Subject {
  id = 0;
  title = '';
  classId = 0;
  class: null;
  assignments: Assignment[];
}
