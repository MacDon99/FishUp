import { LoadingController, AlertController, Loading } from 'ionic-angular';
import { HttpService } from './../../services/http-service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ProfilesForSearcher } from '../../models/profiles-for-searcher';

@Component({
  selector: 'searcher',
  templateUrl: './searcher.page.html'
})
export class SearcherPage implements OnInit {

  displaySearcher = true;
  displayUserProfile = false;
  userId = '';
  form: FormGroup = this.getFormGroup();
  searchedProfiles: ProfilesForSearcher = new ProfilesForSearcher();
  constructor(private httpService: HttpService, private loadingController: LoadingController, private alertController: AlertController) { }

  ngOnInit() {
  }

  getFormGroup(): FormGroup {
    return new FormGroup({
      searchPhrase: new FormControl(),
    });
  }

  searchFriend() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.getProfilesForSearcher(this.form.controls.searchPhrase.value)
      .subscribe((searchedProfiles) => {
        loader.dismiss();
        this.searchedProfiles = searchedProfiles;
      }, () => {
        loader.dismiss();
        const alert = this.alertController.create({
          message: 'Wystąpił błąd.',
          buttons: ['OK']
        });

        alert.present();
      })
  }

  showUserProfile(userId: string) {
    this.userId = userId;
    this.displaySearcher = false;
    this.displayUserProfile = true;
  }

  showSearcher() {
    this.userId = '';
    this.displaySearcher = true;
    this.displayUserProfile = false;
  }
}
