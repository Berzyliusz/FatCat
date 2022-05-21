using NUnit.Framework;

public class character_witch_inventory
{
    [Test]
    public void with_90_armor_takes_10_percent_damage()
    {
        // ARRANGE
        Character character = new Character();
        Inventory inventory = new Inventory();
        Item pants = new Item() { EquipSlot = EquipSlots.Legs, Armor = 40 };
        Item shield = new Item() { EquipSlot = EquipSlots.RightHand, Armor = 50 };

        inventory.EquipItem(pants);
        inventory.EquipItem(shield);

        character.Inventory = inventory;

        // ACT
        int calculatedDamage = DamageCalculator.CalculateDamage(1000, character);

        // ASSERT
        Assert.AreEqual(100, calculatedDamage);
    }
}
