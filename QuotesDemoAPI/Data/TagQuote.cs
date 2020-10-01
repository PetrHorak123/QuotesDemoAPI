using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesDemoAPI.Data
{
    public class TagQuote
    {
        

        [ForeignKey("Quote")]
        public int QuoteId { get; set; }
        public Quote Quote { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
