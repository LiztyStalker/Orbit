using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    PlanetObject m_planetObject;

    [SerializeField]
    Transform m_galaxyTransform;

    List<PlanetObject> m_planetList = new List<PlanetObject>();

    int m_count = 100;
    float m_height = 1f;
    float m_width = 0f;

    void Start()
    {
        initPlanet();
    }


    void initPlanet()
    {
        for (int i = 0; i < 10; i++)
        {
            createPlanet();
        }
    }


    void FixedUpdate()
    {
        if (transform.position.y + 10f < m_height)
        {
            createPlanet();
        }
    }

    void createPlanet()
    {
        PlanetObject planetObj = Instantiate(m_planetObject);
        float size = UnityEngine.Random.Range(1f, 4f);
        float vX = UnityEngine.Random.Range(-2f, 2f);
        float vY = m_height;
        m_height += size;
        planetObj.transform.position = new Vector2(vX, vY);
        planetObj.transform.localScale *= size;
        planetObj.transform.SetParent(m_galaxyTransform);
        m_planetList.Add(planetObj);
    }


    //void createPlanet()
    //{
    //    for (int i = 0; i < m_count; i++)
    //    {
    //        PlanetObject planetObj = Instantiate(m_planetObject);
    //        float vX = UnityEngine.Random.Range(-100f, 100f);
    //        float vY = UnityEngine.Random.Range(-100f, 100f);
    //        planetObj.transform.position = new Vector2(vX, vY);
    //        planetObj.transform.localScale *= UnityEngine.Random.Range(1f, 10f);
    //        planetObj.transform.SetParent(m_galaxyTransform);
    //        m_planetList.Add(planetObj);
    //    }
    //}
}

