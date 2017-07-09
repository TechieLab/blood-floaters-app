import { Component, Inject, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NavController, NavParams } from 'ionic-angular';
import { Profile, User } from '../../app/models';
import { ProfilePage } from './profile.page';
import { UserService, IUserService } from '../../app/services/user.service';
import {StorageService} from '../../app/services/storage.service';

@Component({
  selector: 'edit-profile-page',
  templateUrl: 'editProfile.html',
  providers: [UserService]
})

export class EditProfilePage implements OnInit {
  selectedItem: any;
  editMode: boolean = false;
  profile: Profile;
  user:User;
  userService: IUserService;

  public editProfileForm = this.builder.group({
    FullName: ["", Validators.required],
    EmailId: ["", Validators.required],
    SkypeId: ["", Validators.required],
    PhoneNumber: ["", Validators.required]
  });

  constructor(public builder: FormBuilder, public navCtrl: NavController, public navParams: NavParams,
    @Inject(UserService) userService: IUserService) {
    // If we navigated to this page, we will have an item available as a nav param
    this.selectedItem = navParams.get('item');
    this.userService = userService;

    this.profile = new Profile();
  }

  ngOnInit() {
    this.getProfileProfile();
  }

  editProfile() {
    this.navCtrl.push(EditProfilePage);
  }

  getProfileProfile() {
    this.userService.getById(StorageService.getUserId()).subscribe((result) => {
      if (result) {
        this.profile = result.Profile;
      }
    });
  }

  onSubmitForm() {
    var data = this.editProfileForm.value;

    if (data) {
      this.profile.FullName = data.FullName;
      this.profile.Contact.EmailId = data.EmailId;
      this.profile.Contact.PhoneNumber = data.PhoneNumber;

      this.user.Profile = this.profile;
    }


    this.userService.put(this.user).subscribe((result) => {
      if (result) {      
        this.navCtrl.push(ProfilePage);
      }
    });
  }
}
