using System.ComponentModel.DataAnnotations;

namespace Football.Client.Objects
{
    public class Player
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }
        public Country Country { get; set; }
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
    }
}
