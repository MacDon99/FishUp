import { Component, OnInit } from '@angular/core';
import { LoadingController, Loading } from 'ionic-angular';
import { Trips } from '../../models/trips';
import { HttpService } from '../../services/http-service';

@Component({
  selector: 'trips',
  templateUrl: './trips.page.html'
})
export class TripsPage {

  displayTripsPage = true;
  displayTripDetailsPage = false;
  displayAddTripPage = false;
  currentTripId = '';
  joinedTrips: Trips = new Trips();
  createdTrips: Trips = new Trips();

  constructor(private httpService: HttpService, private loadingController: LoadingController) { }

  ionViewWillEnter() {
    this.getCreatedTrips();
    this.getJoinedTrips();
  }

  getJoinedTrips() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });
    loader.present();

    this.httpService.getJoinedTrips()
    .subscribe((joinedTrips) => {
        loader.dismiss();
        this.joinedTrips = joinedTrips;
      }, () => {
        loader.dismiss();
      })
  }

  getCreatedTrips() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });
    loader.present();

    this.httpService.getCreatedTrips()
    .subscribe((createdTrips) => {
        loader.dismiss();
        this.createdTrips = createdTrips;
      }, () => {
        loader.dismiss();
      })
  }

  moveToAddTripPage() {
    this.displayTripsPage = false;
    this.displayTripDetailsPage = false;
    this.displayAddTripPage = true;
  }

  moveToTripDetailsPage(tripId: string) {
    this.currentTripId = tripId;
    this.displayTripsPage = false;
    this.displayTripDetailsPage = true;
    this.displayAddTripPage = false;
  }

  onGoBackEmit() {
    this.displayTripsPage = true;
    this.displayTripDetailsPage = false;
    this.displayAddTripPage = false;

    this.getCreatedTrips();
    this.getJoinedTrips();
  }

}
