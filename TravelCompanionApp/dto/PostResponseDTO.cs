using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TravelCompanionApp.dto;

public class PostResponseDTO
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }
    
    [JsonPropertyName("contact")]
    [Required(ErrorMessage = "Контактная информация не может быть пустой!")]
    [StringLength(50, ErrorMessage = "Длина контактной информации должна не превышать 50 символов!")]
    public string? Contact { get; set; }
    
    [JsonPropertyName("comment")]
    [StringLength(300, ErrorMessage = "Длина комментария должна не превышать 300 символов!")]
    public string? Comment { get; set; }
    
    [JsonPropertyName("post")]
    public PostDTO? Post { get; set; }
    
    [JsonPropertyName("user")]
    public UserDTO? User { get; set; }
    
    [JsonPropertyName("creation_date")]
    public string? CreationDate { get; set; }
}