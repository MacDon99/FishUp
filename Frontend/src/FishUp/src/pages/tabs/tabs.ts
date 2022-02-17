import { Component } from '@angular/core';

import { HomePage } from '../home/home';
import { ProfilePage } from '../profile/profile.page';
import { SearcherPage } from '../searcher/searcher.page';

@Component({
  templateUrl: 'tabs.html'
})
export class TabsPage {

  homeRoot = HomePage;
  searcherRoot = SearcherPage;
  profileRoot = ProfilePage;

  constructor() {

  }
}
