import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { LoadingController, AlertController, Loading } from 'ionic-angular';
import { HttpService } from '../../services/http-service';

@Component({
  selector: 'add-trip',
  templateUrl: './add-trip.page.html'
})
export class AddTripPage implements OnInit {

  form: FormGroup = this.getFormGroup();
  @Output() onGoBackEmit = new EventEmitter();
  constructor(private httpService: HttpService, private loadingController: LoadingController, private alertController: AlertController) { }

  ngOnInit() {
  }

  getFormGroup(): FormGroup {
    return new FormGroup({
      destination: new FormControl(),
      startDate: new FormControl(),
      endDate: new FormControl()
    });
  }

  addTrip() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.addTrip(this.form.value)
      .subscribe(() => {
        loader.dismiss();
        this.onGoBackEmit.emit();
      }, () => {
        loader.dismiss();
        const alert = this.alertController.create({
          message: 'Nie udało się dodać wyprawy.',
          buttons: ['OK']
        });
        alert.present();
      })
  }

  goBack() {
    this.onGoBackEmit.emit();
  }
}
