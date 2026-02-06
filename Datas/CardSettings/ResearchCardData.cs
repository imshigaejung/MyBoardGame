using UnityEngine;

[CreateAssetMenu(
    fileName = "New Research Card",
    menuName = "Cards/Research Card"
)]
public class ResearchCardData : CardData
{
    [Header("Costs")]
    public ResourceCost researchCost;
    public int researchTime;

    [Header("Availability")]
    public bool canResearch;
}
