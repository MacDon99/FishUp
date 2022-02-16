import { DateTime } from "ionic-angular";
import { AddedComment } from "./added-comment";

export class PostDetails {
  id: string;
  author: string;
  createdDate: DateTime;
  content: string
  comments : AddedComment[]
}
