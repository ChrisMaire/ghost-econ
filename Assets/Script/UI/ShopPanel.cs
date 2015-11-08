using UnityEngine;
using System.Collections;

public class ShopPanel : Menu {
    public BriefcaseUpgrade briefcase;

    Business business;
    void Awake()
    {
        briefcase = FindObjectOfType<BriefcaseUpgrade>();
        business = FindObjectOfType<Business>();
    }

    public void TryBuyBriefcase()
    {
        if(business.Money > briefcase.BaseCost)
        {
            business.SpendMoney(briefcase.BaseCost);
            briefcase.Upgrade();
        }
    }

    public void TryBuyPoster()
    {

    }
}
