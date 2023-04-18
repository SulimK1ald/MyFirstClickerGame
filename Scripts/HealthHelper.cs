using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Получение урона при клике.
// Уничтожение врага.
// Прибавление и спавн валюты.

public class HealthHelper : MonoBehaviour
{
    public int RubyChance;
    [SerializeField] int MaxHealth = 100;
    [SerializeField] int Health;
    [SerializeField] int Gold = 30;

    GameHelper _gameHelper;
    public bool _isDead;

    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
        _gameHelper.HealthSlider.maxValue = MaxHealth;
        _gameHelper.HealthSlider.value = MaxHealth;
    }
    public void GetHit(int damage)
    {
        if (_isDead) return;

        int health = Health - damage;
        if (health <= 0)
        {
            _gameHelper.killedMonsters++;

            _isDead = true;
            _gameHelper.TakeGold(Gold);

            int random = Random.Range(0, 100);
            if (random < RubyChance)
            {
                _gameHelper.TakeRuby(1);
            }

            Destroy(gameObject);
        }
        GetComponent<Animator>().SetTrigger("Hit");
        Health = health;
        _gameHelper.HealthSlider.value = health;
    }

}
