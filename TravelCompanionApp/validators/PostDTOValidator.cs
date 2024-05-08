using TravelCompanionApp.dto;
using TravelCompanionApp.exception;

namespace TravelCompanionApp.validators;

public class PostDTOValidator
{
    public void validate(PostDTO postDTO)
    {
        var errors = new Dictionary<string, string>();
        if (postDTO.DateThere != null)
            if (postDTO.DateThere < DateTime.Now)
                errors.Add("Date", "Дата отправления не может быть в прошлом." );
        if (postDTO.DateBack != null)
            if (postDTO.DateBack < DateTime.Now)
                errors.Add("Date", "Дата прибытия не может быть в прошлом." ); 
        if (postDTO.DateBack < postDTO.DateThere)
        {
            if (errors.ContainsKey("Date"))
            {
                errors.Remove("Date");
                errors.Add("Date", "Неверный формат даты прибытия.");
            }
            else
            {
                errors.Add("Date", "Дата прибытия не может быть раньше даты отправления.");
            }
        }
        if (errors.Count > 0)
            throw new InvalidRequestException("Invalid request!", errors);
    }
}