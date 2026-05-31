using System.ComponentModel.DataAnnotations;

namespace SwiftPro.Models.ViewModels;

public class ContactFormViewModel
{
    [Required(ErrorMessage = "Please enter your full name.")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your email address.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select a country code.")]
    [MaxLength(20)]
    public string CountryCode { get; set; } = "+91";

    [Required(ErrorMessage = "Please enter your phone number.")]
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    [MaxLength(60)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select your country.")]
    [MaxLength(100)]
    public string Country { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a subject.")]
    [MaxLength(150)]
    public string Subject { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please share your requirement.")]
    [MaxLength(2500)]
    [MinLength(10, ErrorMessage = "Message should be at least 10 characters.")]
    public string Message { get; set; } = string.Empty;
}
