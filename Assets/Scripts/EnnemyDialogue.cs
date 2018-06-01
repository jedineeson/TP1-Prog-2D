using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

//m_EnnemySentences.Add("T'es sorti d'une lampe, c'est clair... mais t'est quand même pas une lumière!");      
//m_EnnemySentences.Add("Qu'est-ce qui est plus stupide qu'un sans-génie? 100 génies!");        
//m_EnnemySentences.Add("Tu peux réaliser mon voeux? Et bien fou le camp morveux!");  
//m_EnnemySentences.Add("Aujourd'hui, le génie meurt à la fin! Fait tes adieux à Aladin!");
//m_EnnemySentences.Add("Je suis un phénix majestueux, c'est moi la vedette du jeu!");

//0 Player for 0 ennemy
//m_PlayerSentencesGroup0.Add("- C'est vrai qu'tu brille de mille-feux, mais t'a mis l'feu à ton millieu!");
//m_PlayerSentencesGroup0.Add("- Quand tu repassera à Poudlard, dit bonsoir à Dumbledore!");
//m_PlayerSentencesGroup0.Add("- Je vais réussir à de descendre et répartir tes cendres!");

[System.Serializable]
public class PlayerAnswersGroup
{
    //les 3 réponses du joueurs correspodant aux 3 boutons
    //(Il serait intéressant de pouvoir rendre le chiffre disponible au designer)
    public string[] m_PlayerAnswersGroup = new string[3];
    //la bonne réponse (0-3)
    //(Il serait intéressant de pouvoir rendre le chiffre disponible au designer)
    public int m_RightAnswer = 0;
}

public class EnnemyDialogue : MonoBehaviour
{
    public AudioSource m_BeepTalk;
    public AudioSource m_GenieAttack;
    public AudioSource m_PhenixAttack;
    public AudioSource m_Music;
    public Animator m_GenieAnimator;
    public Animator m_BirdAnimator;

    private bool[] m_AnsweredQuestion = new bool[0];

    //nombre de bonne réponse du joueur
    private int m_Score;
    //nombre de question que le designer veux
    public int m_QuestionQuantity;
    //vitesse de défilement du texte de l'ennemie
    public float m_EnnemyTextSpeed = 0.1f;

    private float m_ActualEnnemyTextSpeed;
    //liste des dialogues de l'ennemie que le designer veux 
    public string[] m_EnnemySentences = new string[0];
    //Text mesh de l'ennemi
    public TextMeshProUGUI m_EnnemyTalk;
    //les 3 boutons interactifs sur lesquels les choix de dialogues du joueur sont affichés
    //(Il serait intéressant de pouvoir rendre le chiffre disponible au designer)
    public Button[] m_ButtonsGroup = new Button[3];
    //Boîte de dialogue de l'ennemie (sprite)
    
    public Button m_StartButton;

    public GameObject m_EnnemyDialogueBox;
    //Boîte de dialogue du joueur (sprite)
    public GameObject m_PlayerDialogueBox;
    //Liste des groupes de 3 réponses du joueurs 
    public PlayerAnswersGroup[] m_PlayerAnswersGroupOfGroup = new PlayerAnswersGroup[0];
    //nombre de réponse possible pour le joueur
    //(Il serait intéressant de pouvoir rendre le chiffre disponible au designer)
    private const int ANSWERS_QUANTITY = 3;
    //int random qui détermine le dialogue de l'ennemi à afficher
    private int m_Random;

    private bool m_IsWriting;

    public bool m_IsPlay;

