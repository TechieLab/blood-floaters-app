import {IBaseService, BaseService} from '../../app/services/base.service'
import {Injectable, Optional} from '@angular/core';
import {Donor} from '../../app/models';
import { Http, URLSearchParams } from '@angular/http';

export interface IDonorService extends IBaseService<Donor> {}

@Injectable()
export class DonorService extends BaseService <Donor> implements IDonorService {
    constructor(public http : Http) {
        super(http, 'donors');
    }
}