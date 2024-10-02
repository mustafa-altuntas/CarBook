using CarBook.Aplication.Interfaces.TagCloudBlogInterfaces;
using CarBook.Domain;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.TagCloudBlogRepositories
{
    public class TagCloudBlogRepository : ITagCloudBlogRepository
    {
        private readonly CarBookContext _context;

        public TagCloudBlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<TagCloudBlog> GetTagCloudBlogsWithTagById(int blogId)
        {
            var values = _context.TagCloudBlogs.Include(x=>x.TagCloud).Where(a=>a.BlogID==blogId).ToList();
            return values;
        }
    }
}
