import { NgModule, ErrorHandler } from '@angular/core';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { FormsModule } from '@angular/forms';
import {RegisterDonorPage} from '../index';

import {DonorService} from './donor.service';

@NgModule({
    declarations:[RegisterDonorPage],    
    exports:[RegisterDonorPage],
    entryComponents:[RegisterDonorPage],
    imports:[IonicModule, FormsModule],
    providers:[DonorService]
})

export class DonorModule{}