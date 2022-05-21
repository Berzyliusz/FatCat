using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    Dictionary<EquipSlots, Item> _equippedItems = new Dictionary<EquipSlots, Item>();
    List<Item> _unequippedItems = new List<Item>();
    private readonly ICharacter _character;

    public Inventory(ICharacter character)
    {
        _character = character;
    }

    public void EquipItem(Item item)
    {
        if (_equippedItems.ContainsKey(item.EquipSlot))
            _unequippedItems.Add(_equippedItems[item.EquipSlot]);

        _equippedItems[item.EquipSlot] = item;
        _character.OnItemEquipped(item);
    }

    public Item GetItem(EquipSlots equipSlot)
    {
        if (_equippedItems.ContainsKey(equipSlot))
            return _equippedItems[equipSlot];

        return null;
    }

    public int GetTotalArmor()
    {
        int totalArmor = _equippedItems.Values.Sum(t => t.Armor);
        return totalArmor;
    }
}