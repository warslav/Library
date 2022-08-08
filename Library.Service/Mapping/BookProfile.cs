using AutoMapper;
using Library.Domain.DTO.Book;
using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, GetBooksDTO>(MemberList.None)
                .ForMember(output => output.Id, m => m.MapFrom(input => input.Id))
                .ForMember(output => output.Title, m => m.MapFrom(input => input.Title))
                .ForMember(output => output.Author, m => m.MapFrom(input => input.Author))
                .ForMember(output => output.Rating, m => m.MapFrom(input =>
                    input.Ratings.Count > 0 ? input.Ratings.Average(x => x.Score) : 0))
                .ForMember(output => output.ReviewsNumber, m => m.MapFrom(input =>
                    input.Reviews.Count > 0 ? input.Reviews.Count : 0));

            CreateMap<Book, GetBookDTO>(MemberList.None)
                .ForMember(output => output.Id, m => m.MapFrom(input => input.Id))
                .ForMember(output => output.Title, m => m.MapFrom(input => input.Title))
                .ForMember(output => output.Author, m => m.MapFrom(input => input.Author))
                .ForMember(output => output.Cover, m => m.MapFrom(input => input.Cover))
                .ForMember(output => output.Content, m => m.MapFrom(input => input.Content))
                .ForMember(output => output.Rating, m => m.MapFrom(input =>
                    input.Ratings.Count > 0 ? input.Ratings.Average(x => x.Score) : 0))
                .ForMember(output => output.Reviews, m => m.MapFrom(input => input.Reviews));

            CreateMap<SaveBookDTO, Book>(MemberList.None)
                .ForMember(output => output.Id, m => m.MapFrom(input => input.Id))
                .ForMember(output => output.Title, m => m.MapFrom(input => input.Title))
                .ForMember(output => output.Cover, m => m.MapFrom(input => input.Cover))
                .ForMember(output => output.Content, m => m.MapFrom(input => input.Content))
                .ForMember(output => output.Genre, m => m.MapFrom(input => input.Genre))
                .ForMember(output => output.Author, m => m.MapFrom(input => input.Author));
        }
    }
}
