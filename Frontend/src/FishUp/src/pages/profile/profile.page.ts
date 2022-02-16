import { ProfileDetails } from './../../models/profile-details';
import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../services/http-service';
import { UserPosts } from '../../models/user-posts';
import jwt_decode from 'jwt-decode';
import { AccessToken } from '../../models/access-token';

@Component({
  selector: 'profile-page',
  templateUrl: './profile.page.html'
})
export class ProfilePage implements OnInit {

  profileDetails: ProfileDetails = new ProfileDetails();
  userPosts: UserPosts = new UserPosts();
  constructor(private httpService: HttpService) {
   }

  ngOnInit() {
    this.getUserId();
    this.httpService.getProfileDetails().subscribe((profileDetails: ProfileDetails) => {
      this.profileDetails = profileDetails;
      this.httpService.getUserPosts(this.getUserId()).subscribe((userPosts: UserPosts) => {
        this.userPosts = userPosts;
      })
    })
  }

  getUserId() {
    var token = localStorage.getItem('token');
    var decoded = jwt_decode<AccessToken>(token);
    return decoded.sub;
  }
}
