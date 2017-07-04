import 'rxjs/add/operator/toPromise';
import { Component, OnInit, Inject, NgZone } from '@angular/core';
import { NgForm, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalController, NavController, NavParams } from 'ionic-angular';
import { Http, Headers, Response, RequestOptions, URLSearchParams, Jsonp } from '@angular/http';
import { Subject, Observable } from 'rxjs';
import {ISearchService, SearchService} from './search.service';

@Component({
  selector: 'search-page',
  templateUrl: 'search.html',
  entryComponents: [],
  providers: [SearchService]
})

export class SearchPage implements OnInit {
  donorList: any[];
  bloodGroups : any[];
  params: URLSearchParams;
  active: boolean = false;
  criteria : any;

  constructor(public builder: FormBuilder, public navCtrl: NavController,
    public navParams: NavParams,
    public modalCtrl: ModalController,
    private _ngZone: NgZone,
     @Inject(SearchService) public searchService : ISearchService
  ) {
    // If we navigated to this page, we will have an item available as a nav param
     
    this.params = new URLSearchParams();
  }  

  ngOnInit() {
    //Event for Search item using temporary api
    // this.search.valueChanges.subscribe(term => this.getByQuery(term));
    this.criteria = {};
    this.bloodGroups = ['A+','B+', 'O+', 'AB+','A-','B-', 'O-', 'AB-'];
  
  }

  gotoCatalogPage(item: any) {
    console.log(item);
  }

  searchDonor(): any {
    this.searchService.findDonor(this.criteria).subscribe((res)=> {
      this.donorList = res;
    });
  }
}
