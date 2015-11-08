using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BusinessUpgrade : MonoBehaviour {
    public int Level = 0;
    public int MaxLevel = 5;

    public string Name;

    public int BaseCost;
    public int CostPerLevel;
    public float CostExponent;

    public Button buyButton;

    public System.Action AssetUpdated;

    void Start()
    {
        if(PlayerPrefs.HasKey(name))
        {
            int l = PlayerPrefs.GetInt(name);
            for(int i = 0; i < l; i++)
            {
                Upgrade();
            }
        }
    }

    public virtual void Init()
    {
        FindObjectOfType<Business>().AddUpgrade(this);
    }

    public int GetCost()
    {
        return BaseCost + (CostPerLevel * Level);
    }

    public virtual void Upgrade()
    {
        Level++;

        buyButton.GetComponentInChildren<Text>().text = "BUY ("+GetCost()+")";

        if (Level == MaxLevel)
            buyButton.interactable = false;

        if (AssetUpdated != null)
        {
            AssetUpdated();
        }
    }
}
