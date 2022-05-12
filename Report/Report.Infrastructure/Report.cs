using System;
using System.ComponentModel.DataAnnotations;

namespace Report.Infrastructure
{
    public class Report
    {
        [Key]
        public int ID { get; set; }
        public DateTime RequestDate { get; set; }
        public string FilePath { get; set; }
        public bool Status { get; set; }
        
    }
}
