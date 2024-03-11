using System.Runtime.Serialization;

namespace Football.Domain
{
    public enum Gender
    {
        [EnumMember(Value = "Male")]
        Male,

        [EnumMember(Value = "Female")]
        Female
    }
}