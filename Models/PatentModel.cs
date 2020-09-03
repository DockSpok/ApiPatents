using System;
using System.Collections.Generic;

namespace ApiPatents.Models
{
    public class PatentModel
    {
        public int PatentId { get; set; }
        public string PatentNumber { get; set; }
        public string PatentTitle { get; set; }
        public int PatentNumClaims { get; set; }
        public List<string> PatentClaims { get; set; }
        public DateTime PatentDate { get; set; }
        public DateTime DateModified { get; set; }
    }
}
