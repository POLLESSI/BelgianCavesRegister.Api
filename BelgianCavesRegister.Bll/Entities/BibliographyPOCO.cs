using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Bll.Entities
{
    public class BibliographyPOCO
    {
        public int Bibliography_Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public string DataType { get; set; }
        public string Detail { get; set; }
        public bool Active { get; set; }

        public List<BibliographyPOCO> Bibliographies { get; set; }
        public class Result
        {
            public List<Result> Results { get; set; }
        }
        public class BibliographyResult
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Url { get; set; }
        }
    }
}

