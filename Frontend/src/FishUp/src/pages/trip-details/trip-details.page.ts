import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { LoadingController, AlertController, Loading } from 'ionic-angular';
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
  constructor(private httpService: HttpService, private loadingController: LoadingController, private alertController: AlertController) { }

  ngOnInit() {
    this.getTripDetails();
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
}
