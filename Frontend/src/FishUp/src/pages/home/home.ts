import { AvailableTrips } from './../../models/available-trips';
import { HttpService } from './../../services/http-service';
import { FormControl, FormGroup } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { NavController, LoadingController, Loading } from 'ionic-angular';
import { RecentPosts } from '../../models/recent-posts';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage implements OnInit {

  availableTrips: AvailableTrips = new AvailableTrips();
  recentPosts : RecentPosts = new RecentPosts();;
  displayHomePage = true;
  displayAddPostPage = false;
  displayPostDetailsPage = false;
  displayTripDetailsPage = false;
  currentCommentId = '';
  currentTripId = '';

  constructor(public navCtrl: NavController, private httpService: HttpService, private loadingController: LoadingController) {

  }

  ngOnInit(): void {
    this.getTrips();
    this.getPosts();
  }

  moveToAddTripPage() {

  }

  moveToAddPostPage() {
    this.displayHomePage = false;
    this.displayAddPostPage = true;
    this.displayTripDetailsPage = false;
    this.displayPostDetailsPage = false;
  }

  moveToTripDetailsPage(tripId: string) {
    this.currentTripId = tripId;

    this.displayHomePage = false;
    this.displayAddPostPage = false;
    this.displayTripDetailsPage = true;
    this.displayPostDetailsPage = false;
  }

  moveToPostDetailsPage(postId: string) {
    this.currentCommentId = postId;

    this.displayHomePage = false;
    this.displayAddPostPage = false;
    this.displayTripDetailsPage = false;
    this.displayPostDetailsPage = true;
  }

  onGoBackEmit() {
    this.displayHomePage = true;
    this.displayAddPostPage = false;
    this.displayTripDetailsPage = false;
    this.displayPostDetailsPage = false;
  }

  onAddedPostEmit() {
    this.displayHomePage = true;
    this.displayAddPostPage = false;
    this.displayTripDetailsPage = false;
    this.displayPostDetailsPage = false;
    this.getPosts();
  }

  ionViewWillEnter() {
    this.getPosts();
    this.getTrips();
  }

  getPosts() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });
    loader.present();

    this.httpService.getRecentPosts()
    .subscribe((recentPosts) => {
        loader.dismiss();
        this.recentPosts = recentPosts;
      }, () => {
        loader.dismiss();
      })
  }

  getTrips() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });
    loader.present();

    this.httpService.getAvailableTrips()
    .subscribe((availableTrips) => {
        loader.dismiss();
        this.availableTrips = availableTrips;
      }, () => {
        loader.dismiss();
      })
  }
}
