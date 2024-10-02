using CarBook.Aplication.Interfaces.BlogInterfaces;
using CarBook.Domain;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _carBookContext;

        public BlogRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public List<Blog> GetAllBlogsWithAuthors()
        {
            var values= _carBookContext.Blogs.Include(b => b.Author).Include(b => b.Category).ToList();
            return values;
        }

        public Blog GetBlogByIdWithAuthor(int id)
        {
            var value = _carBookContext.Blogs.Include(b => b.Author).Where(b => b.BlogID == id).FirstOrDefault();
            return value;
        }

        public List<Blog> GetLast3BlogsWhitAuthors()
        {
            return _carBookContext.Blogs.Include(b=>b.Author).OrderByDescending(x=>x.BlogID).Take(3).ToList();
        }
    }
}
