using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopActive : MonoBehaviour
{
    public GameObject ShopButton;
    public GameObject shopPanel;
    public GameObject howToPlayPanel;

    GameHelper _gameHelper;

    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
        howToPlayPanel.SetActive(true);
        ShopButton.SetActive(false);
        shopPanel.SetActive(false);
    }

    public void ShopAct()
    {
        shopPanel.SetActive(true);
        _gameHelper.EndGame = true;
    }

    public void ShopDisAct()
    {
        shopPanel.SetActive(false);
        _gameHelper.EndGame = false;
    }

    public void closeStartWindow()
    {
        howToPlayPanel.SetActive(false);
        ShopButton.SetActive(true);
    }
}
