using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeskRow : MonoBehaviour {
    public int Index;

    public Button BuyButton;
    public Button UpgradeButton;

    public Text DescriptionText;
    public Text UpgradeButtonText;

    BuyPanel buyPanel;

    public Desk desk;

    Business business;

    void Awake()
    {
        buyPanel = FindObjectOfType<BuyPanel>();
        business = FindObjectOfType<Business>();

        BuyButton.onClick.AddListener(() => Buy());
        UpgradeButton.onClick.AddListener(() => Upgrade());

        business.MoneyChanged += m => UpdateRow(m);
    }

    void Start()
    {
        UpdateText();
        UpdateRow(business.Money);
    }

    void Buy()
    {
        buyPanel.BuyDesk();
	}
	
	void Upgrade() {
        if(desk != null && business.Money >= desk.GetUpgradeCost() && desk.Level < desk.MaxLevel)
        {
            desk.Upgrade();

            business.SpendMoney(desk.GetUpgradeCost());
            business.UpdateAssets();

            UpdateText();
        }
	}

    void UpdateText()
    {
        if(desk != null)
        {
            DescriptionText.text = desk.LevelNames[desk.Level] + " - $" + desk.Money + " / Tick";
            UpgradeButtonText.text = "UPGRADE - LEVEL " + (desk.Level + 1) + " (" + desk.GetUpgradeCost() + ")";
        }
    }

    void UpdateRow(int money)
    {
        if (money >= desk.GetUpgradeCost())
        {
            UpgradeButton.interactable = true;
        }
        else
        {
            UpgradeButton.interactable = false;
        }
    }
}
