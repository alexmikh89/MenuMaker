namespace MenuMaker.Data.Interfaces
{
    public interface INextEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
