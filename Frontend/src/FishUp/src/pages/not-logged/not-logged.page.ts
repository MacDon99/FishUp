import { Component, OnInit } from '@angular/core';
import { ReceivedToken } from '../../models/received-token';

@Component({
  selector: 'not-logged-page',
  templateUrl: './not-logged.page.html'
})
export class NotLoggedPage implements OnInit {

  displayNotLoggedInPanel = false;
  displayLoginOptions = true;
  displayRegisterPanel = false;
  displaySignInPanel = false;
  displayCreateProfilePanel = false;

  constructor() { }

  ngOnInit() {
  }

  showRegisterPage() {
    this.displayLoginOptions = false;
    this.displayRegisterPanel = true;
    this.displaySignInPanel = false;
    this.displayCreateProfilePanel = false;
  }

  showSignInPage() {
    this.displayLoginOptions = false;
    this.displayRegisterPanel = false;
    this.displaySignInPanel = true;
    this.displayCreateProfilePanel = false;
  }

  goBack() {
    this.displayLoginOptions = true;
    this.displayRegisterPanel = false;
    this.displaySignInPanel = false;
    this.displayCreateProfilePanel = false;
  }

  signIn(val: ReceivedToken) {
    localStorage.setItem('token', val.token);
    this.displayLoginOptions = false;
    this.displayRegisterPanel = false;
    this.displaySignInPanel = false;
    this.displayNotLoggedInPanel = false;
    this.displayCreateProfilePanel = false;
  }

  signUp(val: ReceivedToken) {
    localStorage.setItem('token', val.token);
    this.displayLoginOptions = false;
    this.displayRegisterPanel = false;
    this.displaySignInPanel = false;
    this.displayCreateProfilePanel = true;
  }

  createProfile() {
    this.displayLoginOptions = false;
    this.displayRegisterPanel = false;
    this.displaySignInPanel = false;
    this.displayNotLoggedInPanel = false;
    this.displayCreateProfilePanel = false;
  }
}
