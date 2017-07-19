import {Profile} from './profile';

export class User {
     UserName: string;
     Password: string;
     EmailId: string; 
     PhoneNumber: string;    
     Question : string;
     Answer : string;
     Profile : Profile;   

     constructor(){
         this.Profile = new Profile();
     } 
}