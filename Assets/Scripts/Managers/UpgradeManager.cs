using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeManager : MonoBehaviour
{
    private Button button1, button2, button0;
    private List<UpgradeCard> upgradeCards = new List<UpgradeCard>();
    private Type currType;
    private Canvas canvas;

    private void OnEnable()
    {
        GameManager.UpgradeEvent += ChooseAndDisplayUpgrades;
    }

    private void OnDisable()
    {
        GameManager.UpgradeEvent -= ChooseAndDisplayUpgrades;
    }

    private void ChooseAndDisplayUpgrades()
    {
        upgradeCards = GameManager.Instance.GetRandomUpgradeCards(3);
        button0.GetComponent<Image>().sprite = upgradeCards[0].upgradeVisual;
        button0.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = upgradeCards[0].upgradeText;
        button1.GetComponent<Image>().sprite = upgradeCards[1].upgradeVisual;
        button1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = upgradeCards[1].upgradeText;
        button2.GetComponent<Image>().sprite = upgradeCards[2].upgradeVisual;
        button2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = upgradeCards[2].upgradeText;
    }

    private void Start()
    {
        button0 = transform.GetChild(0).GetComponent<Button>();
        button0.onClick.AddListener(UpgradeButton0);
        button1 = transform.GetChild(1).GetComponent<Button>();
        button1.onClick.AddListener(UpgradeButton1);
        button2 = transform.GetChild(2).GetComponent<Button>();
        button2.onClick.AddListener(UpgradeButton2);
        canvas = GetComponent<Canvas>();
    }

    private void UpgradeButton0()
    {
        currType = upgradeCards[0].upgradeType;
        transform.parent.gameObject.AddComponent(currType);
        canvas.gameObject.SetActive(false);
        GameManager.Instance.PlayerReadyUp();
    }

    private void UpgradeButton1()
    {
        currType = upgradeCards[1].upgradeType;
        transform.parent.gameObject.AddComponent(currType);
        canvas.gameObject.SetActive(false);
        GameManager.Instance.PlayerReadyUp();
    }

    private void UpgradeButton2()
    {
        currType = upgradeCards[2].upgradeType;
        transform.parent.gameObject.AddComponent(currType);
        canvas.gameObject.SetActive(false);
        GameManager.Instance.PlayerReadyUp();
    }
}
