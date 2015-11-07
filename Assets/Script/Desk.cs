using UnityEngine;
using System.Collections;

public class Desk : BusinessAsset {
    public SpriteRenderer ghost;
    public SpriteRenderer computer;
    public SpriteRenderer desk;

    public void Init(int row)
    {
        ghost.sortingLayerID = row;
        computer.sortingLayerID = row;
        desk.sortingLayerID = row;

        FindObjectOfType<Business>().AddAsset(this);
    }
}
