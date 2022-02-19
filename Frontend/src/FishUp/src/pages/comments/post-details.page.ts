import { Loading, LoadingController, AlertController } from 'ionic-angular';
import { HttpService } from '../../services/http-service';
import { Component, OnInit, Input, AfterViewInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { PostDetails } from '../../models/post-details';
import { AccessToken } from '../../models/access-token';

@Component({
  selector: 'post-details-page',
  templateUrl: './post-details.page.html'
})
export class PostDetailsPage implements OnInit, AfterViewInit {

  @Input() commentId: string;
  @Output() onGoBackEmit = new EventEmitter();
  postDetails: PostDetails = new PostDetails();
  form: FormGroup = this.getFormGroup();
  liked = false;
  disLiked = false;
  likesCount = 0;
  disLikesCount = 0;
  currentUserId = '';
  canDeletePost = false;
  constructor(private httpService: HttpService, private loadingController: LoadingController, private alertController: AlertController) { }

  ngOnInit() {
    this.getPostDetails();
    this.currentUserId = this.getUserId();
  }

  ngAfterViewInit() {
  }

  goBack() {
    this.onGoBackEmit.emit();
  }

  addComment() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.commentPost(this.commentId, this.form.value)
      .subscribe(() => {
        loader.dismiss();
        this.getPostDetails();
      }, () => {
        loader.dismiss();
        const alert = this.alertController.create({
          message: 'Wystąpił błąd podczas dodawania komentarza.',
          buttons: ['OK']
        });

        alert.present();
      });
  }

  getFormGroup(): FormGroup {
    return new FormGroup({
      message: new FormControl(),
    });
  }

  getPostDetails() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.getPostDetails(this.commentId)
    .subscribe((postDetails) => {
      loader.dismiss();
      this.postDetails = postDetails;
      this.likesCount = this.postDetails.likesCount;
      this.disLikesCount = this.postDetails.disLikesCount;
      this.liked = this.postDetails.likersIds.find(likerId => likerId == this.currentUserId) != null;
      this.disLiked = this.postDetails.disLikersIds.find(disLikerId => disLikerId == this.currentUserId) != null;
      this.canDeletePost = this.postDetails.authorId == this.currentUserId;
    }, () => {
      loader.dismiss();
      const alert = this.alertController.create({
        message: 'Wystąpił błąd podczas ładowania postu.',
        buttons: ['OK']
      });

      alert.present();
    })
  }

  deletePost() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.deletePost(this.postDetails.id)
    .subscribe(() => {
      loader.dismiss();
      this.onGoBackEmit.emit();
    }, () => {
      loader.dismiss();
      const alert = this.alertController.create({
        message: 'Wystąpił błąd podczas usuwania postu.',
        buttons: ['OK']
      });

      alert.present();
    })
  }

  getUserId() {
    var token = localStorage.getItem('token');
    var decoded = this.parseJwt(token);
    var x = decoded as AccessToken;
    return x.sub;
  }

  parseJwt (token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));
    return JSON.parse(jsonPayload);
};
}

