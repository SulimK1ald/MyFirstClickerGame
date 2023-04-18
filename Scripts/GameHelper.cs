using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Обновление текста валюты. СДЕЛАть ИНСТРУКЦИЮ!
//Рандомное появление врага в одном из четырех позиций.
public class GameHelper : MonoBehaviour
{
    public EndMenuHelper EndMenuHelper;
    const int Freeq = 26;
    public int GameTime = 10;
    public Text GameTimeText;
    public GameObject RubyPrefab;

    public Text DamageText;
    public Slider HealthSlider;
    public Transform startPosition;
    public GameObject GoldPrefab;
    public GameObject[] EnemyPrefabs;

    public Text playerRubyUI;
    public Text playerGoldUI;
    public Text KilledEnemiesCount;
    public int playerGold;
    public int playerRuby;
    public int playerDamage = 10;

    public GameObject[] spawnPos;
    public int randomint;
    public int randomEnemy;

    public int _count = 0;
    [SerializeField] public int killedMonsters;
    int _currentTime;
    public bool EndGame { get; set; }

    //private YandexSDK sdk;

    void Start()
    {
        //sdk = YandexSDK.instance;
        //sdk.onRewardedAdReward += RubyADS;
        EndMenuHelper.loadRecord();
        Time.timeScale = 1;
        EndGame = false;
        InvokeRepeating("Timer", 0, 1);
        SpawnEnemy();
    }
    void Timer()
    {
        _currentTime++;
        GameTimeText.text = (GameTime - _currentTime).ToString();

        if (_currentTime >= GameTime)
        {
            Time.timeScale = 0;
            EndGame = true;
            EndMenuHelper.gameObject.SetActive(true);
            EndMenuHelper.EndGame(killedMonsters);//
        }
    }

    void Update()
    {
        playerGoldUI.text = playerGold.ToString();
        playerRubyUI.text = playerRuby.ToString();
        DamageText.text = playerDamage.ToString();
        KilledEnemiesCount.text = "Убито монстров: " + killedMonsters.ToString();
    }
    public void TakeGold(int gold)
    {
        GameObject newGold = Instantiate(GoldPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        Destroy(newGold, 2f);
        playerGold += gold;
        SpawnEnemy();
    }
    public void TakeRuby(int ruby)
    {
        GameObject newRuby = Instantiate(RubyPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        Destroy(newRuby, 2f);
        playerRuby += ruby;
    }

    public void RubyADS(string placement)
    {
        if (placement == "rubyAdd")
        {
            playerRuby += 1;
        }
    }

    public void SpawnEnemy()
    {
        EndMenuHelper.saveRecord();
        _count++;
        int randomMaxValue = _count / Freeq + 1;
        Debug.Log(randomMaxValue);

        if (randomMaxValue >= EnemyPrefabs.Length)
        {
            randomMaxValue = EnemyPrefabs.Length;
        }
        randomEnemy = Random.Range(0, randomMaxValue);
        GameObject newEnemy = Instantiate(EnemyPrefabs[randomEnemy], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        randomint = Random.Range(0, spawnPos.Length);
        newEnemy.transform.position = spawnPos[randomint].transform.position;
    }
}