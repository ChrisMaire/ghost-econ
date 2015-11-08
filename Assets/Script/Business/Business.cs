using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Business : MonoBehaviour {
    public string Name;
    public string Description;

    public int Money;
    public int MoneyPerTick;
    public int MoneyPerClick;
    public int MoneyPerScare;

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

    public static Business instance;

    void Awake() {
        instance = this;

        Assets = new List<BusinessAsset>();
        Upgrades = new List<BusinessUpgrade>();

        StartCoroutine(DoTick());
        tickTime = 0f;

        if(PlayerPrefs.HasKey("businessname"))
        {
            Name = PlayerPrefs.GetString("businessname");
            Description = PlayerPrefs.GetString("businessdesc");
            Money = PlayerPrefs.GetInt("money");
        }
    }

    void Start()
    {
        if (NameChanged != null)
        {
            NameChanged(Name);
        }
        if (DescChanged != null)
        {
            DescChanged(Description);
        }
        if (MoneyChanged != null)
        {
            DescChanged(Description);
        }

        MenuManager m = FindObjectOfType<MenuManager>();
        BuyPanel b = m.HRMenu.GetComponent<BuyPanel>();
        for (int i = 0; i < b.maxDesks; i++)
        {
            if (PlayerPrefs.HasKey("desk" + i))
            {
                int l = PlayerPrefs.GetInt("desk" + i);
                b.AddDeskFree(l);
            }
        }
    }

    public void EarnMoney(int amount)
    {
        Money += amount;

        PlayerPrefs.SetInt("money", Money);

        if (MoneyChanged != null)
        {
            MoneyChanged(Money);
        }
    }

    public void SpendMoney(int amount)
    {
        Money -= amount;

        PlayerPrefs.SetInt("money", Money);

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

        for (int i = 0; i < Assets.Count; i++)
        {
            PlayerPrefs.SetInt("desk"+i, Assets[i].Level);
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
        PlayerPrefs.SetString("businessname", Name);
        if(NameChanged != null)
        {
            NameChanged(Name);
        }
    }

    public void SetDesc(string desc)
    {
        Description = desc;
        PlayerPrefs.SetString("businessdesc", desc);
        if (DescChanged != null)
        {
            DescChanged(Description);
        }
    }
}
