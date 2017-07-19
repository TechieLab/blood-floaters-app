import { Injectable, Optional } from '@angular/core';
import { Profile } from '../../app/models';
import { IBaseService, BaseService } from '../../app/services/base.service';
import { Http, URLSearchParams } from '@angular/http';

export interface IProfileService extends IBaseService<Profile> { }

@Injectable()
export class ProfileService extends BaseService<Profile> implements IProfileService {  

    constructor(public http: Http){
        super(http, "profiles");
    }      
}