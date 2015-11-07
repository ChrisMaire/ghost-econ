using UnityEngine;
using System.Collections;

public class Desk : BusinessAsset {
    public SpriteRenderer ghost;
    public SpriteRenderer computer;
    public SpriteRenderer desk;

    Transform thisTransform;

    void Start()
    {
        thisTransform = transform;
        FindObjectOfType<Business>().Ticked += () =>
        {
            FloatyTextManager.ShowFloatyMoney(Money, Camera.main.WorldToScreenPoint(thisTransform.position));
        };
    }

    public void Init(int row)
    {
        Init();

        ghost.sortingLayerID = row;
        computer.sortingLayerID = row;
        desk.sortingLayerID = row;
    }
}
