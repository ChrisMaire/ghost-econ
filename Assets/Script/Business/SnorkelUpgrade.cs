using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SnorkelUpgrade : BusinessUpgrade {

    public GameObject SnorkelButton;

    public override void Upgrade()
    {
        base.Upgrade();

        SnorkelButton.gameObject.SetActive(true);
        buyButton.interactable = false;

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.RunStarted += () => StartRun();
        gameManager.RunEnded += () => EndRun();
    }

    void StartRun()
    {
        if(Level > 0)
            SnorkelButton.SetActive(false);
    }

    void EndRun()
    {
        if(Level > 0)
            SnorkelButton.SetActive(true);
    }
}
