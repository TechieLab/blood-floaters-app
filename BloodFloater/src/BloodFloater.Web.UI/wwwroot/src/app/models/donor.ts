import {Address, Contact} from '../../app/models';

export class Donor{
    public FullName : string;
    public BloodGroup : string;
    public Address : Address;
    public Contact : Contact;

    constructor(){
        this.Address = new Address();
        this.Contact = new Contact();
    }
}