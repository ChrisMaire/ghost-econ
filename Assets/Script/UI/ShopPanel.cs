using UnityEngine;
using System.Collections;

public class ShopPanel : Menu {
    public BriefcaseUpgrade briefcase;
    public PosterUpgrade poster;
    public CharismaUpgrade charisma;
    public SnorkelUpgrade snorkel;

    Business business;
    void Awake()
    {
        briefcase = FindObjectOfType<BriefcaseUpgrade>();
        business = FindObjectOfType<Business>();
        charisma = FindObjectOfType<CharismaUpgrade>();
        snorkel = FindObjectOfType<SnorkelUpgrade>();
    }

    public void TryBuyBriefcase()
    {
        if(business.Money > briefcase.GetCost())
        {
            business.SpendMoney(briefcase.GetCost());
            briefcase.Upgrade();
        }
    }

    public void TryBuyPoster()
    {
        if (business.Money > poster.GetCost())
        {
            business.SpendMoney(poster.GetCost());
            poster.Upgrade();
        }
    }

    public void TryBuyCharisma()
    {
        if (business.Money > poster.GetCost())
        {
            business.SpendMoney(poster.GetCost());
            poster.Upgrade();
        }
    }

    public void TryBuySnorkel()
    {
        if (business.Money > snorkel.GetCost())
        {
            business.SpendMoney(snorkel.GetCost());
            snorkel.Upgrade();
        }
    }
}
