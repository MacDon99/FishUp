import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { BaseUrls } from '../models/base-urls';
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
}
