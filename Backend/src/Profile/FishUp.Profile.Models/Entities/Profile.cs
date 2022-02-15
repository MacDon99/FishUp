using FishUp.Domain;
using FishUp.Domain.Types;
using FishUp.Models.Types;

namespace FishUp.Profile.Models.Entities
{
    public class Profile : Entity
    {
        public Guid UserId { get; set; }
        public string City { get; set; }
        public string Voivodeship { get; set; }
        public DateTime BirthDate { get; set; }
        public string Profession { get; set; }
        public bool WillToTravelFar { get; set; }
        public ICollection<StoredFile> Photos { get; set; }
        public StoredFile? ProfilePhoto { get; set; }
        public StoredFile? BackgroundPhoto { get; set; }

        protected Profile()
        {

        }

        public Profile(Guid userId, string city, string voivodeship, DateTime birthDate, string profession, bool willToTravelFar)
        {
            UserId = userId;
            City = city;
            Voivodeship = voivodeship;
            BirthDate = birthDate;
            Profession = profession;
            WillToTravelFar = willToTravelFar;
        }

        public void SetProfilePhoto(StoredFile photo)
        {
            ProfilePhoto = photo;
        }

        public void AddPhoto(StoredFile photo)
        {
            ProfilePhoto = photo;
        }

        public void SetBackgroundPhoto(StoredFile photo)
        {
            Photos.Add(photo);
        }

        public override void Valid()
        {
            if (string.IsNullOrEmpty(City))
            {
                throw new DomainException(ExceptionCode.InvalidValue, $"{nameof(Profile)}.{City} cannot be null");
            };

            if (string.IsNullOrEmpty(Voivodeship))
            {
                throw new DomainException(ExceptionCode.InvalidValue, $"{nameof(Profile)}.{Voivodeship} cannot be null");
            };

            if (BirthDate == DateTime.MinValue)
            {
                throw new DomainException(ExceptionCode.InvalidValue, $"{nameof(Profile)}.{BirthDate} cannot be null");
            };

            if (string.IsNullOrEmpty(Profession))
            {
                throw new DomainException(ExceptionCode.InvalidValue, $"{nameof(Profile)}.{Profession} cannot be null");
            };
        }
    }
}