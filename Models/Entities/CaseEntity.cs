using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dbproject.Models.Entities;

	public class CaseEntity
	{
        [Key]
        public string CaseId {get; set;} = Guid.NewGuid().ToString();
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.UtcNow;

        [ForeignKey("Status")]
        public int StatusTypeId {get; set;}
        public StatusTypeEntity Status {get; set;} = null!;

        public int UserId {get; set;}
        public UserEntity User {get; set;} = null!;

        internal ICollection<CommentEntity> Comments {get; set;} = null!;
    }
