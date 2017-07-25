import {Component, OnInit, ElementRef, Inject} from '@angular/core';
import {NgForm, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {NavController, MenuController, ViewController, NavParams} from 'ionic-angular';
import {URLSearchParams} from '@angular/http';
import {Lookup, Donor, Profile, Contact, Address} from '../../app/models';

import {DonorService, IDonorService} from './donor.service';
import {StorageService} from '../../app/services/storage.service';
import {DonorDetailsPage} from './details.page';
import {EditProfilePage} from '../profile/editProfile.page';

@Component({selector: 'register-donor-page', templateUrl: 'register-donor.html', entryComponents: [EditProfilePage], providers: [DonorService]})

export class RegisterDonorPage implements OnInit {
    private rootPage : this;
    private donor : Donor;
    private profile : Profile;
    private successMsg : string = '';

    constructor(public builder : FormBuilder, public viewCtrl : ViewController, public navCtrl : NavController, public menu : MenuController, public navParams : NavParams, @Inject(DonorService)public donorService : IDonorService) {}

    ngOnInit() {
        this.donor = new Donor();

        this.updateDonor();
    }

    updateDonor() {

        this.donor.ProfileId = StorageService
            .getContext()
            .ProfileId;

        this
            .donorService
            .post(this.donor)
            .subscribe((data) => {
                if (data) {
                    this
                        .navCtrl
                        .push(DonorDetailsPage);
                }
            });
    }

}
