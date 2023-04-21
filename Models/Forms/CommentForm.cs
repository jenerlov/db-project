namespace dbproject.Models.Forms;

internal class CommentForm
{
    public string? Comment {get; set;}
    public DateTime Created {get; set;} = DateTime.UtcNow;
}