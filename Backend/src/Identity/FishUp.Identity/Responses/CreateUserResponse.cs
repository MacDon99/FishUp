using System.Collections.Generic;

namespace FishUp.Identity.Responses
{
    public class CreateUserResponse
    {
        public bool Created { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}