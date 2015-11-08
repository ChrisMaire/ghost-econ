using UnityEngine;
using System.Collections;

public class BusinessUpgrade : MonoBehaviour {
    public int Level = 0;
    public int MaxLevel = 5;

    public string Name;

    public int BaseCost;
    public int CostPerLevel;
    public float CostExponent;

    public System.Action AssetUpdated;

    public virtual void Init()
    {
        FindObjectOfType<Business>().AddUpgrade(this);
    }

    public virtual int GetUpgradeCost()
    {
        return BaseCost + (Level * CostPerLevel);
    }

    public virtual void Upgrade()
    {
        Level++;

        if (AssetUpdated != null)
        {
            AssetUpdated();
        }
    }
}
