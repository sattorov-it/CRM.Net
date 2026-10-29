namespace Domain.Models;

public class StudentGroups
{
    public int StudentGroupId { get; set; }
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public StudentGroupStatus Status { get; set; }

}
