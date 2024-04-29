namespace Annexxie.Model
{
    public class Person
    {
        int vid;
        string vFirstName, vLastName, vImage, vCity, vAddress, vPhoneNumber, vEmail, vpassword;
        bool visDeleted;
        public Person()
        {

        }
        public Person(int id, string firstName, string lastName, string image, string city, string address, string phoneNumber, bool isDeleted, string email,string password)
        {
            this.vid = id;
            vFirstName = firstName;
            vLastName = lastName;
            vCity = city;
            vAddress = address;
            vPhoneNumber = phoneNumber;
            vImage = image;
            this.visDeleted = isDeleted;
            vEmail = email;
            vpassword = password;
        }

        public int Id { get => vid; set => vid = value; }
        public string FirstName { get => vFirstName; set => vFirstName = value; }
        public string LastName { get => vLastName; set => vLastName = value; }
        public string Image { get => vImage; set => vImage = value; }
        public string City { get => vCity; set => vCity = value; }
        public string Address { get => vAddress; set => vAddress = value; }
        public string PhoneNumber { get => vPhoneNumber; set => vPhoneNumber = value; }
        public string Email { get => vEmail; set => vEmail = value; }
        public bool IsDeleted { get => visDeleted; set => visDeleted = value; }
        public string Password { get => vpassword; set => vpassword = value; }
    }
}
