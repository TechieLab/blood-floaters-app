import 'rxjs/add/operator/toPromise';
import { Component, OnInit, Inject, NgZone } from '@angular/core';
import { ModalController, NavController, NavParams } from 'ionic-angular';
import { Http, Headers, Response, RequestOptions, URLSearchParams, Jsonp } from '@angular/http';
import { FormControl } from '@angular/forms';
import { Subject, Observable } from 'rxjs';

@Component({
  selector: 'search-page',
  templateUrl: 'search.html',
  entryComponents: [],
  providers: []
})

export class SearchPage implements OnInit {
  results: any[];
  search: FormControl;
  params: URLSearchParams;
  seachTextModel: string;
  results$: Subject<Array<any>> = new Subject<Array<any>>();
  message: string = "";
  active: boolean = false;

  constructor(public navCtrl: NavController,
    public navParams: NavParams,
    public modalCtrl: ModalController,
    private _ngZone: NgZone    
  ) {
    // If we navigated to this page, we will have an item available as a nav param
   

    this.search = new FormControl();
    this.params = new URLSearchParams();
  }

  gotoFiltersPage() {
    //this.navCtrl.push(FiltersPage, {});
   
  }

  getByQuery(term: string) {
    //,1 this.params.set('Title', term);
    // return this.es.search(term);
  }

  ngOnInit() {
    //Event for Search item using temporary api
    // this.search.valueChanges.subscribe(term => this.getByQuery(term));

    this.search.valueChanges.subscribe(term => {
      let entity = {
        size: 20,
        from: 0,
        query: {
          match: {
            Title: { query: `${term}`, fuzziness: 2 }
          }
        }
      };
   
    });
  }

  gotoCatalogPage(item: any) {
    console.log(item);
  }

  handleError(): any {
    this.message = "something went wrong";
  }
}
