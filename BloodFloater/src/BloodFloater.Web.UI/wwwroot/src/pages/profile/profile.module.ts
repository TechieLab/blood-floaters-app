import { NgModule, ErrorHandler } from '@angular/core';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { FormsModule } from '@angular/forms';
import {ProfilePage} from '../profile/profile.page';
import {EditProfilePage} from '../profile/editProfile.page';
import {ChangePasswordPage} from '../account/change-password.page';
import {ProfileService} from './profile.service';

@NgModule({
    declarations:[ProfilePage,EditProfilePage],    
    exports:[ProfilePage, EditProfilePage],
    entryComponents:[ProfilePage, EditProfilePage],
    imports:[IonicModule, FormsModule],
    providers:[ProfileService]
})

export class ProfileModule{}