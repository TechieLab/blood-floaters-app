import {Profile,Donation} from '../../app/models';

export class Donor{
    public profileId : number;
    public donationId : number;

    public Profile : Profile;
    public Donation : Donation;

    public PastDonations : Array<Donation>;

    constructor(){
        this.Profile = new Profile();
        this.Donation = new Donation();

        this.PastDonations = new Array<Donation>();

    }
}