import {Component, Inject, OnInit} from '@angular/core';
import {NgForm, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {NavController, NavParams, LoadingController, ToastController} from 'ionic-angular';
import {Lookup, Donor, Profile, Contact, Address} from '../../app/models';
import {ProfilePage} from './profile.page';
import {UserService, IUserService, StorageService, ILookupService, LookupService} from '../../app/services';
import {ProfileService, IProfileService} from '../profile/profile.service';
import {URLSearchParams} from '@angular/http';
import {PageConstants} from '../../app/common/pageConstants';

@Component({selector: 'edit-profile-page', templateUrl: 'edit-profile.html', providers: []})

export class EditProfilePage implements OnInit {
  private selectedItem : any;
  private editMode : boolean = false;
  private profile : Profile;
  private countries : Array < Lookup >;
  private states : Array < Lookup >;
  private bloodGroups : Array < string >;

  public editProfileForm = this
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

  constructor(public builder : FormBuilder, public navCtrl : NavController, public navParams : NavParams, @Inject(ProfileService)public profileService : IProfileService, @Inject(LookupService)public lookupService : ILookupService, public toastCtrl : ToastController, public loadingCtrl : LoadingController) {

    this.selectedItem = navParams.get('item');

    this.profile = new Profile();
  }

  ngOnInit() {
    this.bloodGroups = PageConstants.BloodGroups;

    this.getProfile();
    this.getCountries();
  }

  editProfile() {
    this
      .navCtrl
      .push(EditProfilePage);
  }

  getProfile() {
    this
      .profileService
      .getById(StorageService.getContext().ProfileId)
      .subscribe((res) => {
        if (res) {
          this.profile = res;
          if (!this.profile.Contact) {
            this.profile.Contact = new Contact();
            this.profile.Contact.ProfileId = StorageService
              .getContext()
              .ProfileId;
            this.profile.Contact.EmailId = StorageService
              .getContext()
              .EmailId;
            this.profile.Contact.PhoneNumber = StorageService
              .getContext()
              .PhoneNumber;             
          }

          if (!this.profile.Address) {
            this.profile.Address = new Address();
            this.profile.Address.ProfileId = StorageService
              .getContext()
              .ProfileId;
          }
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

  onCountryChange(country) {
    var params = new URLSearchParams();
    params.set('key', 'state');
    if (country) {
      params.set('value', country.Value);
      this
        .lookupService
        .getByQuery(params)
        .subscribe((res) => {
          this.states = res
        });
    }
  }

  resetForm() {
    this.profile = new Profile();
  }

  saveProfile() {

    var data = this.editProfileForm.value;

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
          this.presentToast("Profile saved succesfully");
          this
            .navCtrl
            .push(ProfilePage);
        }
      });
  }

  private presentToast(text) {
    let toast = this
      .toastCtrl
      .create({message: text, duration: 3000, position: 'middle'});
    toast.present();
  }
}
