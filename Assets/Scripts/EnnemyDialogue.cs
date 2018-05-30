using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

[System.Serializable]
public class PlayerAnswersGroup
{
    public string[] m_PlayerAnswersGroup = new string[3];
    public int m_GoodAnswer = 0;
}

public class EnnemyDialogue : MonoBehaviour
{
    public int m_GoodAnswersQuantity;
    public int m_QuestionQuantity;
    public float m_EnnemyTextSpeed;
    public string[] m_EnnemySentences = new string[0];
    public TextMeshProUGUI m_EnnemyTalk;
    
    public Button[] m_ButtonsGroup = new Button[3];
    
    public GameObject m_EnnemyDialogueBox;
    public GameObject m_PlayerDialogueBox;
    public PlayerAnswersGroup[] m_PlayerAnswersGroupOfGroup = new PlayerAnswersGroup[0];
    
    private const int ANSWERS_QUANTITY = 3;
    private int m_Random;

    //loop playeranswersgroup 
    public void OnValidate()
    {   
        Array.Resize(ref m_PlayerAnswersGroupOfGroup, m_QuestionQuantity);
        Array.Resize(ref m_EnnemySentences, m_QuestionQuantity);
        Array.Resize(ref m_ButtonsGroup, ANSWERS_QUANTITY);

        for (int i = 0; i < m_PlayerAnswersGroupOfGroup.Length; i++)
        {
            Array.Resize(ref m_PlayerAnswersGroupOfGroup[i].m_PlayerAnswersGroup, ANSWERS_QUANTITY);//m_PlayerAnswers
        }
        
        Debug.LogWarning("Cannot resize this array");       
    }

    private void Start()
    {
        m_EnnemyTalk.gameObject.SetActive(false);
        m_ButtonsGroup[0].gameObject.SetActive(false);
        m_ButtonsGroup[1].gameObject.SetActive(false);
        m_ButtonsGroup[2].gameObject.SetActive(false);
        m_EnnemyDialogueBox.SetActive(false);
        m_PlayerDialogueBox.SetActive(false);


        m_EnnemyTalk.SetText("");
        
        
        //m_EnnemySentences.Add("T'es sorti d'une lampe, c'est clair... mais t'est quand même pas une lumière!");      
        //m_EnnemySentences.Add("Qu'est-ce qui est plus stupide qu'un sans-génie? 100 génies!");        
        //m_EnnemySentences.Add("Tu peux réaliser mon voeux? Et bien fou le camp morveux!");  
        //m_EnnemySentences.Add("Aujourd'hui, le génie meurt à la fin! Fait tes adieux à Aladin!");
        //m_EnnemySentences.Add("Je suis un phénix majestueux, c'est moi la vedette du jeu!");

        //0 Player for 0 ennemy
        //m_PlayerSentencesGroup0.Add("- C'est vrai qu'tu brille de mille-feux, mais t'a mis l'feu à ton millieu!");
        //m_PlayerSentencesGroup0.Add("- Quand tu repassera à Poudlard, dit bonsoir à Dumbledore!");
        //m_PlayerSentencesGroup0.Add("- Je vais réussir à de descendre et répartir tes cendres!");
        
        //1 Player for 0 ennemy
        //m_PlayerSentencesGroup1.Add("- AAAAAAAA AAAAAAAAAAAAAAA AAAAAAAAAA AAAA AAAAAAAAA AAAAA AAAAA AAA");
        //m_PlayerSentencesGroup1.Add("- AAAAAAAA AAAAAAAAAA AAAAAAAA AAAAAAAA AAAAAAAAA AAAAAA AAAAAAAAA");
        //m_PlayerSentencesGroup1.Add("- 1111 1111 111111111 1111 111111111 11111 1111111111 11111111");
        
        //2 Player for 0 ennemy
        //m_PlayerSentencesGroup2.Add("- BBBBBBB BBBBBBB BBBBBBBB BBBBBBBBB BBBBBBB BBBBBBBBB BBBBB BBBBB");
        //m_PlayerSentencesGroup2.Add("- BBBBBBB BBB BBBBBBBBB BBBBBBBBB BBBBBBBBB BBBBBBBBB BBBBBBB BBB");
        //m_PlayerSentencesGroup2.Add("- 2222 22222222 22222222 2222222 22222222 222222 222222");

        //m_PlayerSentencesGroup3.Add("- CCCCC CCCCCCCC CCCCCC CCCCCCCCCCC CCCCCCC CCCC CCCCC");
        //m_PlayerSentencesGroup3.Add("- CCCC CCCCC CCCCCCC CCCCCC CCCCCCCC CCCCCCC CCCCC CCCC CCCCC");
        //m_PlayerSentencesGroup3.Add("- 33333 333333 33333333333 3333333 333333333 3333333 3333333");

        //m_PlayerSentencesGroup4.Add("- DDDDDDDDD D DDDDDDDDD DDDDDDDDDD DDDDDDDDDDDDD DDD DDDDDD");
        //m_PlayerSentencesGroup4.Add("- DDDD DDDDDDD DDDDDDD DDDDDDDD DDDDD DDDDDDDDD DDDDDD DDDD");
        //m_PlayerSentencesGroup4.Add("- 444444 444444 44444444 44444444 44444444 44444 444444 4444");

        //m_PlayerSentencesGroup.Add(m_PlayerSentencesGroup0);
        //m_PlayerSentencesGroup.Add(m_PlayerSentencesGroup1);
        //m_PlayerSentencesGroup.Add(m_PlayerSentencesGroup2);
        //m_PlayerSentencesGroup.Add(m_PlayerSentencesGroup3);
        //m_PlayerSentencesGroup.Add(m_PlayerSentencesGroup4);
    }

