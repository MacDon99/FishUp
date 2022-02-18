import { AddedComment } from './added-comment';
import { DateTime } from 'ionic-angular';

export class TripDetails {
  id: string;
  destination: string;
  authorId: string;
  authorName: string;
  startDate: DateTime;
  endDate: DateTime;
  closed: boolean;
  comments: AddedComment[];
}
