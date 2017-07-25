import {Component, Inject, OnInit, ElementRef} from '@angular/core';
import {URLSearchParams} from '@angular/http';
import {Observable} from 'rxjs';
import {StorageService} from '../../app/services/storage.service';
import {
    Events,
    AlertController,
    NavController,
    NavParams,
    ToastController,
    LoadingController
} from 'ionic-angular';
import {Geolocation} from 'ionic-native';
import {SearchPage, RegisterDonorPage} from '../index';
import {DonorService, IDonorService} from '../donor/donor.service';

@Component({selector: 'home-page', templateUrl: 'home.html', entryComponents: []})

export class HomePage implements OnInit {
    private city : string;

    constructor(public navCtrl : NavController, public navParams : NavParams, public events : Events, public toastCtrl : ToastController, private loadingCtrl : LoadingController, public alertCtrl : AlertController, @Inject(DonorService)public donorService : IDonorService,) {}

    ngOnInit() {
        this.getDonorDetails();
    }

    getDonorDetails() {
        this
            .donorService
            .getByProfileId(StorageService.getContext().ProfileId)
            .subscribe((res) => {
                if (res) {} else {
                    this.showConfirm();
                }
            })
    }

    showConfirm() {
        let confirm = this
            .alertCtrl
            .create({
                title: 'Donor Registration',
                message: 'Do you want to register yourself as Donor?',
                buttons: [
                    {
                        text: 'No',
                        handler: () => {
                            //confirm.dismiss();
                        }
                    }, {
                        text: 'Yes',
                        handler: () => {
                            this
                                .navCtrl
                                .push(RegisterDonorPage);
                           // confirm.dismiss();
                        }
                    }
                ]
            });
        confirm.present();
    }

    gotoSearchPage() {
        this
            .navCtrl
            .push(SearchPage);
    }

    gotoRequestBloodPage() {}
}