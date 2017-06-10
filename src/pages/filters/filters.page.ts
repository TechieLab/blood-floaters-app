import { Component, OnInit, ElementRef , Inject} from '@angular/core';
import { NavController, MenuController, ViewController, NavParams } from 'ionic-angular';
import { Filters } from '../../app/models/filters';
import { Lookup } from '../../app/models/lookup';
import { ILookupService, LookupService } from '../../app/services/lookup.service';

@Component({
    selector: 'filters-page',
    templateUrl: 'filters.html',
    providers: [LookupService]
})

export class FiltersPage implements OnInit {
    private filters: Filters;
    private rootPage: this;

    constructor(public viewCtrl: ViewController,
        public navCtrl: NavController,
        public menu: MenuController,
        public navParams: NavParams,
        @Inject(LookupService) public lookupService : ILookupService) {


    }

    ngOnInit() {
        this.filters = <Filters>{};
    }

    clearFilters() {
        this.filters = <Filters>{};
    }
}
