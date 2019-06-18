using AutoMapper;
using CarPartsService.DAL.Models;

namespace ToDoService.DAL.AutoMapperProfiles
{
    public class ToDoProfile : Profile
    {
        //Example Profile for mapping with Automapper
        public ToDoProfile(){
            // CreateMap<TbuProvider, ProviderVM>()
            //     .ForMember(dest => dest.Name,
            //                 opts => opts.MapFrom(
            //                     src => src.ProviderType == "Facility" ? src.Facility.FacilityName : src.Physician.FirstName + " " + src.Physician.MiddleName + " "  + src.Physician.LastName 
            //                 ));
                
            
        }

    }
}