import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { LoadingController, AlertController, Loading } from 'ionic-angular';
import { AccessToken } from '../../models/access-token';
import { TripDetails } from '../../models/trip-details';
import { HttpService } from '../../services/http-service';

@Component({
  selector: 'trip-details',
  templateUrl: './trip-details.page.html'
})
export class TripDetailsPage implements OnInit {

  @Output() onGoBackEmit = new EventEmitter();
  @Input() tripId: string;
  form: FormGroup = this.getFormGroup();
  tripDetails: TripDetails = new TripDetails();
  canJoinTrip = false;
  canLeaveTrip = false;
  canDeleteTrip = false;
  currentUserId = '';
  constructor(private httpService: HttpService, private loadingController: LoadingController, private alertController: AlertController) { }

  ngOnInit() {
    this.getTripDetails();
    this.currentUserId = this.getUserId();
  }

  getUserId() {
    var token = localStorage.getItem('token');
    var decoded = this.parseJwt(token);
    var x = decoded as AccessToken;
    return x.sub;
  }

  getFormGroup(): FormGroup {
    return new FormGroup({
      message: new FormControl(),
    });
  }

  goBack() {
    this.onGoBackEmit.emit();
  }

  ionViewWillEnter() {
    this.getTripDetails();
  }

  getTripDetails() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.getTripDetails(this.tripId)
    .subscribe((tripDetails) => {
      loader.dismiss();
      this.tripDetails = tripDetails;
      this.canDeleteTrip = this.currentUserId == this.tripDetails.authorId;
      this.canJoinTrip = this.tripDetails.authorId != this.currentUserId && this.tripDetails.participants.find(x => x.participantUserId == this.currentUserId) == null;
      this.canLeaveTrip = this.tripDetails.authorId != this.currentUserId && this.tripDetails.participants.find(x => x.participantUserId == this.currentUserId) != null;
    }, () => {
      loader.dismiss();
      const alert = this.alertController.create({
        message: 'Wystąpił błąd podczas ładowania wyprawy.',
        buttons: ['OK']
      });

      alert.present();
    })
  }

  addComment() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.commentTrip(this.tripId, this.form.value)
      .subscribe(() => {
        loader.dismiss();
        this.getTripDetails();
      }, () => {
        loader.dismiss();
        const alert = this.alertController.create({
          message: 'Wystąpił błąd podczas dodawania komentarza.',
          buttons: ['OK']
        });

        alert.present();
      });
  }

  joinTrip() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.participateTrip(this.tripId)
    .subscribe(() => {
      loader.dismiss();
      this.getTripDetails();
    }, () => {
      loader.dismiss();
      const alert = this.alertController.create({
        message: 'Wystąpił błąd podczas dołączania do wyprawy.',
        buttons: ['OK']
      });

      alert.present();
    })
  }

  leaveTrip() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.leaveTrip(this.tripId)
    .subscribe(() => {
      loader.dismiss();
      this.getTripDetails();
    }, () => {
      loader.dismiss();
      const alert = this.alertController.create({
        message: 'Wystąpił błąd podczas odejścia od wyprawy.',
        buttons: ['OK']
      });

      alert.present();
    })
  }

  deleteTrip() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.deleteTrip(this.tripId)
    .subscribe(() => {
      loader.dismiss();
      this.onGoBackEmit.emit();
    }, () => {
      loader.dismiss();
      const alert = this.alertController.create({
        message: 'Wystąpił błąd podczas usuwania wyprawy.',
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
  }
}
