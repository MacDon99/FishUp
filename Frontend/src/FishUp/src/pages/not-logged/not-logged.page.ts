import { Component, OnInit } from '@angular/core';
import { ReceivedToken } from '../../models/received-token';

@Component({
  selector: 'not-logged-page',
  templateUrl: './not-logged.page.html'
})
export class NotLoggedPage implements OnInit {

  displayNotLoggedInPanel = true;
  displayLoginOptions = true;
  displayRegisterPanel = false;
  displaySignInPanel = false;

  constructor() { }

  ngOnInit() {
  }

  showRegisterPage() {
    this.displayLoginOptions = false;
    this.displayRegisterPanel = true;
    this.displaySignInPanel = false;
  }

  showSignInPage() {
    this.displayLoginOptions = false;
    this.displayRegisterPanel = false;
    this.displaySignInPanel = true;
  }

  goBack() {
    this.displayLoginOptions = true;
    this.displayRegisterPanel = false;
    this.displaySignInPanel = false;
  }

  signIn(val: ReceivedToken) {
    localStorage.setItem('token', val.token);
    this.displayLoginOptions = false;
    this.displayRegisterPanel = false;
    this.displaySignInPanel = false;
    this.displayNotLoggedInPanel = false;
  }
}