    //loop playeranswersgroup 
    public void OnValidate()
    {
        Array.Resize(ref m_PlayerAnswersGroupOfGroup, m_QuestionQuantity);
        Array.Resize(ref m_EnnemySentences, m_QuestionQuantity);
        Array.Resize(ref m_AnsweredQuestion, m_QuestionQuantity);
        Array.Resize(ref m_ButtonsGroup, ANSWERS_QUANTITY);

        for (int i = 0; i < m_PlayerAnswersGroupOfGroup.Length; i++)
        {
            Array.Resize(ref m_PlayerAnswersGroupOfGroup[i].m_PlayerAnswersGroup, ANSWERS_QUANTITY);//m_PlayerAnswers
        }

        //Debug.LogWarning("Cannot resize this array");
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        { 
            m_ActualEnnemyTextSpeed = 0f;
        }
    }

        private IEnumerator LetsPlay()
    {
        yield return new WaitForSeconds(3f);
        m_ActualEnnemyTextSpeed = m_EnnemyTextSpeed;
        m_EnnemyTalk.text = "";
        RandomEnnemySentence();
    }

    private void RandomEnnemySentence()
    {
        m_IsWriting = true;

        while (m_AnsweredQuestion[m_Random] != false)
        {
            m_Random = UnityEngine.Random.Range(0, m_QuestionQuantity);
        }
        StartCoroutine(ShowSentences());
    }

    private IEnumerator ShowSentences()
    {
        m_EnnemyDialogueBox.SetActive(true);
        m_EnnemyTalk.gameObject.SetActive(true);
        int textSize = 0;

        while (textSize < m_EnnemySentences[m_Random].ToString().Length)
        {
            m_BeepTalk.Play();
            m_EnnemyTalk.text += m_EnnemySentences[m_Random].ToString()[textSize++];

            if (m_ActualEnnemyTextSpeed > 0)
            {
                yield return new WaitForSeconds(m_ActualEnnemyTextSpeed);
            }
        }

        yield return new WaitForSeconds(1f);

        m_PlayerDialogueBox.SetActive(true);
        m_ButtonsGroup[0].gameObject.SetActive(true);
        m_ButtonsGroup[1].gameObject.SetActive(true);
        m_ButtonsGroup[2].gameObject.SetActive(true);

        TextMeshProUGUI playerTalk;

        for (int i = 0; i < m_ButtonsGroup.Length; i++)
        {
            playerTalk = m_ButtonsGroup[i].gameObject.GetComponentInChildren<TextMeshProUGUI>();
            playerTalk.SetText(m_PlayerAnswersGroupOfGroup[m_Random].m_PlayerAnswersGroup[i]);
        }

    }

    public void StartToPlay()
    {
        m_IsPlay = true;
        m_GenieAnimator.SetTrigger("GenieAnimate");
        m_BirdAnimator.SetTrigger("BirdAnimate");
        m_Music.Play();
        m_StartButton.gameObject.SetActive(false);
        StartCoroutine(LetsPlay());
    }

    public void ValidateAnswers(int answers)
    {

        if (answers == m_PlayerAnswersGroupOfGroup[m_Random].m_RightAnswer)
        {
            m_Score += 1;
            m_AnsweredQuestion[m_Random] = true;
            
            m_GenieAnimator.SetTrigger("GenieAttack");
            m_BirdAnimator.SetTrigger("BirdGetHit");

            m_GenieAttack.Play();
        }
        else
        {
            for (int i = 0; i < m_QuestionQuantity; i++)
            {
                m_AnsweredQuestion[i] = false;
            }
            m_Score = 0;

            m_BirdAnimator.SetTrigger("BirdAttack");
            m_GenieAnimator.SetTrigger("GenieGetHit");

            m_PhenixAttack.Play();
        }

        m_EnnemyTalk.gameObject.SetActive(false);
        m_ButtonsGroup[0].gameObject.SetActive(false);
        m_ButtonsGroup[1].gameObject.SetActive(false);
        m_ButtonsGroup[2].gameObject.SetActive(false);
        m_EnnemyDialogueBox.SetActive(false);
        m_PlayerDialogueBox.SetActive(false);

        if(m_Score != 5)
        {
            StartCoroutine(LetsPlay());
            
        }
    }

    private IEnumerator Victory()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Victoire");
    }

}
