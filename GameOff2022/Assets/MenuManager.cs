using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject[] menuArray;

    public GameObject[] rArray;

    public int raInt = 0, lastInt;

    private void Start()
    {
        menuArray[0].SetActive(true);
    }

    public void ToInfo()
    {
        menuArray[1].SetActive(true);
        menuArray[0].SetActive(false);
    }

    public void GoToRobots()
    {
        menuArray[2].SetActive(true);
        menuArray[0].SetActive(false);
    }

    public void RightArrowClick()
    {
        raInt++;

        if ((raInt) >= 5)
        {
            raInt = 0;
            rArray[raInt].SetActive(true);
            rArray[4].SetActive(false);
            
        }
        lastInt = raInt-1;
        rArray[raInt].SetActive(true);
        rArray[lastInt].SetActive(false);
        
    }

    public void LeftArrowClick()
    {
        raInt--;

        if ((raInt) < 0)
        {
            raInt = 4;
            rArray[raInt].SetActive(true);
            rArray[0].SetActive(false);
        }
        lastInt = raInt + 1;
        rArray[raInt].SetActive(true);
        rArray[lastInt].SetActive(false);
    }

    public void MainMenu()
    {
        menuArray[0].SetActive(true);
        menuArray[1].SetActive(false);
        menuArray[2].SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
