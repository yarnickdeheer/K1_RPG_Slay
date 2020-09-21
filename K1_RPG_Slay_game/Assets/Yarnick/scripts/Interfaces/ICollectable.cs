public interface IColletable
{
    //int Weight { get; set; }
    int Rarity { get; set; }
    int ItemId { get; set; }
    void CollectItem();
}