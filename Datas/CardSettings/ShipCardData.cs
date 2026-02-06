using UnityEngine;
using System.Collections.Generic;

public enum AttackType {
    Laser,
    Missile,
    Boarding
}

public enum TagType
{
    cloaked,
    preemptive_strike,
    Armor
}

[CreateAssetMenu(
    fileName = "New Ship Card",
    menuName = "Cards/Ship Card"
)]
public class ShipCardData : CardData
{
    [Header("Costs")]
    public ResourceCost buildCost;
    public ResourceCost upkeepCost;
    public int buildTime;

    [Header("Combat")]
    public List<AttackType> attackTypes;
    public int attackPower;
    public int attackRange;

    [Header("Stats")]
    public int maxShield;
    public int maxHull;
    public int moveSpeed;

    [Header("Capacity")]
    public int energyStorage;
    public int materialStorage;
}
