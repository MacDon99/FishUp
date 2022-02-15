import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseUrls } from '../models/base-urls';
import { CreateProfile } from '../models/create-profile';
import { ReceivedToken } from '../models/received-token';
import { SignIn } from '../models/sign-in';
import { SignUp } from '../models/sign-up';

@Injectable()
export class HttpService {

constructor(private httpClient: HttpClient) {

}

signIn(model: SignIn) {
  return this.httpClient.post<ReceivedToken>(`${BaseUrls.Identity}/sign-in`, model);
}

signUp(model: SignUp) {
  return this.httpClient.post(`${BaseUrls.Identity}/sign-up`, model);
}

createProfile(model: CreateProfile) {
  return this.httpClient.post(`${BaseUrls.Profile}/`, model, this.addToken());
}

private addToken() {
  return {
    headers: {
      'Authorization': `Bearer ${localStorage.getItem('token')}`
    }
  }
}
}
