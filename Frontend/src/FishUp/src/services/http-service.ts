import { ProfilesForSearcher } from './../models/profiles-for-searcher';
import { PostDetails } from './../models/post-details';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseUrls } from '../models/base-urls';
import { CreateProfile } from '../models/create-profile';
import { ProfileDetails } from '../models/profile-details';
import { ReceivedToken } from '../models/received-token';
import { SignIn } from '../models/sign-in';
import { SignUp } from '../models/sign-up';
import { UserPosts } from '../models/user-posts';
import { AvailableTrips } from '../models/available-trips';

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
  return this.httpClient.post(`${BaseUrls.Profile}/`, model, this.addHeaders());
}

getProfileDetails(userId: string) {
  return this.httpClient.get<ProfileDetails>(`${BaseUrls.Profile}?userId=${userId}`, this.addHeaders());
}

getUserPosts(userId: string) {
  return this.httpClient.get<UserPosts>(`${BaseUrls.Post}/created/${userId}`, this.addHeaders());
}

getPostDetails(postId: string) {
  return this.httpClient.get<PostDetails>(`${BaseUrls.Post}/${postId}`, this.addHeaders());
}

commentPost(postId: string, message: any) {
  console.log(message);
  return this.httpClient.put<UserPosts>(`${BaseUrls.Post}/${postId}/comment`, message, this.addHeaders());
}

getProfilesForSearcher(searchPhrase: string) {
  var params = new HttpParams();
  params.append('searchPhrase', searchPhrase)
  return this.httpClient.get<ProfilesForSearcher>(`${BaseUrls.Profile}/search?searchPhrase=${searchPhrase}`, this.addHeaders(params))
}

getAvailableTrips() {
  return this.httpClient.get<AvailableTrips>(`${BaseUrls.Trip}/available`, this.addHeaders())
}

addFriend(id: string) {
  return this.httpClient.post(`${BaseUrls.Profile}/friend/add`, {
    friendId: id
  }, this.addHeaders())
}

private addHeaders(params = null) {
  return {
    headers: {
      'Authorization': `Bearer ${this.getToken()}`
    },
    params: params
  }
}

private getToken() {
  return localStorage.getItem('token');
}
}
