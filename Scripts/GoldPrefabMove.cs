using UnityEngine;

public class GoldPrefabMove : MonoBehaviour
{
    public float speed;
    goldEndPos EndPosHelper;
    //Движение/анимация валюты до конечной точки.
    void Start()
    {
        EndPosHelper = GameObject.FindObjectOfType<goldEndPos>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, EndPosHelper.transform.position, speed);
    }
}
