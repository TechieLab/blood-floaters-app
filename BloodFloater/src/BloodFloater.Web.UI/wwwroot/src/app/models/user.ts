import {Profile, BaseEntity} from './';

export class User {
     Id: number;
     UserName: string;
     Password: string;
     EmailId: string; 
     PhoneNumber: string;    
     Question : string;
     Answer : string;  
     Profile: Profile;

     constructor(){
     
         this.Profile = new Profile();
     } 
}