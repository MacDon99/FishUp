import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AlertController, Loading, LoadingController } from 'ionic-angular';
import { HttpService } from '../../services/http-service';

@Component({
  selector: 'create-profile',
  templateUrl: './create-profile.page.html'
})
export class CreateProfilePage implements OnInit {
  form: FormGroup;

  @Output() onCreatedProfileEmit = new EventEmitter();
  constructor(private httpService: HttpService, private loadingController: LoadingController, private alertController: AlertController) { }

  ngOnInit() {
    this.form = this.getFormGroup();
  }

  getFormGroup(): FormGroup {
    return new FormGroup({
      city: new FormControl(),
      voivodeship: new FormControl(),
      birthDate: new FormControl(),
      profession: new FormControl(),
      willToTravelFar: new FormControl(false)
    });
  }

  createProfile() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.createProfile(this.form.value).subscribe(() => {
      loader.dismiss();
      this.onCreatedProfileEmit.emit();
    }, (error) => {
      console.log(error);
      loader.dismiss();
      const alert = this.alertController.create({
        message: 'Wprowadzono niepoprawne dane.',
        buttons: ['OK']
      });

      alert.present();
    })
  }
}
