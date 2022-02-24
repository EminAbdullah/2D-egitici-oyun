using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject SquarePrefab;

    [SerializeField]
    private Transform SquarePanel;

    [SerializeField]
    private Text QuestionText;

    private GameObject[] SquaresArray = new GameObject[25];
    [SerializeField]
    private Transform QuestionPanel;

    [SerializeField]
    private Sprite[] SquareSprites;

    [SerializeField]
    private GameObject resultPanel;

    [SerializeField]
    AudioSource audioSource;

    public AudioClip buttonSound;

    List<int> QuotientList = new List<int>(); //Bölüm listesi

    int Dividend, Divisor;//Bölünen ve bölen sayýlar
    int whichQuestion;

    int correctAnswer;
    int ButtonValue;
    bool clickButton;
    HealthManager healthManager;
    ScoreManager scoreManager;

    int Health;

    GameObject currentSquare;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
        
        resultPanel.GetComponent<RectTransform>().localScale = Vector2.zero; //ana ekranda görünmez boyutu 0 olur


        Health = 3;
        scoreManager = Object.FindObjectOfType<ScoreManager>();
        healthManager = Object.FindObjectOfType<HealthManager>();

        healthManager.HealtController(Health);
    }
    void Start()
    {
        clickButton = false;
        QuestionPanel.GetComponent<RectTransform>().localScale = Vector2.zero;// boyutunu 0 olarak ayarladýk animasyon ile açmak için

        CreateSquare();
    }

    public void CreateSquare()
    {
        for (int i = 0; i < SquaresArray.Length; i++)
        {
            GameObject Square = Instantiate(SquarePrefab, SquarePanel);
            Square.transform.GetChild(1).GetComponent<Image>().sprite = SquareSprites[Random.Range(0, SquareSprites.Length)];

            Square.transform.GetComponent<Button>().onClick.AddListener(() => ClickButton());
            SquaresArray[i] = Square;

        }

        QuotientText(); //Bölüm elemanlarýný texte yazdýrýr.
        StartCoroutine(DoFadeRoutine());
        Invoke("QuestionOpen", 3f);// 3 saniye sonra fonksiyonu çalýþtýrýr
        
    }

    private void ClickButton()
    {
        
        if (clickButton)
        {
            audioSource.PlayOneShot(buttonSound);
            ButtonValue = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            currentSquare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            CheckAnswer();
        } 
       
    }

    private void CheckAnswer()
    {
        if (correctAnswer==ButtonValue)
        {
            if (Dividend<40)
            {
                scoreManager.addScore("Easy");
            }
            else if(correctAnswer>=40 && correctAnswer < 60)
            {
                scoreManager.addScore("Normal");
            }
            else
            {
                scoreManager.addScore("Hard");
            }
            
            currentSquare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            currentSquare.transform.GetChild(0).GetComponent<Text>().text = "";
            currentSquare.transform.GetComponent<Button>().interactable = false;

            QuotientList.RemoveAt(whichQuestion);

            if (QuotientList.Count > 0)
            {
                QuestionOpen();
            }
            else
            {
                gameDone();
            }           
           
        }
        else
        {
            Health--;
            healthManager.HealtController(Health);
        }

        if (Health<=0)
        {
            gameDone();
        }
    }

    private void gameDone()
    {
        clickButton = false;
        resultPanel.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.InCirc);
    }

    IEnumerator DoFadeRoutine()
    {

        foreach (var square in SquaresArray)
        {
            square.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void QuotientText() //Bölüm texti
    {
        foreach (var square in SquaresArray)
        {
            int RandomNumber = Random.Range(1, 13);
            QuotientList.Add(RandomNumber);
            square.transform.GetChild(0).GetComponent<Text>().text = RandomNumber.ToString();
        }

    }
    void QuestionOpen()//Soru panelini aç
    {
        AskQuestion();
        clickButton = true;
        QuestionPanel.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.InCirc);

    }

    void AskQuestion()//Soruyu sor
    {

        Divisor = Random.Range(2, 11);
        whichQuestion = Random.Range(0, QuotientList.Count);
        correctAnswer= QuotientList[whichQuestion];
        Dividend = Divisor * correctAnswer;
        QuestionText.text = Dividend.ToString() + ":" + Divisor.ToString();
    
    }

}
