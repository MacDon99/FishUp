import { LoadingController, AlertController, Loading } from 'ionic-angular';
import { HttpService } from './../../services/http-service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'add-post',
  templateUrl: './add-post.page.html'
})
export class AddPostPage implements OnInit {

  form: FormGroup = this.getFormGroup();
  @Output() onAddedPostEmit = new EventEmitter();
  constructor(private httpService: HttpService, private loadingController: LoadingController, private alertController: AlertController) { }

  ngOnInit() {
  }

  getFormGroup(): FormGroup {
    return new FormGroup({
      message: new FormControl()
    });
  }

  addPost() {
    let loader: Loading = this.loadingController.create({
      content: 'Proszę czekać...',
      duration: 60000
    });

    loader.present();

    this.httpService.addPost(this.form.value)
      .subscribe(() => {
        loader.dismiss();
        this.onAddedPostEmit.emit();
      }, () => {
        loader.dismiss();
        const alert = this.alertController.create({
          message: 'Nie udało się dodać postu.',
          buttons: ['OK']
        });
        alert.present();
      })
  }

}
