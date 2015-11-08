using UnityEngine;
using System.Collections;

public class BusinessAsset : MonoBehaviour {

    public int Money = 1;
    public int MoneyPerLevel = 5;
    public int Level = 0;
    public int MaxLevel = 5;

    public string Name;
    public string[] LevelNames;

    public int BaseCost;
    public int CostPerLevel;
    public float CostExponent;

    public System.Action AssetUpdated;

    public virtual void Init()
    {
        Money = (1 + Level) * MoneyPerLevel;
        FindObjectOfType<Business>().AddAsset(this);
    }

    public virtual int GetUpgradeCost()
    {
        return (int)Mathf.Pow(BaseCost + (Level * CostPerLevel), CostExponent);
    }

    public virtual void Upgrade()
    {
        Level++;
        Money = (1 + Level) * MoneyPerLevel;

        if (AssetUpdated != null)
        {
            AssetUpdated();
        }
    } 

    public string GetName()
    {
        if(Level > LevelNames.Length)
        {
            return LevelNames[LevelNames.Length];
        } else
        {
            return Name;
        }
    }
}
