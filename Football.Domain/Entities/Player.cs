using System.ComponentModel.DataAnnotations;

namespace Football.Domain
{
    public class Player
    {
        // Todo: Custom error message
        public Guid Id { get; set; }
        
        [Required]
        // самое длинное имя в мире имеет 102 символа
        [StringLength(102, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]*$")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(102, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]*$")]
        public string LastName { get; set; }
        
        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        
        [Required]
        // TODO: посмотреть возможность валидации даты
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }
        
        [Required]
        [EnumDataType(typeof(Country))]
        public Country Country { get; set; }
        
        [Required]
        public Guid TeamId { get; set; }
    }
}
