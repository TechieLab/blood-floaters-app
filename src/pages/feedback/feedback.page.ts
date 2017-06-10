import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';

@Component({
  selector: 'feedback-page',
  templateUrl: 'feedback.html',
  entryComponents : []
})
export class FeedbackPage { 
  private feedback : any;
  constructor(public navCtrl: NavController, public navParams: NavParams) {
      this.feedback = {};
  }
}
