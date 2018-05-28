using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    private float m_ScaleX = 19.2f;

    public GameObject m_Plan41;
    public GameObject m_Plan42;
    
    public GameObject m_Plan31;
    public GameObject m_Plan32;

    public GameObject m_Plan21;
    public GameObject m_Plan22;

    public GameObject m_Plan11;
    public GameObject m_Plan12;
    
    private Vector2 m_Plan4Scale = new Vector2();
    private Vector2 m_Plan3Scale = new Vector2();
    private Vector2 m_Plan2Scale = new Vector2();
    private Vector2 m_Plan1Scale = new Vector2();

    private Vector2 m_ScrollingDir41 = new Vector2();
    private Vector2 m_ScrollingDir42 = new Vector2();

    private Vector2 m_ScrollingDir31 = new Vector2();
    private Vector2 m_ScrollingDir32 = new Vector2();

    private Vector2 m_ScrollingDir21 = new Vector2();
    private Vector2 m_ScrollingDir22 = new Vector2();

    private Vector2 m_ScrollingDir11 = new Vector2();
    private Vector2 m_ScrollingDir12 = new Vector2();

    public float m_Plan4ScrollingSpeed = 5f;
    public float m_Plan3ScrollingSpeed = 5f;
    public float m_Plan2ScrollingSpeed = 5f;
    public float m_Plan1ScrollingSpeed = 5f;

    void Start ()
    {
        m_ScrollingDir41 = m_Plan41.transform.position;
        m_ScrollingDir42 = m_Plan42.transform.position;

        m_ScrollingDir31 = m_Plan31.transform.position;
        m_ScrollingDir32 = m_Plan32.transform.position;

        m_ScrollingDir21 = m_Plan21.transform.position;
        m_ScrollingDir22 = m_Plan22.transform.position;

        m_ScrollingDir11 = m_Plan11.transform.position;
        m_ScrollingDir12 = m_Plan12.transform.position;
    }
	
	void Update ()
    {
        m_ScrollingDir41.x -= m_Plan4ScrollingSpeed * Time.deltaTime;
        m_ScrollingDir42.x -= m_Plan4ScrollingSpeed * Time.deltaTime;
        
        m_ScrollingDir31.x -= m_Plan3ScrollingSpeed * Time.deltaTime;
        m_ScrollingDir32.x -= m_Plan3ScrollingSpeed * Time.deltaTime;
    
        m_ScrollingDir21.x -= m_Plan2ScrollingSpeed * Time.deltaTime;
        m_ScrollingDir22.x -= m_Plan2ScrollingSpeed * Time.deltaTime;

        m_ScrollingDir11.x -= m_Plan1ScrollingSpeed * Time.deltaTime;
        m_ScrollingDir12.x -= m_Plan1ScrollingSpeed * Time.deltaTime;

        m_Plan41.transform.position = m_ScrollingDir41;
        m_Plan42.transform.position = m_ScrollingDir42;

        m_Plan31.transform.position = m_ScrollingDir31;
        m_Plan32.transform.position = m_ScrollingDir32;

        m_Plan21.transform.position = m_ScrollingDir21;
        m_Plan22.transform.position = m_ScrollingDir22;

        m_Plan11.transform.position = m_ScrollingDir11;
        m_Plan12.transform.position = m_ScrollingDir12;

        if (m_ScrollingDir41.x <= -m_ScaleX)
        {
            m_ScrollingDir41.x = m_ScrollingDir42.x + m_ScaleX;
        }
        if (m_ScrollingDir42.x <= -m_ScaleX)
        {
            m_ScrollingDir42.x = m_ScrollingDir41.x + m_ScaleX;
        }

        if (m_ScrollingDir31.x <= -m_ScaleX)
        {
            m_ScrollingDir31.x = m_ScrollingDir32.x + m_ScaleX;
        }
        if (m_ScrollingDir32.x <= -m_ScaleX)
        {
            m_ScrollingDir32.x = m_ScrollingDir31.x + m_ScaleX;
        }

        if (m_ScrollingDir21.x <= -m_ScaleX)
        {
            m_ScrollingDir21.x = m_ScrollingDir22.x + m_ScaleX;
        }
        if (m_ScrollingDir22.x <= -m_ScaleX)
        {
            m_ScrollingDir22.x = m_ScrollingDir21.x + m_ScaleX;
        }

        if (m_ScrollingDir11.x <= -m_ScaleX)
        {
            m_ScrollingDir11.x = m_ScrollingDir12.x + m_ScaleX;
        }
        if (m_ScrollingDir12.x <= -m_ScaleX)
        {
            m_ScrollingDir12.x = m_ScrollingDir11.x + m_ScaleX;
        }
    }
}
