using AutoMapper;
using Library.Domain.DTO.Review;
using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Mapping
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDTO>(MemberList.None)
                .ForMember(output => output.Id, m => m.MapFrom(input => input.Id))
                .ForMember(output => output.Message, m => m.MapFrom(input => input.Message))
                .ForMember(output => output.Reviewer, m => m.MapFrom(input => input.Reviewer));

            CreateMap<SaveReviewDTO, Review>(MemberList.None)
                .ForMember(output => output.BookId, m => m.MapFrom(input => input.BookId))
                .ForMember(output => output.Message, m => m.MapFrom(input => input.Message))
                .ForMember(output => output.Reviewer, m => m.MapFrom(input => input.Reviewer));
        }
    }
}
