using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarvedRock.Entities
{
    public class ProductReview
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [StringLength(200), Required]
        public string Title { get; set; }
        public string Review { get; set; }

    }
}
