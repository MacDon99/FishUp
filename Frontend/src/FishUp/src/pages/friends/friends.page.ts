import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'friends-page',
  templateUrl: './friends.page.html'
})
export class FriendsPage implements OnInit {

  displayFriendsPage = true;
  displayFriendProfilePage = false;
  selectedUserId = '';

  constructor() { }

  ngOnInit() {
  }

}
