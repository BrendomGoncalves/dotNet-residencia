namespace TechMed.Core.Entities;

public abstract class BaseEntity
{
    public DateTimeOffSet CreateAt {get; set;}
    public DateTimeOffSet? UpdateAt {get; set;}
    public DateTimeOffSet? DeleteAt {get; set;}
}
