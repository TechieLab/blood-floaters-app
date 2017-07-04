using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DomainModels = BloodFloater.Models;

namespace BloodFloater.Infrastructure
{
    public class DomainToViewModelMappingProfile : AutoMapper.Profile
    {
        //protected override void Configure()
        //{
        //    Mapper.CreateMap<DomainModels.Receiver, ViewModels.Receiver>();

        //    Mapper.CreateMap<DomainModels.Donor, ViewModels.Donor>()
        //        .ForMember(vm => vm.TotalPhotos, map => map.MapFrom(a => a.Photos.Count))
        //        .ForMember(vm => vm.Thumbnail, map =>
        //            map.MapFrom(a => (a.Photos != null && a.Photos.Count > 0) ?
        //            "/images/" + a.Photos.First().Uri :
        //            "/images/thumbnail-default.png"));
        //}
    }
}
