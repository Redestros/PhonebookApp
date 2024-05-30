using System.ComponentModel.DataAnnotations;

namespace PhonebookApp.UI.Models;

public class UpdateContactModel
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Phone { get; set; } = string.Empty;
}