using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResultManager : MonoBehaviour
{
    public void TryAgain()
    {

        SceneManager.LoadScene("gameLevel");
    }
    public void BackToMenu()
    {

        SceneManager.LoadScene("MenuLevel"); 
    }

   
}
