using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dbproject.Models.Entities;

internal class CommentEntity 
{
    public Guid Id{get; set;}
    public DateTime Created {get; set;}
    public string Comment {get; set;} = null!;

    [ForeignKey("CaseId")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public CaseEntity Case {get; set;} = null!;

    [ForeignKey("UserId")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public UserEntity User {get; set;} = null!;
}