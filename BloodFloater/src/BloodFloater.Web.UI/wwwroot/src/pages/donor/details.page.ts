import {Component, OnInit, ElementRef, Inject} from '@angular/core';
import {NgForm, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {NavController, MenuController, ViewController, NavParams} from 'ionic-angular';
import {URLSearchParams} from '@angular/http';
import {Lookup, Donor, Profile} from '../../app/models';
import {PageConstants} from '../../app/common/pageConstants';
import {DonorService, IDonorService} from './donor.service';
import {ProfileService, IProfileService} from '../profile/profile.service';
import {StorageService} from '../../app/services/storage.service';
import{EditProfilePage} from '../';

@Component({selector: 'donor-details-page', templateUrl: 'details.html', providers: []})

export class DonorDetailsPage implements OnInit {
    private profile : Profile;

    constructor( public navCtrl : NavController, @Inject(DonorService)public donorService : IDonorService, 
    @Inject(ProfileService)public profileService : IProfileService){

    }
    
    ngOnInit() {
       
    }   

    updateProfile(){
        this.navCtrl.push(EditProfilePage);       
    }
}