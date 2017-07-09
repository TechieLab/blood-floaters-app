import { Injectable } from '@angular/core';
import { NavController } from 'ionic-angular';
import { Router, CanActivate } from '@angular/router';
import { LoginPage } from './../../pages/account/login.page';
import {StorageService} from './storage.service';

export interface IAuthGuard  {
    canActivate();
}

@Injectable()
export class AuthGuard implements IAuthGuard {

    constructor() { }

    public canActivate() {
        if (this.checkLogin()) {
            return true;
        } else {           
            return false;
        }
    }

     public checkLogin(): boolean {
        let token = StorageService.getToken();
        return token != null;
    }
}

