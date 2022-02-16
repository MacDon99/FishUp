import { HttpService } from './../../services/http-service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AlertController, Loading, LoadingController } from 'ionic-angular';

@Component({
  selector: 'sign-up-page',
  templateUrl: './sign-up.page.html'
})
export class SignUpPage implements OnInit {

  form: FormGroup;
  @Output() onGoBackEmit = new EventEmitter();
  @Output() onSignUpEmit = new EventEmitter();
  constructor(private httpService: HttpService, private loadingController: LoadingController, private alertController: AlertController) { }

  ngOnInit() {
    this.form = this.getFormGroup()
  }

  getFormGroup(): FormGroup {
    return new FormGroup({
      username: new FormControl(),
      email: new FormControl(),
      password: new FormControl(),
      firstName: new FormControl(),
      lastName: new FormControl()
    });
  }

  async register() {
    let loader: Loading = await this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.signUp(this.form.value).subscribe((next) => {
      loader.dismiss();
      this.onSignUpEmit.emit(next);
    }, (error) => {
      loader.dismiss();
      const alert = this.alertController.create({
        message: 'Wprowadzono niepoprawne dane.',
        buttons: ['OK']
      });

      alert.present();
    })
  }

  goBack() {
    this.onGoBackEmit.emit();
  }
}

