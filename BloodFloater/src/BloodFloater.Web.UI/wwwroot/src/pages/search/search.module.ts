import { NgModule, ErrorHandler, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { FormsModule } from '@angular/forms';
import { ModalController, NavController, NavParams } from 'ionic-angular';
import { FormControl } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import {SearchPage} from './search.page';
import {ISearchService, SearchService} from './search.service'

@NgModule({
    declarations:[SearchPage],    
    exports:[SearchPage],
    imports:[IonicModule, FormsModule, ReactiveFormsModule],
    providers:[SearchService],
    entryComponents: []
})

export class SearchModule{}