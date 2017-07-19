
import {Address, Contact,Media, BaseEntity} from './';

export class Profile extends BaseEntity
{   
     FullName: string;
     Age : number;
     Gender: string;  
     BloodGroup : string;
     Address : Address;
     Contact: Contact;   
     Media : Media;    
     Status : string;

     constructor(){
         super();
         
         this.FullName = '';    
         this.Address = new Address()
         this.Contact = new Contact();
         this.Media = new Media();
     }
}