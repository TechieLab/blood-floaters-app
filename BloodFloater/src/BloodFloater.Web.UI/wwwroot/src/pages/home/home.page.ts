import {Component, Inject, OnInit, ElementRef} from '@angular/core';
import {URLSearchParams} from '@angular/http';
import {Observable} from 'rxjs';

import {Events, NavController, NavParams, ToastController, LoadingController} from 'ionic-angular';
import {Geolocation} from 'ionic-native';
import {SearchPage} from '../index';

@Component({selector: 'home-page', templateUrl: 'home.html', entryComponents: []})

export class HomePage implements OnInit {
    private city : string;

    constructor(public navCtrl : NavController, public navParams : NavParams, public events : Events, public toastCtrl : ToastController, private loadingCtrl : LoadingController) {}

    ngOnInit() {}

    gotoSearchPage() {
        this
            .navCtrl
            .push(SearchPage);
    }

    gotoRequestBloodPage() {}
}