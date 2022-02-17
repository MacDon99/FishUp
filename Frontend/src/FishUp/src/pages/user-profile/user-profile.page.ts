import { Component, Input, OnInit, EventEmitter, Output } from '@angular/core';
import { ProfileDetails } from '../../models/profile-details';
import { UserPosts } from '../../models/user-posts';
import { HttpService } from '../../services/http-service';

@Component({
  selector: 'user-profile',
  templateUrl: './user-profile.page.html'
})
export class UserProfilePage implements OnInit {

  @Input() userId: string;
  displayProfilePage = true;
  displayCommentDetailsPage = false;
  currentCommentId = '';
  profileDetails: ProfileDetails = new ProfileDetails();
  userPosts: UserPosts = new UserPosts();

  @Output() onGoBackEmit = new EventEmitter();
  constructor(private httpService: HttpService) {
   }

  ngOnInit() {
    this.httpService.getProfileDetails(this.userId).subscribe((profileDetails: ProfileDetails) => {
      this.profileDetails = profileDetails;
      this.httpService.getUserPosts(this.userId).subscribe((userPosts: UserPosts) => {
        this.userPosts = userPosts;
      })
    })
  }

  goToComments(id: string) {
    this.currentCommentId = id;
    this.displayProfilePage = false;
    this.displayCommentDetailsPage = true;
  }

  goBackToSearcher() {
    this.currentCommentId = null;
    this.displayProfilePage = true;
    this.displayCommentDetailsPage = false;
    this.onGoBackEmit.emit();
  }

  goBackToProfilePage() {
    this.currentCommentId = null;
    this.displayProfilePage = true;
    this.displayCommentDetailsPage = false;
  }

  parseJwt (token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));
    return JSON.parse(jsonPayload);
};
}
