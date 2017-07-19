import {Component, OnInit, ElementRef, Inject} from '@angular/core';
import {NgForm, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {NavController, MenuController, ViewController, NavParams} from 'ionic-angular';
import {URLSearchParams} from '@angular/http';
import {Lookup, Donor, Profile} from '../../app/models';
import {PageConstants} from '../../app/common/pageConstants';
import {DonorService, IDonorService} from './donor.service';
import {ProfileService, IProfileService} from '../profile/profile.service';
import {StorageService} from '../../app/services/storage.service';

@Component({selector: 'add-edit-donor-page', templateUrl: 'add-edit-donor.html', providers: []})

export class DonorDetailsPage implements OnInit {
    private profile : Profile;
    constructor( @Inject(DonorService)public donorService : IDonorService, 
    @Inject(ProfileService)public profileService : IProfileService){

    }

    ngOnInit() {
       this.getProfile();
    }

    getProfile() {
        this
            .profileService
            .getById(StorageService.getUserId())
            .subscribe((res) => {
                if (res) {
                    this.profile = res;
                }
            });
    }
}