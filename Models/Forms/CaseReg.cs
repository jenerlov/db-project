namespace dbproject.Models.Forms;


    internal class CaseRegForm
    {
        public string CaseId {get; set;} = null!;
        public string Title {get; set;} = null!;
        public string Description {get; set;} = null!;
        public DateTime Created {get; set;} = DateTime.UtcNow;

        public string Status {get; set;} = null!;
        public string FirstName {get; set;} = null!;
        public string LastName {get; set; } = null!;
        public string Email {get; set; } = null!;
        public string PhoneNumber {get; set; } = null!;


    }


