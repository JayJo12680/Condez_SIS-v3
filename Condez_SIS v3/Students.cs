using System;
using System.ComponentModel.DataAnnotations;

namespace Condez_SIS_v3
{
      public class Students
        {
            [Key]
            public int StudentNo { get; set; }
            public string Name { get; set; }
            public string Year_Major { get; set; }
            public string Course { get; set; }
            public DateTime Birthday { get; set; }
            public string ContactNumber { get; set; }
            public string Address { get; set; }
            public string ContactPerson { get; set; }
            public string ContactPersonAddress { get; set; }
            public string ContactPersonNumber { get; set; }
            public byte[] StudentProfile { get; set; }
        }
    }
