﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Business : MonoBehaviour {
    public string Name;
    public string Description;

    public int Money;
    public int MoneyPerTick;
    public int MoneyPerClick;

    public List<BusinessAsset> Assets;
    public List<BusinessUpgrade> Upgrades;

    public float TickTime = 3.0f;

    public System.Action<string> NameChanged;
    public System.Action<string> DescChanged;

    public System.Action<int> MoneyChanged;
    public System.Action<int> MoneyPerTickChanged;

    public System.Action Ticked;

    public int MaxDesks;

    float tickTime;
    public float TickPercent;

    void Awake() {
        Assets = new List<BusinessAsset>();
        Upgrades = new List<BusinessUpgrade>();

        StartCoroutine(DoTick());
        tickTime = 0f;
	}

    public void EarnMoney(int amount)
    {
        Money += amount;

        if (MoneyChanged != null)
        {
            MoneyChanged(Money);
        }
    }

    public void SpendMoney(int amount)
    {
        Money -= amount;

        if (MoneyChanged != null)
        {
            MoneyChanged(Money);
        }
    }

    IEnumerator DoTick()
    {
        while(true)
        {
            yield return new WaitForEndOfFrame();

            tickTime += Time.deltaTime;
            TickPercent = tickTime / TickTime;

            if(tickTime >= TickTime)
            {
                Money += MoneyPerTick;

                if (MoneyChanged != null)
                {
                    MoneyChanged(Money);
                }

                tickTime = 0f;

                if(Ticked != null)
                {
                    Ticked();
                }
            }
        }
    }

    public void AddAsset(BusinessAsset asset)
    {
        Assets.Add(asset);

        UpdateAssets();
    }

    public void AddUpgrade(BusinessUpgrade upgrade)
    {
        Upgrades.Add(upgrade);
    }

    public void UpdateAssets()
    {
        int newTick = 0;

        foreach(BusinessAsset asset in Assets)
        {
            newTick += asset.Money;
        }

        MoneyPerTick = newTick;

        if (MoneyPerTickChanged != null)
        {
            MoneyPerTickChanged(MoneyPerTick);
        }
    }

    public void SetName(string name)
    {
        Name = name;

        if(NameChanged != null)
        {
            NameChanged(Name);
        }
    }

    public void SetDesc(string desc)
    {
        Description = desc;

        if (DescChanged != null)
        {
            DescChanged(Description);
        }
    }
}