import { ProfileDetails } from './../../models/profile-details';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpService } from '../../services/http-service';
import { UserPosts } from '../../models/user-posts';
import { AccessToken } from '../../models/access-token';

@Component({
  selector: 'profile-page',
  templateUrl: './profile.page.html'
})
export class ProfilePage {

  displayProfilePage = true;
  displayCommentDetailsPage = false;
  currentCommentId = '';
  profileDetails: ProfileDetails = new ProfileDetails();
  userPosts: UserPosts = new UserPosts();
  constructor(private httpService: HttpService) {
   }

  ionViewWillEnter() {
    this.httpService.getProfileDetails(this.getUserId()).subscribe((profileDetails: ProfileDetails) => {
      this.profileDetails = profileDetails;
      this.getPosts();
    })
  }

  getPosts() {
    this.httpService.getUserPosts(this.getUserId()).subscribe((userPosts: UserPosts) => {
      this.userPosts = userPosts;
    })
  }

  getUserId() {
    var token = localStorage.getItem('token');
    var decoded = this.parseJwt(token);
    var x = decoded as AccessToken;
    return x.sub;
  }

  goToComments(id: string) {
    this.currentCommentId = id;
    this.displayProfilePage = false;
    this.displayCommentDetailsPage = true;
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
