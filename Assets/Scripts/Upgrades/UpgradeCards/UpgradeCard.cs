using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class UpgradeCard
{
    public Sprite upgradeVisual;
    public Type upgradeType;
    public string upgradeText;

    public UpgradeCard(Sprite upgradeVisual, Type upgradeType, string upgradeText)
    {
        this.upgradeVisual = upgradeVisual;
        this.upgradeType = upgradeType;
        this.upgradeText = upgradeText;
    }

    public UpgradeCard Clone()
    {
        return new UpgradeCard(this.upgradeVisual, this.upgradeType, this.upgradeText);
    }
}
