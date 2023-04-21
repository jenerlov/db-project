namespace dbproject.Models.Entities;
    public class UserEntity
    {
		public Guid Id { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;

		
		public UserTypeEntity UserType {get; set;} = null!;
		
		public ICollection<CaseEntity> Cases {get; set;} = new HashSet<CaseEntity>();
		internal ICollection<CommentEntity> Comments {get; set;} = new HashSet<CommentEntity>();


    }


