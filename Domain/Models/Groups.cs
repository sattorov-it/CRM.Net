namespace Domain.Models;

public class Groups
{
    public int GroupId { get; set; }
    public string GroupName { get; set; } = null!;
    public int CourseId { get; set; }
    public int MentorId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}
