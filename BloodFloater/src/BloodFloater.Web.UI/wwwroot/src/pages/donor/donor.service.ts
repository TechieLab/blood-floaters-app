import {IBaseService, BaseService} from '../../app/services/base.service'
import {Injectable, Optional} from '@angular/core';
import {Donor} from '../../app/models';
import { Http, URLSearchParams } from '@angular/http';

export interface IDonorService extends IBaseService<Donor> {
    getByProfileId(id : number);
}

@Injectable()
export class DonorService extends BaseService <Donor> implements IDonorService {
    constructor(public http : Http) {
        super(http, 'donors');
    }

    getByProfileId(id: number){
        var params = new URLSearchParams();
        params.set('profileId', id.toString());
        return this.getByQuery(params);
    }
}