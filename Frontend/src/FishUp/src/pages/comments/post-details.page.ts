import { Loading, LoadingController, AlertController } from 'ionic-angular';
import { HttpService } from '../../services/http-service';
import { Component, OnInit, Input, AfterViewInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { PostDetails } from '../../models/post-details';

@Component({
  selector: 'post-details-page',
  templateUrl: './post-details.page.html'
})
export class PostDetailsPage implements OnInit, AfterViewInit {

  @Input() commentId: string;
  @Output() onGoBackEmit = new EventEmitter();
  postDetails: PostDetails = new PostDetails();
  form: FormGroup = this.getFormGroup();
  constructor(private httpService: HttpService, private loadingController: LoadingController, private alertController: AlertController) { }

  ngOnInit() {
    this.getPostDetails();
    console.log(this.commentId);
  }

  ngAfterViewInit() {
    console.log(this.commentId);
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
    }, () => {
      loader.dismiss();
      const alert = this.alertController.create({
        message: 'Wystąpił błąd podczas ładowania postu.',
        buttons: ['OK']
      });

      alert.present();
    })
  }
}

