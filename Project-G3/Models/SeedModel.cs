using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_G3.Models
{
    public class SeedModel
    {
        public string tittle { get; set; }
        public string cover { get; set; }
        public string releasYear { get; set; }
        public string duration { get; set; }
        public string text { get; set; }
        public string director { get; set; }
        public string[] genres { get; set; }
        public string[] stars { get; set; }
    }
}