import { LoadingController, AlertController, Loading } from 'ionic-angular';
import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../services/http-service';
import { Friendships } from '../../models/friendships';

@Component({
  selector: 'friends-page',
  templateUrl: './friends.page.html'
})
export class FriendsPage {

  displayFriendsPage = true;
  displayFriendProfilePage = false;
  selectedUserId = '';
  friendships: Friendships = new Friendships();

  constructor(private httpService: HttpService, private loadingController: LoadingController, private alertController: AlertController) { }


  ionViewWillEnter() {
    this.getFriends();
  }

  goToFriendPage(userId: string) {
    this.selectedUserId = userId;
    this.displayFriendsPage = false;
    this.displayFriendProfilePage = true;
  }

  goBackToFriendsPage() {
    this.selectedUserId = '';
    this.displayFriendsPage = true;
    this.displayFriendProfilePage = false;
    this.getFriends();
  }

  getFriends() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.getUserFriends()
      .subscribe((friendships: Friendships) => {
        this.friendships = friendships;
        loader.dismiss();
      }, () => {
        loader.dismiss();
        const alert = this.alertController.create({
          message: 'Wystąpił błąd.',
          buttons: ['OK']
        });

        alert.present();
      });
  }
}
