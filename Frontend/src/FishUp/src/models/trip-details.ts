import { AddedComment } from './added-comment';
import { DateTime } from 'ionic-angular';
import { JoinedParticipant } from './joined-participant';

export class TripDetails {
  id: string;
  destination: string;
  authorId: string;
  authorName: string;
  startDate: DateTime;
  endDate: DateTime;
  closed: boolean;
  comments: AddedComment[];
  participants: JoinedParticipant[];
}
