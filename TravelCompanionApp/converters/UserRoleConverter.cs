using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelCompanionApp.models;

namespace TravelCompanionApp.converters;

public class UserRoleConverter : EnumToStringConverter<Role>
{
    
}