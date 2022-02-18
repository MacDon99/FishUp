import { Component, Input, OnInit, EventEmitter, Output } from '@angular/core';
import { LoadingController, AlertController, Loading, NavController } from 'ionic-angular';
import { AccessToken } from '../../models/access-token';
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
  currentUserId = '';

  canAddFriend = true;
  canDeleteFriend = false;

  @Output() onGoBackEmit = new EventEmitter();
  constructor(private httpService: HttpService, private loadingController: LoadingController, private alertController: AlertController) {
  }

  ngOnInit() {
    this.getProfileDetails();
  }

  getProfileDetails() {
    this.httpService.getProfileDetails(this.userId).subscribe((profileDetails: ProfileDetails) => {
      this.currentUserId = this.getUserId();
      this.profileDetails = profileDetails;
      this.canAddFriend = this.profileDetails.friendsIds.indexOf(this.currentUserId) == -1;

      this.canDeleteFriend = !(this.currentUserId != this.userId && this.canAddFriend);

      this.httpService.getUserPosts(this.userId).subscribe((userPosts: UserPosts) => {
        this.userPosts = userPosts;
      })
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

  goBack() {
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

  addFriend() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.addFriend(this.userId)
      .subscribe(() => {
        loader.dismiss();
        this.getProfileDetails();
      }, () => {
        loader.dismiss();
        const alert = this.alertController.create({
          message: 'Nie udało się dodać znajomego.',
          buttons: ['OK']
        });

        alert.present();
      })
  }

  deleteFriend() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.deleteFriend(this.userId)
      .subscribe(() => {
        loader.dismiss();
        this.getProfileDetails();
      }, () => {
        loader.dismiss();
        const alert = this.alertController.create({
          message: 'Wprowadzono niepoprawne dane.',
          buttons: ['OK']
        });

        alert.present();
      })
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