    private void Update()
    {     
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_EnnemyTalk.text = "";

            RandomEnnemySentence();

        }
    }

    private void RandomEnnemySentence()
    {        
        m_Random = UnityEngine.Random.Range(0, m_QuestionQuantity);
        StartCoroutine(ShowSentences());
    }

    private IEnumerator ShowSentences()
    {
        m_EnnemyDialogueBox.SetActive(true);
        m_EnnemyTalk.gameObject.SetActive(true);
        int textSize = 0;
        Debug.Log(m_Random);
        Debug.Log(m_EnnemySentences.Length);
        while (textSize < m_EnnemySentences[m_Random].ToString().Length)
        {
            m_EnnemyTalk.text += m_EnnemySentences[m_Random].ToString()[textSize++];
            yield return new WaitForSeconds(m_EnnemyTextSpeed);
        }

        m_PlayerDialogueBox.SetActive(true);

        m_ButtonsGroup[0].gameObject.SetActive(true);
        m_ButtonsGroup[1].gameObject.SetActive(true);
        m_ButtonsGroup[2].gameObject.SetActive(true);
        
        TextMeshProUGUI playerTalk;
        
        for (int i = 0; i < m_ButtonsGroup.Length; i++)
        {
            playerTalk = m_ButtonsGroup[i].gameObject.GetComponentInChildren<TextMeshProUGUI>();
            playerTalk.SetText(m_PlayerAnswersGroupOfGroup[m_Random].m_PlayerAnswersGroup[i]);
            Debug.Log(playerTalk.text);
        }
      
    }

    public void ValidateAnswers(int answers)
    {
        if(answers == m_PlayerAnswersGroupOfGroup[m_Random].m_GoodAnswer)
        {
            m_GoodAnswersQuantity += 1;
        }
        else
        {
            m_GoodAnswersQuantity = 0;
        }

        Debug.Log(m_GoodAnswersQuantity);
        //switch (m_Random)
        //{
        //    case 0 : 
        //    case 1 :
        //    case 2 :
        //    case 3 :
        //    case 4 :
        //    default:
        //}    
    }

}
