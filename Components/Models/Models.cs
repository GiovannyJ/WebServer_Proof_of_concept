namespace WebServer_Proof_of_concept.Components.Models
{
    public class Businesses
    {
        public int BusinessID { get; set; }
        public string? BusinessName { get; set; }
        public int OwnerUserID { get; set; }
        public string? BusinessType { get; set; }
        public string? Location { get; set; }
        public string? Contact { get; set; }
        public string? BusinessDescription { get; set; }
        public string? Events { get; set; }
        public int? Rating { get; set; }
        public string? DataLocation { get; set; } = "internal";
        public int? ImgID { get; set; }
        public string? PetSizePref { get; set; } = "small";
        public bool LeashPolicy { get; set; }
        public bool DisabledFriendly { get; set; }
        public string? GeoLocation { get; set; }
    }

    public class Users
    {
        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? AccountType { get; set; } = "regular";
        public int? ImgID { get; set; } = 0;
    }

    public class UserOwnedBusiness
    {
        public Users? Users { get; set; }
        public Businesses? Business { get; set; }
    }
}
