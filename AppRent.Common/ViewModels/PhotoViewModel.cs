﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRent.Common.ViewModels
{
    public class PhotoViewModel
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public string Description { get; set; }

        public bool IsMain { get; set; }
    }
}
