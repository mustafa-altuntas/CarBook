using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain
{
    public class TagCloudBlog
    {
        public int TagCloudBlogID { get; set; }
        public int TagCloudID { get; set; }
        public TagCloud TagCloud { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }

    }
}
