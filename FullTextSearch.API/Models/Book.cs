using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FullTextSearch.API.Models
{
    public class Book
    {
        [Key, NotNull]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(50), NotNull]
        public string Name { get; set; }
        [MaxLength(100), NotNull]
        public string Description { get; set; }
    }
}
