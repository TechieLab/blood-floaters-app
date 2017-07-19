import {Component, OnInit, ElementRef, Inject} from '@angular/core';
import {NgForm, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {NavController, MenuController, ViewController, NavParams} from 'ionic-angular';
import {URLSearchParams} from '@angular/http';
import {Lookup, Donor, Profile} from '../../app/models';
import {ILookupService, LookupService} from '../../app/services/lookup.service';
import {PageConstants} from '../../app/common/pageConstants';
import {ProfileService, IProfileService} from '../profile/profile.service';
import {DonorService, IDonorService} from './donor.service';
import {StorageService} from '../../app/services/storage.service';
import {DonorDetailsPage} from './details.page';

@Component({selector: 'register-donor-page', templateUrl: 'register-donor.html', providers: [LookupService]})

export class RegisterDonorPage implements OnInit {
    private rootPage : this;
    private bloodGroups : Array < string >;
    private donor : Donor;
    private countries : Array < Lookup >;
    private states : Array < Lookup >;
    private profile : Profile;
    private successMsg : string = '';

    public registerDonorForm = this
        .builder
        .group({
            FullName: [
                "", Validators.required
            ],
            Age: [
                "", Validators.required
            ],
            Gender: [
                "", Validators.required
            ],
            BloodGroup: [
                "", Validators.required
            ],
            EmailId: [
                "", Validators.required
            ],
            PhoneNumber: [
                "", Validators.required
            ],
            AddressLine1: [""],
            City: [""],
            State: [""],
            Country: [""],
            Zipcode: [""]
        });

    constructor(public builder : FormBuilder, public viewCtrl : ViewController, public navCtrl : NavController, public menu : MenuController, public navParams : NavParams, @Inject(LookupService)public lookupService : ILookupService, @Inject(DonorService)public donorService : IDonorService, @Inject(ProfileService)public profileService : IProfileService) {
        this.bloodGroups = PageConstants.BloodGroups;
    }

    ngOnInit() {
        this.donor = new Donor();
        this.profile = new Profile();

        this.getProfile();
        this.getCountries();
    }

    getProfile() {
        this
            .profileService
            .getById(StorageService.getContext().ProfileId)
            .subscribe((res) => {
                if (res) {
                    this.profile = res;
                }
            });
    }

    getCountries() {
        var params = new URLSearchParams();
        params.set('key', 'country');;
        this
            .lookupService
            .getByQuery(params)
            .subscribe((res) => {
                this.countries = res
            });
    }

    onCountrySelection() {
        this.getStates();
    }

    getStates() {
        var params = new URLSearchParams();
        params.set('key', 'state');
        params.set('value', this.profile.Address.CountryId);

        this
            .lookupService
            .getByQuery(params)
            .subscribe((res) => {
                this.states = res
            });
    }

    resetForm() {
        this.profile = new Profile();
    }

    registerDonor() {

        var data = this.registerDonorForm.value;

        if (data) {
            this.profile.FullName = data.FullName;
            this.profile.Contact.EmailId = data.EmailId;
            this.profile.Contact.PhoneNumber = data.PhoneNumber;
            this.profile.Address.AddressLine1 = data.AddressLine1;
            this.profile.Address.StateId = data.State;
            this.profile.Address.City = data.City;
            this.profile.Address.CountryId = data.Country;
            this.profile.Address.Zipcode = data.ZipCode;
        }

        this
            .profileService
            .put(this.profile)
            .subscribe((res) => {
                if (res) {
                    this.donor.profileId = res.Content.Id;
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

            });
    }
}
