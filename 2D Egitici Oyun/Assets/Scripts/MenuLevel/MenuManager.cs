using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject StartBtn, ExitBtn;
    // Start is called before the first frame update
    void Start()
    {
        fadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void fadeOut()
    {
        StartBtn.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
        ExitBtn.GetComponent<CanvasGroup>().DOFade(1, 0.8f).SetDelay(0.5f);

    }
    public void ExitGame()
    {

        Application.Quit();
    }
    public void StartGameLevel()
    {

        SceneManager.LoadScene("gameLevel");
    }
}
