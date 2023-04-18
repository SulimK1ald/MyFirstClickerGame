using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpButtonHelper : MonoBehaviour
{

    public bool isRuby;
    public bool isHero;
    public GameObject HeroPrefab;

    public GameObject UpPrefab;
    public Text DamageTxt;
    public Text PriceTxt;
    public Image IconImage;

    public int Damage = 10;
    public int Price = 100;

    GameHelper _gameHelper;

    public int heroCount;
    public bool killHero;

    public GameObject notEnoughMoneyTxt;

    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
        DamageTxt.text = "+" + Damage.ToString();
        PriceTxt.text = Price.ToString();
        notEnoughMoneyTxt.SetActive(false);
    }

    public void UpgradeClick()
    {
        if (!isRuby && _gameHelper.playerGold >= Price || isRuby && _gameHelper.playerRuby >= Price)
        {
            if (!isRuby)
            _gameHelper.playerGold -= Price;
            else
            _gameHelper.playerRuby -= Price;
            if (!isHero)
            {
                _gameHelper.playerDamage += Damage;

            }
            else if (heroCount < 33)
            {
                GameObject hero = Instantiate(HeroPrefab) as GameObject;

                heroCount++; //Ограничение на спавн бесконечных помощников

                Vector3 heroPos = new Vector3(
                    7.8f,//Random.Range(8.3f, 7.8f),
                    Random.Range(-4.0f, 1.8f),
                    0
                    );
                hero.transform.position = heroPos;
            }
            else
            {
                Destroy(gameObject);
            }

            GameObject upEffect = Instantiate(UpPrefab) as GameObject;
            Transform canvas = GameObject.Find("Canvas").transform;
            upEffect.transform.SetParent(canvas);
            upEffect.GetComponent<Image>().sprite = IconImage.sprite;

            Destroy(upEffect, 1.5f);

            if (!isHero || killHero == true)
            {
                Destroy(gameObject);
            }
            
        }
        else
        {
            StartCoroutine(notEnoughMoney());
        }
    }
    IEnumerator notEnoughMoney()
    {
        notEnoughMoneyTxt.SetActive(true);
        yield return new WaitForSeconds(2);
        notEnoughMoneyTxt.SetActive(false);
        StopCoroutine(notEnoughMoney());
    }
}
