using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHelper : MonoBehaviour
{
    HealthHelper _healthHelper;
    public float bulletSpeed = 4f;

    public int Damage { get; set; }
    void Update()
    {
        if (_healthHelper == null)
            _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,
                _healthHelper.transform.position, Time.deltaTime * bulletSpeed);

            if (Vector2.Distance(transform.position,
                _healthHelper.transform.position) < 0.2f)
            {//Ватсон, здесь проблемы.
                _healthHelper.GetHit(Damage);
                Destroy(gameObject);
            }
        }
    }
}
