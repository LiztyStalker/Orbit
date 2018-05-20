using System;
using UnityEngine;

public class SpaceShip
{
    string m_key;

    Sprite m_icon;
    Sprite m_image;
    
    string m_contents;
    
    float m_weight;
    float m_fual;
    float m_speed;

    public string key { get { return m_key; } }
    public Sprite icon { get { return m_icon; } }
    public Sprite image { get { return m_image; } }
    public string contents { get { return m_contents; } }
    public float weight { get { return m_weight; } }
    public float fual { get { return m_fual; } }
    public float speed { get { return m_speed; } }


    public SpaceShip(string key, Sprite icon, Sprite image, string contents, float weight, float fual, float speed)
    {
        m_key = key;
        m_icon = icon;
        m_image = image;
        m_contents = contents;
        m_weight = weight;
        m_fual = fual;
        m_speed = speed;
    }
}

