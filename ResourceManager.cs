using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public ResourceCost current;
    public ResourceCost income;

    public void Init()
    {
        
    }
    
    public bool CanPay(ResourceCost cost)
    {
        return current.energy >= cost.energy &&
               current.material >= cost.material &&
               current.credit >= cost.credit;
    }

    public bool Pay(ResourceCost cost)
    {
        if (!CanPay(cost))
            return false;

        current.energy -= cost.energy;
        current.material -= cost.material;
        current.credit -= cost.credit;
        return true;
    }

    public void Gain(ResourceCost gain)
    {
        current.energy += gain.energy;
        current.material += gain.material;
        current.credit += gain.credit;
    }

    public void Income()
    {
        Gain(income);
    }
}