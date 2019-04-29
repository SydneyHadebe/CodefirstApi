using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Entities
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public Guid AuthorId { get; set; }

        public DeveloperAuthor developerAuthor { get; set; }
    }
}
