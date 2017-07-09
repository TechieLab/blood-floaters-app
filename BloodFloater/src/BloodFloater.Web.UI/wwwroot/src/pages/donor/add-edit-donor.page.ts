import { Component, OnInit, ElementRef , Inject} from '@angular/core';
import { NavController, MenuController, ViewController, NavParams } from 'ionic-angular';
import { Lookup, Donor } from '../../app/models';
import { ILookupService, LookupService } from '../../app/services/lookup.service';

@Component({
    selector: 'add-donor-page',
    templateUrl: 'add-donor.html',
    providers: [LookupService]
})

export class AddEditDonorPage implements OnInit {
    private rootPage: this;
    private bloodGroups: Array<string>;

    constructor(public viewCtrl: ViewController,
        public navCtrl: NavController,
        public menu: MenuController,
        public navParams: NavParams,
        @Inject(LookupService) public lookupService : ILookupService) {
         this.bloodGroups = ['A+','B+', 'O+', 'AB+','A-','B-', 'O-', 'AB-'];
    }

    ngOnInit() {

    }

    resetForm(){
        
    }
}
