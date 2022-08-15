using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace dotnettest.Pokemon.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Trainer
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        [StringLength(998)] // RFC5322
        public string Email { get; set; } = "";

    }
}