﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleEF.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
