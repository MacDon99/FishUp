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
import { Trips } from '../models/trips';
import { Friendships } from '../models/friendships';
import { RecentPosts } from '../models/recent-posts';
import { TripDetails } from '../models/trip-details';

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
  return this.httpClient.put<UserPosts>(`${BaseUrls.Post}/${postId}/comment`, message, this.addHeaders());
}

getProfilesForSearcher(searchPhrase: string) {
  var params = new HttpParams();
  params.append('searchPhrase', searchPhrase)
  return this.httpClient.get<ProfilesForSearcher>(`${BaseUrls.Profile}/search?searchPhrase=${searchPhrase}`, this.addHeaders(params))
}

getAvailableTrips() {
  return this.httpClient.get<Trips>(`${BaseUrls.Trip}/available`, this.addHeaders())
}

getJoinedTrips() {
  return this.httpClient.get<Trips>(`${BaseUrls.Trip}/joined`, this.addHeaders())
}

getCreatedTrips() {
  return this.httpClient.get<Trips>(`${BaseUrls.Trip}/created`, this.addHeaders())
}

addFriend(id: string) {
  return this.httpClient.post(`${BaseUrls.Profile}/friend/add`, {
    friendId: id
  }, this.addHeaders())
}

deleteFriend(id: string) {
  return this.httpClient.delete(`${BaseUrls.Profile}/friend/remove`, this.addHeaders(null, {
    friendId: id
  }))
}

getUserFriends() {
  return this.httpClient.get<Friendships>(`${BaseUrls.Profile}/friend`, this.addHeaders())
}

getRecentPosts() {
  return this.httpClient.get<RecentPosts>(`${BaseUrls.Post}`, this.addHeaders())
}

addPost(message: string) {
  return this.httpClient.post(`${BaseUrls.Post}`, message, this.addHeaders())
}

getTripDetails(tripId: string) {
  return this.httpClient.get<TripDetails>(`${BaseUrls.Trip}/${tripId}`, this.addHeaders());
}

commentTrip(tripId: string, message: any) {
  return this.httpClient.put<UserPosts>(`${BaseUrls.Trip}/${tripId}/comment`, message, this.addHeaders());
}

addTrip(value: any) {
  return this.httpClient.post(`${BaseUrls.Trip}`, value, this.addHeaders())
}

participateTrip(tripId: string) {
  return this.httpClient.put(`${BaseUrls.Trip}/${tripId}/participate`, {}, this.addHeaders())
}

leaveTrip(tripId: string) {
  return this.httpClient.put(`${BaseUrls.Trip}/${tripId}/leave`, {}, this.addHeaders())
}

deleteTrip(tripId: string) {
  return this.httpClient.delete(`${BaseUrls.Trip}/${tripId}/delete`, this.addHeaders())
}

like(what: string, whatId: string) {
  let baseUrl = '';
  if(what == 'post') {
    baseUrl = BaseUrls.Post;
  } else {
    baseUrl = BaseUrls.Trip;
  }
  return this.httpClient.put(`${baseUrl}/${whatId}/like`, {}, this.addHeaders())
}

unLike(what: string, whatId: string) {
  let baseUrl = '';
  if(what == 'post') {
    baseUrl = BaseUrls.Post;
  } else {
    baseUrl = BaseUrls.Trip;
  }
  return this.httpClient.put(`${baseUrl}/${whatId}/unLike`, {}, this.addHeaders())
}

disLike(what: string, whatId: string) {
  let baseUrl = '';
  if(what == 'post') {
    baseUrl = BaseUrls.Post;
  } else {
    baseUrl = BaseUrls.Trip;
  }
  return this.httpClient.put(`${baseUrl}/${whatId}/disLike`, {}, this.addHeaders())
}

unDisLike(what: string, whatId: string) {
  let baseUrl = '';
  if(what == 'post') {
    baseUrl = BaseUrls.Post;
  } else {
    baseUrl = BaseUrls.Trip;
  }
  return this.httpClient.put(`${baseUrl}/${whatId}/unDisLike`, {}, this.addHeaders())
}

deletePost(postId: string) {
  return this.httpClient.delete(`${BaseUrls.Post}/${postId}/delete`, this.addHeaders())
}

private addHeaders(params = null, body = null) {
  return {
    headers: {
      'Authorization': `Bearer ${this.getToken()}`
    },
    params: params,
    body: body
  }
}

private getToken() {
  return localStorage.getItem('token');
}
}
