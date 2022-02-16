import { PostDetails } from './../models/post-details';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseUrls } from '../models/base-urls';
import { CreateProfile } from '../models/create-profile';
import { ProfileDetails } from '../models/profile-details';
import { ReceivedToken } from '../models/received-token';
import { SignIn } from '../models/sign-in';
import { SignUp } from '../models/sign-up';
import { UserPosts } from '../models/user-posts';

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

getProfileDetails() {
  return this.httpClient.get<ProfileDetails>(`${BaseUrls.Profile}/`, this.addToken());
}

getUserPosts(userId: string) {
  return this.httpClient.get<UserPosts>(`${BaseUrls.Post}/created/${userId}`, this.addToken());
}

getPostDetails(postId: string) {
  return this.httpClient.get<PostDetails>(`${BaseUrls.Post}/${postId}`, this.addToken());
}

commentPost(postId: string, message: any) {
  console.log(message);
  return this.httpClient.put<UserPosts>(`${BaseUrls.Post}/${postId}/comment`, message, this.addToken());
}

private addToken() {
  return {
    headers: {
      'Authorization': `Bearer ${this.getToken()}`
    }
  }
}

private getToken() {
  return localStorage.getItem('token');
}
}
