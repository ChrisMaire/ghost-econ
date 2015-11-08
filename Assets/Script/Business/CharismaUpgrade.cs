using UnityEngine;
using System.Collections;

public class CharismaUpgrade : BusinessUpgrade {

    public GameObject BriefcaseButton;

    public override void Upgrade()
    {
        base.Upgrade();

        BriefcaseButton.gameObject.SetActive(true);

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
