using UnityEngine;
using System.Collections;
using System.Linq;

public class BuyPanel : Menu {
    public GameObject DeskObject;

    public Transform DeskList;
    public GameObject DeskRowPrefab;

    DeskLocation[] DeskLocations;

    int maxDesks = 6;
    int deskIndex = 0;

    Business business;

	void Awake() {
        DeskLocations = FindObjectsOfType<DeskLocation>();
        DeskLocations = DeskLocations.OrderBy(d => d.Index).ToArray();

        business = FindObjectOfType<Business>();
	}

    void Start()
    {
        for (int i = 0; i < maxDesks; i++)
        {
            if (PlayerPrefs.HasKey("desk" + i))
            {
                int l = PlayerPrefs.GetInt("desk" + i);
                AddDeskFree(l);
            }
        }
    }
	
	public void BuyDesk()
    {
        if (deskIndex == maxDesks)
        {
            return;
        }

        AddDesk();

    }

    public void AddDesk()
    {
        GameObject newDesk = Instantiate(DeskObject, DeskLocations[deskIndex].transform.position, Quaternion.identity) as GameObject;
        Desk desk = newDesk.GetComponent<Desk>();
        desk.Init(DeskLocations[deskIndex].LayerInt);
        newDesk.transform.SetParent(DeskLocations[deskIndex].transform);
        business.SpendMoney(desk.BaseCost);

        deskIndex++;

        GameObject newDeskRow = Instantiate(DeskRowPrefab) as GameObject;
        newDeskRow.transform.SetParent(DeskList, false);
        newDeskRow.transform.localScale = new Vector3(1, 1, 1);
        newDeskRow.GetComponent<DeskRow>().desk = desk;
    }

    public void AddDeskFree(int level)
    {
        GameObject newDesk = Instantiate(DeskObject, DeskLocations[deskIndex].transform.position, Quaternion.identity) as GameObject;
        Desk desk = newDesk.GetComponent<Desk>();
        desk.Init(DeskLocations[deskIndex].LayerInt);
        newDesk.transform.SetParent(DeskLocations[deskIndex].transform);

        for(int i = 0; i < level;i++)
        {
            desk.Upgrade();
            business.UpdateAssets();
        }

        deskIndex++;

        GameObject newDeskRow = Instantiate(DeskRowPrefab) as GameObject;
        newDeskRow.transform.SetParent(DeskList, false);
        newDeskRow.transform.localScale = new Vector3(1, 1, 1);
        DeskRow d = newDeskRow.GetComponent<DeskRow>();
        d.UpdateText();
    }
}
