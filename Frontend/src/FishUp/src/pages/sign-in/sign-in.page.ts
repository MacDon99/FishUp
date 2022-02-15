import { Loading, LoadingController } from 'ionic-angular';
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
  constructor(private httpService: HttpService, private loadingController: LoadingController) { }

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

  async login() {
    let loader: Loading = await this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 500000
    });

    this.httpService.signIn(this.form.value).subscribe((next: ReceivedToken) => {
      loader.dismiss();
      this.onSignInEmit.emit(next);
    }, (error) => {
      loader.dismiss();
    })
  }

  goBack() {
    this.onGoBackEmit.emit();
  }
}
