import { AddTripPage } from './../pages/add-trip/add-trip.page';
import { FriendsPage } from './../pages/friends/friends.page';
import { UserProfilePage } from './../pages/user-profile/user-profile.page';
import { PostDetailsPage } from '../pages/comments/post-details.page';
import { HttpService } from './../services/http-service';
import { SignUpPage } from './../pages/sign-up/sign-up.page';
import { SignInPage } from './../pages/sign-in/sign-in.page';
import { ProfilePage } from '../pages/profile/profile.page';
import { NgModule, ErrorHandler } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { MyApp } from './app.component';

import { HomePage } from '../pages/home/home';
import { TabsPage } from '../pages/tabs/tabs';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { NotLoggedPage } from '../pages/not-logged/not-logged.page';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from  '@angular/common/http';
import { CreateProfilePage } from '../pages/create-profile/create-profile.page';
import { SearcherPage } from '../pages/searcher/searcher.page';
import { AddPostPage } from '../pages/add-post/add-post.page';
import { TripDetailsPage } from '../pages/trip-details/trip-details.page';
import { TripsPage } from '../pages/trips/trips.page';
import { LikesComponent } from '../components/likes/likes.component';

@NgModule({
  declarations: [
    MyApp,
    HomePage,
    TabsPage,
    ProfilePage,
    SignInPage,
    SignUpPage,
    NotLoggedPage,
    CreateProfilePage,
    PostDetailsPage,
    SearcherPage,
    UserProfilePage,
    FriendsPage,
    AddPostPage,
    TripDetailsPage,
    AddTripPage,
    TripsPage,
    LikesComponent
   ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    TabsPage,
    ProfilePage,
    SignInPage,
    SignUpPage,
    NotLoggedPage,
    CreateProfilePage,
    PostDetailsPage,
    SearcherPage,
    UserProfilePage,
    FriendsPage,
    AddPostPage,
    TripDetailsPage,
    AddTripPage,
    TripsPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler},
    HttpService
  ]
})
export class AppModule {

}
