using System.ComponentModel.DataAnnotations;

namespace StudentCourseRegistration.Models;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    [StringLength(80, ErrorMessage = "Email cannot exceed 80 characters.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select a course.")]
    public string Course { get; set; } = string.Empty;

    [Range(1, 8, ErrorMessage = "Semester must be between 1 and 8.")]
    public int Semester { get; set; }
}
