using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("suburbs")]
    public class SuburbItem
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String PostCode { get; set; }
    }
}
