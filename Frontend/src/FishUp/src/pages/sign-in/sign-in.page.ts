import { AlertController, Loading, LoadingController } from 'ionic-angular';
import { HttpService } from './../../services/http-service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ReceivedToken } from '../../models/received-token';

@Component({
  selector: 'sign-in-page',
  templateUrl: './sign-in.page.html'
})
export class SignInPage implements OnInit {

  form: FormGroup;
  @Output() onGoBackEmit = new EventEmitter();
  @Output() onSignInEmit = new EventEmitter<ReceivedToken>();
  constructor(private httpService: HttpService, private loadingController: LoadingController, private alertController: AlertController) { }

  ngOnInit() {
    this.form = this.getFormGroup()
  }

  getFormGroup(): FormGroup {
    return new FormGroup({
      usernameOrEmail: new FormControl(),
      password: new FormControl(),
      repeatPassword: new FormControl()
    });
  }

  login() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.signIn(this.form.value).subscribe((next: ReceivedToken) => {
      loader.dismiss();
      this.onSignInEmit.emit(next);
    }, (error) => {
      loader.dismiss();
      const alert = this.alertController.create({
        message: 'Niepoprawne dane logowania.',
        buttons: ['OK']
      });

      alert.present();
    })
  }

  goBack() {
    this.onGoBackEmit.emit();
  }
}
