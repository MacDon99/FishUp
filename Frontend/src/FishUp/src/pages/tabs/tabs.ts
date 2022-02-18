import { Component } from '@angular/core';
import { FriendsPage } from '../friends/friends.page';

import { HomePage } from '../home/home';
import { ProfilePage } from '../profile/profile.page';
import { SearcherPage } from '../searcher/searcher.page';
import { TripsPage } from '../trips/trips.page';

@Component({
  templateUrl: 'tabs.html'
})
export class TabsPage {

  homeRoot = HomePage;
  searcherRoot = SearcherPage;
  tripsRoot = TripsPage;
  friendsRoot = FriendsPage;
  profileRoot = ProfilePage;

  constructor() {

  }
}
