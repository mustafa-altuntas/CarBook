﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain
{
    public class TagCloud
    {
        public int TagCloudID { get; set; }
        public string Title { get; set; }
        public List<TagCloudBlog> TagCloudBlogs { get; set; }
    }
}
