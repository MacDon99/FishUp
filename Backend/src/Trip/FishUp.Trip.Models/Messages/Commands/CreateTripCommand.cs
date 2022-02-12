using FishUp.Dispatchers;
using System.ComponentModel.DataAnnotations;

namespace FishUp.Trip.Models.Messages.Commands
{
    public record CreateTripCommand : ICommand
    {
        [Required]
        public string Destination { get; set; }
        public Guid AuthorId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
