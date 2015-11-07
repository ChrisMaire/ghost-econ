using UnityEngine;
using System.Collections;

public class BusinessAsset : MonoBehaviour {

    public int Money = 1;
    public int MoneyPerLevel = 5;
    public int Level = 0;

    public int BaseCost;
    public int CostPerLevel;
    public int CostExponent;

    public System.Action AssetUpdated;
    
    public virtual int GetCost()
    {
        return (int)Mathf.Pow(BaseCost + (Level * CostPerLevel), CostExponent);
    }

    public virtual void Upgrade()
    {
        Level++;

        if(AssetUpdated != null)
        {
            AssetUpdated();
        }
    } 
}
