using NSubstitute;
using NUnit.Framework;

public class inventory
{
    [Test]
    public void only_allows_one_chest_to_be_equipped_at_a_time()
    {
        // ARRANGE
        ICharacter character = Substitute.For<ICharacter>();
        Inventory inventory = new Inventory(character);
        Item chest1 = new Item() { EquipSlot = EquipSlots.Chest };
        Item chest2 = new Item() { EquipSlot = EquipSlots.Chest };

        // ACT
        inventory.EquipItem(chest1);
        inventory.EquipItem(chest2);

        //ASSERT
        var equippedItem = inventory.GetItem(EquipSlots.Chest);
        Assert.AreEqual(chest2, equippedItem);
    }

    [Test]
    public void tells_character_when_an_item_is_equipped_succsessfully()
    {
        // ARRANGE
        ICharacter character = Substitute.For<ICharacter>();
        Inventory inventory = new Inventory(character);
        Item chestOne = new Item() { EquipSlot = EquipSlots.Chest };

        // ACT
        inventory.EquipItem(chestOne);

        //ASSERT
        character.Received().OnItemEquipped(chestOne);
    }
}
