﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BriefcaseUpgrade : BusinessUpgrade {

    public GameObject BriefcaseButton;

    public override void Upgrade()
    {
        base.Upgrade();

        BriefcaseButton.gameObject.SetActive(true);
        buyButton.interactable = false;

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.RunStarted += () => StartRun();
        gameManager.RunEnded += () => EndRun();
    }

    void StartRun()
    {
        if(Level > 0)
            BriefcaseButton.SetActive(false);
    }

    void EndRun()
    {
        if(Level > 0)
            BriefcaseButton.SetActive(true);
    }
}
