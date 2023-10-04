namespace Employee.Frontend.Models;

public class Emplyees
{
    public int Id { get; set; }

    /// <summary>
    /// First Name
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// Last Name
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// Address
    /// </summary>
    public string? Address { get; set; }
    /// <summary>
    /// Age
    /// </summary>
    public int Age { get; set; }
    /// <summary>
    /// Phone Number
    /// </summary>
    public string? PhoneNumber { get; set; }
    ///<summary>
    ///phone Number
    ///</summary>
    public string? Email { get; set; }

    public int CountryId { get; set; }

    public string? CountryName { get; set; }
}
