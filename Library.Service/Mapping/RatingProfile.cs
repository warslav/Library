using AutoMapper;
using Library.Domain.DTO.Rating;
using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Mapping
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<SaveRatingDTO, Rating>(MemberList.None)
                .ForMember(output => output.BookId, m => m.MapFrom(input => input.BookId))
                .ForMember(output => output.Score, m => m.MapFrom(input => input.Score));
        }
    }
}
