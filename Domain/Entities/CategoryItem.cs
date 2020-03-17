using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("categories")]
    public class CategoryItem
    {
        public long Id { get; set; }
        public String Name { get; set; }

        [Column("parent_category_id")]
        public long ParentCategoryID { get; set; }
    }
}
