using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Вызов анимации при клике.
//Вызов метода урона.

public class HitHelper : MonoBehaviour
{
    GameHelper _gameHelper;

    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
    }
    void OnMouseDown()
    {
        if (_gameHelper.EndGame == true) return;
        Debug.Log("OnMouseDown()");
        GetComponent<HealthHelper>().GetHit(_gameHelper.playerDamage);
    }

}
