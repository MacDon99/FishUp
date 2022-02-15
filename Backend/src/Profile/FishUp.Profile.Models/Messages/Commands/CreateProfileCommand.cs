using FishUp.Dispatchers;

namespace FishUp.Profile.Models.Messages.Commands
{
    public record CreateProfileCommand(Guid UserId) : ICommand
    {
        public string City { get; set; }
        public string Voivodeship { get; set; }
        public DateTime BirthDate { get; set; }
        public string Profession { get; set; }
        public bool WillToTravelFar { get; set; }
    }
}
