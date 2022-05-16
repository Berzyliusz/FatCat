using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory
{
    [Test]
    public void only_allows_one_chest_to_be_equipped_at_a_time()
    {
        // ARRANGE
        Inventory inventory = new Inventory();
        Item chest1 = new Item() { EquipSlot = EquipSlots.Chest };
        Item chest2 = new Item() { EquipSlot = EquipSlots.Chest };

        // ACT
        inventory.EquipItem(chest1);
        inventory.EquipItem(chest2);

        //ASSERT
        var equippedItem = inventory.GetItem(EquipSlots.Chest);
        Assert.AreEqual(chest2, equippedItem);
    }
}
