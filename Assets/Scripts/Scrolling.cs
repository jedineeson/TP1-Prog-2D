using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class LayerGroup
{
    public GameObject[] m_Backgrounds = new GameObject[2];
    [HideInInspector]
    public GameObject m_PreviousBackground;
    public float m_LayerSpeed = 5f;
}

public class Scrolling : MonoBehaviour
{
    public int m_NumberOfLayer = 4;
    public LayerGroup[] m_LayerGroup = new LayerGroup[0];
    //private float m_ScaleX = 19.2f;
    public Vector2 m_ScrollingDir = new Vector2();
    private float m_ScreenWidth;
    public GameObject GameManager;

    public void OnValidate()
    {
        Array.Resize(ref m_LayerGroup, m_NumberOfLayer);

        for (int i = 0; i < m_LayerGroup.Length; i++)
        {
            Array.Resize(ref m_LayerGroup[i].m_Backgrounds, 2);//m_PlayerAnswers

        }

        //Debug.LogWarning("Cannot resize this array");
    }

    private void Start()
    {
        m_ScreenWidth = -Screen.width / 100f;

        for (int i = 0; i < m_LayerGroup.Length; i++)
        {
                m_LayerGroup[i].m_PreviousBackground = m_LayerGroup[i].m_Backgrounds[m_LayerGroup[i].m_Backgrounds.Length-1];
        }
    }

    private void Update()
    {
        if(GameManager.GetComponent<EnnemyDialogue>().m_IsPlay == true)
        {
            for (int i = 0; i < m_LayerGroup.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    m_LayerGroup[i].m_Backgrounds[j].transform.Translate(-m_LayerGroup[i].m_LayerSpeed * Time.deltaTime, 0f, 0f);
            
                    if (m_LayerGroup[i].m_Backgrounds[j].transform.position.x < m_ScreenWidth)
                    {
                        //Içi on assigne une nouvelle position en x en backgrounds ayant dépasser la limite.
                        m_ScrollingDir.x = m_LayerGroup[i].m_PreviousBackground.transform.position.x - m_ScreenWidth;
                        m_LayerGroup[i].m_Backgrounds[j].transform.position = m_ScrollingDir;
                        m_LayerGroup[i].m_Backgrounds[j].transform.position = new Vector3(m_LayerGroup[i].m_Backgrounds[j].transform.position.x - m_LayerGroup[i].m_LayerSpeed * Time.deltaTime, 0f);
                    }
            
                    m_LayerGroup[i].m_PreviousBackground = m_LayerGroup[i].m_Backgrounds[j];
            
                }

            }
        }
        
    }
}
