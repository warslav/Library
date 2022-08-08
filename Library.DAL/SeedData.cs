using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class SeedData
    {
        public List<Book> Books { get; } = new List<Book>();
        public List<Rating> Ratings { get; } = new List<Rating>();
        public List<Review> Reviews { get; } = new List<Review>();

        public SeedData()
        {
            for (int i = 1; i < 11; i++)
            {
                Books.Add(new()
                {
                    Id = i,
                    Title = $"Book{i}",
                    Cover = $"image{i}.png",
                    Content = $"Content book{i} Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has",
                    Author = $"Author{i}",
                    Genre = $"Genre{i}"
                });

                Ratings.Add(new()
                {
                    Id = i,
                    BookId = i,
                    Score = i
                });

                Reviews.Add(new()
                {
                    Id = i,
                    BookId = i,
                    Message = $"Message{i} It is a long established fact that a reader will be distracted by the readable content of a page",
                    Reviewer = $"Reviewer{i}"
                });
            }
            
        }
    }
}
