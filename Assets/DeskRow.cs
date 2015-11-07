using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeskRow : MonoBehaviour {
    public int Index;

    public Button BuyButton;
    public Button UpgradeButton;

    BuyPanel buyPanel;

    void Awake()
    {
        buyPanel = FindObjectOfType<BuyPanel>();

        BuyButton.onClick.AddListener(() => Buy());
        UpgradeButton.onClick.AddListener(() => Upgrade());
    }

    void Buy()
    {
        buyPanel.BuyDesk();
	}
	
	void Upgrade() {
	    
	}
}
