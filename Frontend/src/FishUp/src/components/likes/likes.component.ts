import { AlertController } from 'ionic-angular';
import { HttpService } from './../../services/http-service';
import { Component, Input, OnInit, Output, EventEmitter, AfterViewInit } from '@angular/core';

@Component({
  selector: 'likes',
  templateUrl: './likes.component.html'
})
export class LikesComponent implements OnInit, AfterViewInit {

  @Input() liked = false;
  @Input() disLiked = false;
  @Input() what = '';
  @Input() whatId = '';
  @Input() likes = 0;
  @Input() disLikes = 0;

  constructor(private httpService: HttpService, private alertController: AlertController) { }
  ngAfterViewInit(): void {
    console.log(this.what);
  }

  ngOnInit() {
    console.log(this.what);
    console.log(this.whatId);
  }

  like() {
    this.liked = true;
    this.likes += 1;
    this.httpService.like(this.what, this.whatId)
    .subscribe(() => {
    }, () => {
      this.liked = false;
      this.likes -= 1;
      const alert = this.alertController.create({
        message: 'Wystąpił błąd podczas ładowania postu.',
        buttons: ['OK']
      });

      alert.present();
    })
  }

  unLike() {
    this.liked = false;
    this.likes -= 1;
    this.httpService.unLike(this.what, this.whatId)
    .subscribe(() => {
    }, () => {
      this.liked = true;
      this.likes += 1;
      const alert = this.alertController.create({
        message: 'Wystąpił błąd podczas ładowania postu.',
        buttons: ['OK']
      });

      alert.present();
    })
  }

  disLike() {
    this.disLiked = true;
    this.disLikes += 1;
    this.httpService.disLike(this.what, this.whatId)
    .subscribe(() => {
    }, () => {
      this.disLiked = false;
      this.disLikes -= 1;
      const alert = this.alertController.create({
        message: 'Wystąpił błąd podczas ładowania postu.',
        buttons: ['OK']
      });

      alert.present();
    })
  }

  unDisLike() {
    this.disLiked = false;
    this.disLikes -= 1;
    this.httpService.unDisLike(this.what, this.whatId)
    .subscribe(() => {
    }, () => {
      this.disLiked = true;
      this.disLikes += 1;
      const alert = this.alertController.create({
        message: 'Wystąpił błąd podczas ładowania postu.',
        buttons: ['OK']
      });

      alert.present();
    })
  }
}
