﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public  class FileModel
    {
        public IFormFile MyFile { get; set; }
        public string CustomerId { get; set; }
    }
}
