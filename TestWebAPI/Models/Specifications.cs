using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI.Models
{
    public class Specifications
    {
        public string OriginallyPublished { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }

        private readonly List<string> _Genres = new List<string>();
        private readonly List<string> _Illustrator = new List<string>();
        public IList<string> Genres { get { return _Genres; } }
        public IList<string> Illustrator { get { return _Illustrator; } }
    }
}
