import { NgModule, ErrorHandler } from '@angular/core';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { FormsModule } from '@angular/forms';
import {ChangePasswordPage} from '../account/change-password.page';
import {ProfilePage} from './profile.page';
import {EditProfilePage} from './editProfile.page';

@NgModule({
    declarations:[ProfilePage,EditProfilePage],    
    exports:[ProfilePage, EditProfilePage],
    entryComponents:[ProfilePage, EditProfilePage,ChangePasswordPage],
    imports:[IonicModule, FormsModule],
    providers:[]
})

export class ProfileModule{}