using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHelper : MonoBehaviour
{
    [SerializeField] int MaxHealth = 100;
    [SerializeField] int Health;
    [SerializeField] int Gold = 30;

    public float timeToDestroy;
    GameHelper _gameHelper;
    void Start()
    {
        StartCoroutine(BombTimeDestroy());
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
    }
    public void GetHit(int damage)
    {
        int health = Health - damage;
        if (health <= 0)
        {
            _gameHelper.TakeGold(Gold);
            Destroy(gameObject);
            _gameHelper.SpawnEnemy();
        }
        Health = health;
        Debug.Log("Health = " + Health);
    }
    IEnumerator BombTimeDestroy()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject, timeToDestroy);
        _gameHelper.SpawnEnemy();
        StopCoroutine(BombTimeDestroy());
    }
}
