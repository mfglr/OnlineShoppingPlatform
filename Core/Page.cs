namespace Core
{
    public record Page(Guid? Offset, int Take, bool IsDescending);
}
