using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharismaUpgrade : BusinessUpgrade
{
    public int Boost = 200;

    public override void Upgrade()
    {
        Business.instance.MoneyPerScare += Boost;

        base.Upgrade();
    }
}
