import { DateTime } from "ionic-angular";
import { AddedComment } from "./added-comment";

export class PostDetails {
  id: string;
  author: string;
  authorId: string;
  createdDate: DateTime;
  content: string;
  comments : AddedComment[];
  likersIds : string[];
  disLikersIds : string[];
  likesCount: number;
  disLikesCount: number;
}
