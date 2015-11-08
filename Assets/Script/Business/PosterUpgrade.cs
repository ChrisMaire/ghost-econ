using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PosterUpgrade : BusinessUpgrade {
    public float TickReduce = 0.5f;

    public GameObject[] Posters;
    public override void Upgrade()
    {
        Posters[Level].SetActive(true);
        FindObjectOfType<Business>().TickTime -= TickReduce;

        base.Upgrade();

        if (Level == MaxLevel)
            buyButton.interactable = false;
    }
}
