using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Business : MonoBehaviour {
    public string Name;
    public string Description;

    public int Money;
    public int MoneyPerTick;

    public List<BusinessAsset> Assets;

    public float TickTime = 3.0f;

    public System.Action<int> MoneyChanged;
    public System.Action<int> MoneyPerTickChanged;

    public int MaxDesks;

    void Awake() {
        Assets = new List<BusinessAsset>();
        StartCoroutine(DoTick());
	}

    IEnumerator DoTick()
    {
        while(true)
        {
            yield return new WaitForSeconds(TickTime);

            Money += MoneyPerTick;

            if(MoneyChanged != null)
            {
                MoneyChanged(Money);
            }
        }
    }

    public void AddAsset(BusinessAsset asset)
    {
        Assets.Add(asset);

        UpdateAssets();
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
            MoneyPerTickChanged(Money);
        }
    }
}
