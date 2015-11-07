using UnityEngine;
using System.Collections;

public class Desk : BusinessAsset {
    public SpriteRenderer ghost;
    public SpriteRenderer computer;
    public SpriteRenderer desk;

    public void Init(int row)
    {
        Init();

        ghost.sortingLayerID = row;
        computer.sortingLayerID = row;
        desk.sortingLayerID = row;
    }
}
