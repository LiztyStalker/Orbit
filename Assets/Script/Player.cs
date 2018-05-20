using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour{

    
    PlanetObject m_planet;



    float m_weight = 1f; //중량
    float m_maxFual = 100f; //연료
    float m_nowFual; //연료
    float m_speed = 1f; //속도 및 가속력



    int m_score = 0;
    int m_star = 0;


    float m_accelerator = 4f;

    float radius = 1f;
    float movement = 1f;
    float rad = 0f;
    float reverser = 1f;


    bool m_isClicked = false;
    bool m_isCircle = false;

    public int score { get { return m_score; } }
    public int star { get { return m_star; } }
    public float fualRate { get { return m_nowFual / m_maxFual; } }
    public bool isClicked { get { return m_isClicked; } set { m_isClicked = value; } }

	// Use this for initialization
	void Start () {

        
        rad = /*Random.Range(0f, 360f)*/90f * Mathf.Deg2Rad;

        float vX = Mathf.Cos(rad) * radius;
        float vY = Mathf.Sin(rad) * radius;
        m_isCircle = false;

        m_nowFual = m_maxFual;

        GetComponent<Rigidbody2D>().velocity = new Vector2(vX, vY);

	}
	
	// Update is called once per frame
	void FixedUpdate () {




        //원운동
        if (m_isClicked)
        {
            if (m_planet != null)
            {


                if (!m_isCircle)
                {
                    Vector2 distance = transform.position - m_planet.transform.position;
                    radius = distance.x * distance.x + distance.y * distance.y;

                    Debug.Log("radius : " + radius);

                    rad = Mathf.Atan2(distance.y, distance.x);
                    m_isCircle = true;

                    //현재 진행각도와 행성 각도를 계산 후 양수이면 시계, 음수이면 시계반대로 회전


                    float velocityAngle = Mathf.Atan2(GetComponent<Rigidbody2D>().velocity.y, GetComponent<Rigidbody2D>().velocity.x);


                    //velocity - 나가는 방향
                    //rad - 행성 위치
                    
                    //나가는 방향을 기준으로 왼쪽, 오른쪽 구분 필요

                    //velocity를 0으로 보간
                    //행성 위치도 velocity만큼 보간
                    //계산 필요

                    //+방향 시계 반대방향
                    //-방향 시계 방향

                    //4사분기에서 1사분기로 이동할 때 또 다른 보간 필요
                    

                    //보간 필요

                    
                    if (angleCalculator(rad * Mathf.Rad2Deg - velocityAngle * Mathf.Rad2Deg) < 0f)
                        reverser = 1f;
                    else
                        reverser = -1f;






                }

                //반지름이 행성의 힘에 따라서 줄어듬

                rad += Time.deltaTime * m_accelerator * reverser;

                radius -= m_planet.gravity * 0.001f;

                float vX = Mathf.Cos(rad) * radius + m_planet.transform.position.x;
                float vY = Mathf.Sin(rad) * radius + m_planet.transform.position.y;

                transform.position = new Vector2(vX, vY);
            }
        }
        //등속운동
        else
        {
            if (m_isCircle)
            {
//                Start();
                m_isCircle = false;



                float vX = Mathf.Cos(rad + 1.57f * reverser) * radius;
                float vY = Mathf.Sin(rad + 1.57f * reverser) * radius;



                GetComponent<Rigidbody2D>().velocity = new Vector2(vX, vY) * m_accelerator;
            }

            m_nowFual -= Time.deltaTime;

        }

    
    }


    float angleCalculator(float angle)
    {
        if (angle > 180f) angle -= 360f;
        if (angle < -180f) angle += 360f;
        return angle;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Planet")
        {
            m_planet = col.GetComponent<PlanetObject>();
            Debug.Log("Planet");
            m_score++;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        m_planet = null;
        Debug.Log("Out");
    }



}
