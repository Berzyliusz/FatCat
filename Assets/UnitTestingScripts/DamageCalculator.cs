using System;

public class DamageCalculator
{
    public static int CalculateDamage(int amount, float mitigationPercent)
    {
        float multiplier = 1f - mitigationPercent;
        return Convert.ToInt32(amount * multiplier);
    }

    public static int CalculateDamage(int amount, ICharacter character)
    {
        int totalArmor = character.Inventory.GetTotalArmor() + character.Level * 10;
        float multiplier = 100f - totalArmor;
        multiplier /= 100f;
        return Convert.ToInt32(amount * multiplier);
    }
}
