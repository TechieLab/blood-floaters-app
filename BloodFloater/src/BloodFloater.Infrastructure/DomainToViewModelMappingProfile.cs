using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DomainModels = BloodFloater.Models;

namespace BloodFloater.Infrastructure
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<DomainModels.Receiver, ViewModels.Receiver>().ReverseMap();

            CreateMap<DomainModels.Donor, ViewModels.Donor>().ReverseMap();

            CreateMap<DomainModels.User, ViewModels.User>().ReverseMap();

            CreateMap<DomainModels.Profile, ViewModels.Profile>().ReverseMap();

            CreateMap<DomainModels.Address, ViewModels.Address>().ReverseMap();

            CreateMap<DomainModels.Contact, ViewModels.Contact>().ReverseMap();

            CreateMap<DomainModels.Donation, ViewModels.Donation>().ReverseMap();

            CreateMap<DomainModels.DonorHistory, ViewModels.DonorHistory>().ReverseMap();

            CreateMap<DomainModels.Location, ViewModels.Location>().ReverseMap();

            CreateMap<DomainModels.LocationCords, ViewModels.LocationCords>().ReverseMap();

            //    .ForMember(vm => vm.TotalPhotos, map => map.MapFrom(a => a.Photos.Count))
            //    .ForMember(vm => vm.Thumbnail, map =>
            //        map.MapFrom(a => (a.Photos != null && a.Photos.Count > 0) ?
            //        "/images/" + a.Photos.First().Uri :
            //        "/images/thumbnail-default.png"));
        }
    }
}
