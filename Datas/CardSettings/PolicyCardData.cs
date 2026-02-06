using UnityEngine;

[CreateAssetMenu(
    fileName = "New Policy Card",
    menuName = "Cards/Policy Card"
)]
public class PolicyCardData : CardData
{
    [Header("Costs")]
    public ResourceCost policyCost;

    [Header("Availablity")]
    public bool canExecute;
}

