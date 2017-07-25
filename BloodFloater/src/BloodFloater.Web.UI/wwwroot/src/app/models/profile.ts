
import {Address, Contact,Media, BaseEntity} from './';

export class Profile
{   
     Id : number;
     FullName: string;
     Age : number;
     Gender: string;  
     BloodGroup : string;
     Address : Address;
     Contact:  Contact;   
     Photos : Array<Media>;    
     Status : string;
     UserId : number;

     constructor(){

         this.FullName = '';    
         this.Address = new Address()
         this.Contact = new Contact();
         this.Photos = new Array<Media>();
     }
}