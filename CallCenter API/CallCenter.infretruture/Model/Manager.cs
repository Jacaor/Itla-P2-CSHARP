using System;
using System.ComponentModel.DataAnnotations.Schema;



namespace CallCenter.infretruture.Model
{

    public class ManagerModel

    {
        [Column("ManagerId")]
        public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; }




    public ManagerModel(int managerid, string firstName, string phoneNumber, string email, string lastName)
    {
            Id = managerid;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            Email = email;
            LastName = lastName;
    }

    public ManagerModel() { }
}

}