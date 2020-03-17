using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    [Table("jobs")]
    public class JobItem
    {

        [Column("id")]
        [Required]
        public long Id { get; set; }
        [Column("status")]
        [Required]
        public string Status { get; set; }
        [Column("suburb_id")]
        [Required]
        public long SuburbId { get; set; }
        [Column("category_id")]
        [Required]
        public long CategoryId { get; set; }
        [Column("contact_name")]
        public string ContactName { get; set; }
        [Column("contact_phone")]
        public string ContactPhone { get; set; }
        [Column("contact_email")]
        public string ContactEmail { get; set; }
        [Column("price")]
        public int Price { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        public CategoryItem Category { get; set; }
        public SuburbItem Suburb { get; set; }

    }
}
