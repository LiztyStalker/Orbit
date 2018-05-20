using System;
using UnityEngine;

public class UICamera : MonoBehaviour
{
    Player m_player;


    void Awake()
    {
        m_player = GameObject.Find("Player").GetComponent<Player>();

    }

    void FixedUpdate()
    {
        transform.position = new Vector3(0f, m_player.transform.position.y, -10f);
    }


    //void FixedUpdate()
    //{
    //    transform.position = m_player.transform.position + (Vector3.back * 10f);
    //}
}

