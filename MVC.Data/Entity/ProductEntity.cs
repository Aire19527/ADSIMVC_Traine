﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Data.Entity
{
    [Table("Product")]
    public class ProductEntity
    {
        public ProductEntity()
        {
            ImageProductEntities = new HashSet<ImageProductEntity>();
        }

        [Key]
        public int IdProduct { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Amount { get; set; }

        public decimal Price { get; set; }

        [Required]
        public DateTime DateRegister { get; set; }
        public DateTime? DateUpdate { get; set; }


        [ForeignKey("CategoryEntity")]
        public int IdCategory { get; set; }
        public CategoryEntity CategoryEntity { get; set; }  
        
        [ForeignKey("StateEntity")]
        public int IdState { get; set; }
        public StateEntity StateEntity { get; set; }

        public IEnumerable<ImageProductEntity> ImageProductEntities { get; set; }

        public IEnumerable<InvoiceDetailEntity> InvoiceDetailEntities { get; set; }

    }
}
