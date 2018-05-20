using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPlayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{

    [SerializeField]
    Text m_score;

    [SerializeField]
    Text m_star;

    [SerializeField]
    Slider m_fualSlider;

    Player m_player;

    void Awake()
    {
        m_player = GameObject.Find("Player").GetComponent<Player>();



    }



    void Update()
    {
        m_score.text = string.Format("{0}", m_player.score);
        m_star.text = string.Format("{0}", m_player.star);
        m_fualSlider.value = m_player.fualRate;
    }

    public void OnPointerDown(PointerEventData data)
    {
        m_player.isClicked = true;
        Debug.Log("Clicked");
    }

    public void OnPointerUp(PointerEventData data)
    {
        m_player.isClicked = false;
        Debug.Log("Up");
    }

}

