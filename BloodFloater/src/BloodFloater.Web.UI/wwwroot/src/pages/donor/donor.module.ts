import { NgModule, ErrorHandler } from '@angular/core';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { FormsModule } from '@angular/forms';
import {RegisterDonorPage} from '../donor/registerDonor.page';
import {DonorDetailsPage} from '../donor/details.page';
import {ProfileModule} from '../profile/profile.module';
import {ProfilePage} from '../';
import {DonorService} from './donor.service';

@NgModule({
    declarations:[RegisterDonorPage, DonorDetailsPage],    
    exports:[RegisterDonorPage, DonorDetailsPage],
    entryComponents:[RegisterDonorPage,DonorDetailsPage,ProfilePage],
    imports:[IonicModule, FormsModule, ProfileModule],
    providers:[DonorService]
})

export class DonorModule{

}