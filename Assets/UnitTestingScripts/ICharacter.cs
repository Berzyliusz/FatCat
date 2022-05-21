public interface ICharacter
{
    int Health { get; }
    Inventory Inventory { get; }
    int Level { get; }

    void OnItemEquipped(Item item);
}
