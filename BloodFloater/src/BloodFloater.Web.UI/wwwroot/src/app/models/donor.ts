import {Profile,Donation} from '../../app/models';

export class Donor{
    public ProfileId : number;
    public DonationId : number;

    public Profile : Profile;
    public Donation : Donation;

    public PastDonations : Array<Donation>;

    constructor(){
        this.Profile = new Profile();
        this.Donation = new Donation();

        this.PastDonations = new Array<Donation>();

    }
}