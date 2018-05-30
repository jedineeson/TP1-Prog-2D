using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnnemyDialogue : MonoBehaviour
{
    public GameObject m_EnnemyDialogueBox;
    public GameObject m_PlayerDialogueBox;

    public float m_TextSpeed;

    private List<string> m_EnnemySentences = new List<string>();

    private List<string> m_PlayerSentencesGroup0 = new List<string>();
    private List<string> m_PlayerSentencesGroup1 = new List<string>();
    private List<string> m_PlayerSentencesGroup2 = new List<string>();
    private List<string> m_PlayerSentencesGroup3 = new List<string>();
    private List<string> m_PlayerSentencesGroup4 = new List<string>();

    private List<List<string>> m_PlayerSentencesGroup = new List<List<string>>();
    private int m_Random;

    public TextMeshProUGUI m_EnnemyTalk;
    public List<TextMeshProUGUI> m_PlayerTalkChoice = new List<TextMeshProUGUI>();

    private void Start()
    {
        m_PlayerSentencesGroup.Add(m_PlayerSentencesGroup0);
        m_PlayerSentencesGroup.Add(m_PlayerSentencesGroup1);
        m_PlayerSentencesGroup.Add(m_PlayerSentencesGroup2);
        m_PlayerSentencesGroup.Add(m_PlayerSentencesGroup3);
        m_PlayerSentencesGroup.Add(m_PlayerSentencesGroup4);

        m_EnnemyTalk.gameObject.SetActive(false);
        m_PlayerTalkChoice[0].gameObject.SetActive(false);
        m_PlayerTalkChoice[1].gameObject.SetActive(false);
        m_PlayerTalkChoice[2].gameObject.SetActive(false);
        m_EnnemyDialogueBox.SetActive(false);
        m_PlayerDialogueBox.SetActive(false);


        m_EnnemyTalk.text = "";
        m_PlayerTalkChoice[0].text = "";
        m_PlayerTalkChoice[1].text = "";
        m_PlayerTalkChoice[2].text = "";
        //0 ennemy
        m_EnnemySentences.Add("T'es sorti d'une lampe, c'est clair... mais t'est quand même pas une lumière!");
        //1 ennemy
        m_EnnemySentences.Add("Qu'est-ce qui est plus stupide qu'un sans-génie? 100 génies!");
        //2 ennemy
        m_EnnemySentences.Add("Tu peux réaliser mon voeux? Et bien fou le camp morveux!");
        //3 ennemy
        m_EnnemySentences.Add("Aujourd'hui, le génie meurt à la fin! Fait tes adieux à Aladin!");
        //4 ennemy
        m_EnnemySentences.Add("Je suis un phénix majestueux, c'est moi la vedette du jeu!");

        //0 Player for 0 ennemy
        m_PlayerSentencesGroup0.Add("   C'est vrai qu'tu brille de mille-feux, mais t'a mis l'feu à ton millieu!");
        m_PlayerSentencesGroup0.Add("   Quand tu repassera à Poudlard, dit bonsoir à Dumbledore!");
        m_PlayerSentencesGroup0.Add("   Je vais réussir à de descendre et répartir tes cendres!");
        //1 Player for 0 ennemy
        m_PlayerSentencesGroup1.Add("   AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        m_PlayerSentencesGroup1.Add("   AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        m_PlayerSentencesGroup1.Add("   111111111111111111111111111111111111111111111111111111111111");
        //2 Player for 0 ennemy
        m_PlayerSentencesGroup2.Add("   BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
        m_PlayerSentencesGroup2.Add("   BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
        m_PlayerSentencesGroup2.Add("   22222222222222222222222222222222222222222222222222222");

        m_PlayerSentencesGroup3.Add("   CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC");
        m_PlayerSentencesGroup3.Add("   CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC");
        m_PlayerSentencesGroup3.Add("   3333333333333333333333333333333333333333333333333333333333");

        m_PlayerSentencesGroup4.Add("   DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
        m_PlayerSentencesGroup4.Add("   DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
        m_PlayerSentencesGroup4.Add("   4444444444444444444444444444444444444444444444444444444444");
    }

    private void Update()
    {     

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_EnnemyTalk.text = "";
            m_PlayerTalkChoice[0].text = "";
            m_PlayerTalkChoice[1].text = "";
            m_PlayerTalkChoice[2].text = "";

            RandomEnnemySentence();

        }
    }

    private void RandomEnnemySentence()
    {
        
        m_Random = Random.Range(0, 5);
        StartCoroutine(ShowEnnemySentence());
        //m_EnnemyTalk.text = m_EnnemySentences[m_Random].ToString();

    }

    private IEnumerator ShowEnnemySentence()
    {
        m_EnnemyDialogueBox.SetActive(true);
        m_EnnemyTalk.gameObject.SetActive(true);
        int textSize = 0;

        while (textSize < m_EnnemySentences[m_Random].ToString().Length)
        {
            m_EnnemyTalk.text += m_EnnemySentences[m_Random].ToString()[textSize++];
            yield return new WaitForSeconds(m_TextSpeed);
        }

        m_PlayerDialogueBox.SetActive(true);

        m_PlayerTalkChoice[1].text = m_PlayerSentencesGroup[m_Random][0].ToString();
        m_PlayerTalkChoice[2].text = m_PlayerSentencesGroup[m_Random][1].ToString();
        m_PlayerTalkChoice[3].text = m_PlayerSentencesGroup[m_Random][2].ToString();

        m_PlayerTalkChoice[0].gameObject.SetActive(true);
        m_PlayerTalkChoice[1].gameObject.SetActive(true);
        m_PlayerTalkChoice[2].gameObject.SetActive(true);

    }

}
