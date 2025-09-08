using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using SurveyBasket.API.Models;
using SurveyBasket.API.DTOs.Response;
using SurveyBasket.API.DTOs.Requist;

namespace API_FirstProject.Profiles
{
    public class ApplicationUserProfile:Profile
    {
        public ApplicationUserProfile() {
        
        CreateMap<Poll,PollResponse>().ForMember(dest=>dest.Description,op=>op.MapFrom(s=>s.Description)).ReverseMap();

            CreateMap<Poll, pollRequist>().ReverseMap();
        
        
        
        
        
        }
    }
}
