import { AvailableTrips } from './../../models/available-trips';
import { HttpService } from './../../services/http-service';
import { FormControl, FormGroup } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { NavController, LoadingController, Loading } from 'ionic-angular';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage implements OnInit {

  availableTrips: AvailableTrips = new AvailableTrips();
  constructor(public navCtrl: NavController, private httpService: HttpService, private loadingController: LoadingController) {

  }

  ngOnInit(): void {
    this.getTrips();
  }

  addTrip() {

  }

  addPost() {

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
