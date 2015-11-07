using UnityEngine;
using System.Collections;
using System.Linq;

public class BuyPanel : Menu {
    public GameObject DeskObject;

    public Transform DeskList;
    public GameObject DeskRowPrefab;

    DeskLocation[] DeskLocations;

    int maxDesks = 6;
    int desk = 0;

    Business business;

	void Awake() {
        DeskLocations = FindObjectsOfType<DeskLocation>();
        DeskLocations = DeskLocations.OrderBy(d => d.Index).ToArray();

        business = FindObjectOfType<Business>();
	}
	
	public bool BuyDesk()
    {
        if (desk == maxDesks)
            return false;

        GameObject newDesk = Instantiate(DeskObject, DeskLocations[desk].transform.position, Quaternion.identity) as GameObject;
        newDesk.GetComponent<Desk>().Init(DeskLocations[desk].LayerInt);

        desk++;

        GameObject newDeskRow = Instantiate(DeskRowPrefab) as GameObject;
        newDeskRow.transform.SetParent(DeskList, false);

        return true;
    }
}
