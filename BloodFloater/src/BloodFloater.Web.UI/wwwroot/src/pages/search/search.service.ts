
import { Injectable, Optional } from '@angular/core';
import { Http, Headers, Response, RequestOptions, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { ChangePassword } from '../../app/models/login';
import { User } from '../../app/models/user';
import { StorageService } from '../../app/services/storage.service';
import { Constants } from '../../app/common/constants';
import { Login, SignUp } from '../../app/models/login';

export interface ISearchService {
    findDonor(searchCriteria);    
}

@Injectable()
export class SearchService implements ISearchService {

    url: string;
    options: RequestOptions;
    token: string;

    constructor(public http: Http) {
        this.url = Constants.SearchApi;
        let headers = new Headers({ 'Content-Type': 'application/json' });
        this.options = new RequestOptions({
            headers: headers
        });
    }

    findDonor(searchCriteria: any) { 
        return this.http.post(this.url, searchCriteria, this.options)
            .map(this.extractData).catch(this.handleError);
    }   

    private extractData(res: Response) {
        let body = res.json();
        return body.data || body;
    }

    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';

        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }

}
