import { Component, Inject } from '@angular/core';
import { NavController, Events, ModalController, NavParams } from 'ionic-angular';
import { Geolocation } from 'ionic-native';

import { NotificationPage } from '../../../pages/notification/notification.page';
import { SearchPage } from '../../../pages/search/search.page';
import { VendorService } from '../../services/vendor.service';
import { AuthGuard, IAuthGuard } from '../../services/guard.service';
import { AccountService, IAccountService } from '../../../pages/account/account.service';

@Component({
    selector: 'header-component',
    templateUrl: 'header.html',
    entryComponents: [SearchPage],
    providers: [VendorService,AuthGuard,AccountService]
})

export class HeaderComponent {
    private items: Array<any>;
    private city: String;
    private isUserAuthenticated: boolean = false;

    constructor(public navCtrl: NavController,
        public modalCtrl: ModalController,
        public navParams: NavParams,
        public events: Events,
        @Inject(AuthGuard) public authGuard: IAuthGuard,
        @Inject(AccountService) public accountService: IAccountService,
        public service: VendorService) {       
    }

    ngOnInit() {
        Geolocation.getCurrentPosition().then((resp) => {
            this.service.getCity(resp).subscribe((res: any) => {
                this.city = JSON.parse(res._body)['results']['0']['address_components']['4']['long_name'];
            });
        }).catch((error) => {
            console.log('Error getting Location', error)
        });

        this.isUserAuthenticated = this.authGuard.canActivate();

    }  

    gotoNotificationPage() {
        this.navCtrl.push(NotificationPage, {
            id: "123",
            name: "Carl"
        });
    }

    gotoSearchPage() {
        this.navCtrl.setRoot(SearchPage, { category: 'POST FOR FREE' });
    }    
}