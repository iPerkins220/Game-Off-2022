using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTestScript : MonoBehaviour
{
    // build UI
    public Image sImage, eImage, hImage;
    public Image hiImage, kImage, fImage;
    public Sprite[] sArray;
    public Sprite[] eArray;
    public Sprite[] hArray;
    public Sprite[] hiArray;
    public Sprite[] kArray;
    public Sprite[] fArray;
    public GameObject armObject, legObject, buildUI;


    // request UI
    public Image aRImage, lRImage, rImage;
    public int armInt, legInt, rewardInt;
    public Sprite[] armArray;
    public Sprite[] legArray;
    public Sprite[] rewardArray;
    public GameObject armCheck, legCheck, acceptRejectButton, submitButton;

    // robot UI
    public GameObject[] blockers;


    // timer UI
    public TMPro.TextMeshProUGUI timerText;
    public float timeValue = 120;

    // win lose screens
    public GameObject winPanel, losePanel;

    // pause
    public bool isPaused;
    public GameObject pausePanel;

    int randNum;
    int sInt, eInt, hInt;
    int hiInt, kInt, fInt;

    public int rangeMax = 5, rangeMin = 0, listCount = 5;

    public List<int> randList = new List<int>();
    List<int> shoulderList = new List<int>(new int[5]); 
    List<int> elbowList = new List<int>(new int[5]); 
    List<int> handList = new List<int>(new int[5]);
    List<int> hipList = new List<int>(new int[5]);
    List<int> kneeList = new List<int>(new int[5]);
    List<int> footList = new List<int>(new int[5]);
    List<int> armList = new List<int>(new int[3]);
    List<int> legList = new List<int>(new int[3]);

    List<int> usedNum = new List<int>();
    List<int> usedArmRequestNum = new List<int>();
    List<int> usedLegRequestNum = new List<int>();
    List<int> usedRewardRequestNum = new List<int>();

    public bool armRequestMet, legRequestMet;

    public void RandumNumber(int count, int min, int max, List<int> list)
    {
        List<int> numberUsed = new List<int>();
        List<int> randList = new List<int>(new int[count]);

        for (int i = 0; i < count; i++)
        {
            randNum = Random.Range(min, max);

            while(numberUsed.Contains(randNum))
            {
                randNum = Random.Range(min, max);
            }
            randList[i] = randNum;
            numberUsed.Add(randNum);
            list[i] = randList[i];
        }

    }

    void Start()
    {
        SetInitialArmImage();
        SetInitialLegImage();
        buildUI.SetActive(false);
        Request();
    }

    public void Request()
    {
        armCheck.SetActive(false);
        legCheck.SetActive(false);

        armInt = Random.Range(0, armArray.Length);
        if (usedArmRequestNum.Contains(armInt)) { armInt = Random.Range(0, armArray.Length); }
        usedArmRequestNum.Add(armInt);
        aRImage.sprite = armArray[armInt];

        legInt = Random.Range(0, legArray.Length);
        if (usedLegRequestNum.Contains(legInt)) { legInt = Random.Range(0, legArray.Length); }
        usedLegRequestNum.Add(legInt);
        lRImage.sprite = legArray[legInt];

        rewardInt = Random.Range(0, rewardArray.Length);
        if (usedRewardRequestNum.Contains(rewardInt)) { rewardInt = Random.Range(0, rewardArray.Length); }
        usedRewardRequestNum.Add(rewardInt);
        rImage.sprite = rewardArray[rewardInt];

        submitButton.SetActive(false);
        acceptRejectButton.SetActive(true);

    }

    public void AcceptRequest()
    {
        acceptRejectButton.SetActive(false);
        submitButton.SetActive(true);
        buildUI.SetActive(true);
    }

    public void RejectRequest()
    {
        Request();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { 
            //PauseGame();

            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pausePanel.SetActive(isPaused);

        }
        if (isPaused) { if (Input.GetKeyDown(KeyCode.Escape)) { ResumeGame(); } }

        if(timeValue> 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        Timer(timeValue);


    }

    public void Timer(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
            Lose();
        }else if (timeToDisplay > 0)
        { 
            timeToDisplay += 1; 
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SetInitialArmImage()
    {
        /*
        RandumNumber(listCount, rangeMin, rangeMax, shoulderList);
        sInt = Random.Range(0, shoulderList.Count);
        usedNum.Add(sInt);
        sImage.sprite = sArray[shoulderList[sInt]];

        RandumNumber(listCount, rangeMin, rangeMax, elbowList);
        eInt = Random.Range(0, elbowList.Count);
        if(usedNum.Contains(eInt)) { eInt = Random.Range(0, elbowList.Count); }
        usedNum.Add(eInt);
        eImage.sprite = eArray[elbowList[eInt]];

        RandumNumber(listCount, rangeMin, rangeMax, handList);
        hInt = Random.Range(0, handList.Count);
        if (usedNum.Contains(hInt)) { hInt = Random.Range(0, handList.Count); }
        hImage.sprite = hArray[handList[hInt]];
        */

        RandumNumber(listCount, rangeMin, rangeMax, shoulderList);
        RandumNumber(listCount, rangeMin, rangeMax, elbowList);
        RandumNumber(listCount, rangeMin, rangeMax, handList);
        RandumNumber(3, 0, shoulderList.Count, armList);

        sInt = armList[0];
        eInt = armList[1];
        hInt = armList[2];

        sImage.sprite = sArray[shoulderList[sInt]];
        eImage.sprite = eArray[elbowList[eInt]];
        hImage.sprite = hArray[handList[hInt]];

        usedNum.Clear();

    }

    public void SetInitialLegImage()
    {
        /*
        RandumNumber(listCount, rangeMin, rangeMax, hipList);
        hiInt = Random.Range(0, hipList.Count);
        usedNum.Add(hiInt);
        hiImage.sprite = hiArray[hipList[hiInt]];

        RandumNumber(listCount, rangeMin, rangeMax, kneeList);
        kInt = Random.Range(0, kneeList.Count);
        if (usedNum.Contains(kInt)) { kInt = Random.Range(0, kneeList.Count); }
        usedNum.Add(kInt);
        kImage.sprite = kArray[kneeList[kInt]];

        RandumNumber(listCount, rangeMin, rangeMax, footList);
        fInt = Random.Range(0, footList.Count);
        if (usedNum.Contains(fInt)) { fInt = Random.Range(0, footList.Count); }
        fImage.sprite = fArray[footList[fInt]];
        */

        RandumNumber(listCount, rangeMin, rangeMax, hipList);
        RandumNumber(listCount, rangeMin, rangeMax, kneeList);
        RandumNumber(listCount, rangeMin, rangeMax, footList);
        RandumNumber(3, 0, hipList.Count, legList);

        hiInt = legList[0];
        kInt = legList[1];
        fInt = legList[2];

        hiImage.sprite = hiArray[hipList[hiInt]];
        kImage.sprite = kArray[kneeList[kInt]];
        fImage.sprite = fArray[footList[fInt]];

        usedNum.Clear();

    }

    // Arm arrow buttons
    public void ShoulderRightButtonClick()
    {
        sInt++;

        if ((sInt) >= sArray.Length)
        {
            sInt = 0;
            sImage.sprite = sArray[shoulderList[sInt]];
        }

        sImage.sprite = sArray[shoulderList[sInt]];

    }
    public void ShoulderLeftButtonClick()
    {

        sInt--;

        
        if ((sInt) < 0)
        {
            sInt = sArray.Length - 1;
            sImage.sprite = sArray[shoulderList[sInt]];
        }

        sImage.sprite = sArray[shoulderList[sInt]];

    }
    public void ElbowRightButtonClick()
    {
        eInt++;

        if ((eInt) >= eArray.Length)
        {
            eInt = 0;
            eImage.sprite = eArray[elbowList[eInt]];
        }

        eImage.sprite = eArray[elbowList[eInt]];

    }
    public void ElbowLeftButtonClick()
    {
        eInt--;

        if ((eInt) < 0)
        {
            eInt = eArray.Length - 1;
            eImage.sprite = eArray[elbowList[eInt]];
        }

        eImage.sprite = eArray[elbowList[eInt]];

    }
    public void HandRightButtonClick()
    {
        hInt++;

        if ((hInt) >= hArray.Length)
        {
            hInt = 0;
            hImage.sprite = hArray[handList[hInt]];
        }

        hImage.sprite = hArray[handList[hInt]];

    }
    public void HandLeftButtonClick()
    {
        hInt--;

        if ((hInt) < 0)
        {
            hInt = hArray.Length - 1;
            hImage.sprite = hArray[handList[hInt]];
        }

        hImage.sprite = hArray[handList[hInt]];

    }



    // Leg Arrow Buttons
    public void HipRightButtonClick()
    {
        hiInt++;

        if ((hiInt) >= sArray.Length)
        {
            hiInt = 0;
            hiImage.sprite = hiArray[hipList[hiInt]];
        }

        hiImage.sprite = hiArray[hipList[hiInt]];

    } 
    public void HipLeftButtonClick()
    {

        hiInt--;

        
        if ((hiInt) < 0)
        {
            hiInt = hiArray.Length - 1;
            hiImage.sprite = hiArray[hipList[hiInt]];
        }

        hiImage.sprite = hiArray[shoulderList[hiInt]];

    }
    public void KneeRightButtonClick()
    {
        kInt++;

        if ((kInt) >= kArray.Length)
        {
            kInt = 0;
            kImage.sprite = kArray[kneeList[kInt]];
        }

        kImage.sprite = kArray[kneeList[kInt]];

    }
    public void KneeLeftButtonClick()
    {
        kInt--;

        if ((kInt) < 0)
        {
            kInt = kArray.Length - 1;
            kImage.sprite = kArray[kneeList[kInt]];
        }

        kImage.sprite = kArray[kneeList[kInt]];

    }
    public void FootRightButtonClick()
    {
        fInt++;

        if ((fInt) >= fArray.Length)
        {
            fInt = 0;
            fImage.sprite = fArray[footList[fInt]];
        }

        fImage.sprite = fArray[footList[fInt]];

    }
    public void FootLeftButtonClick()
    {
        fInt--;

        if ((fInt) < 0)
        {
            fInt = fArray.Length - 1;
            fImage.sprite = fArray[footList[fInt]];
        }

        fImage.sprite = fArray[footList[fInt]];

    }
    




    public void CheckArmBuildAccuracy()
    {
        Debug.Log("Shoulder: " + shoulderList[sInt] + " || Elbow: " + elbowList[eInt] + " || Hand: " + handList[hInt] + " ||");

        if(shoulderList[sInt] == elbowList[eInt] || shoulderList[sInt] == handList[hInt] || elbowList[eInt] == handList[hInt])
        {
            Debug.Log("Arm Build Success");
            if( shoulderList[sInt] == armInt)
            {
                armCheck.SetActive(true);
                armRequestMet = true;
                armObject.SetActive(false);
                legObject.SetActive(true);
                SetInitialArmImage();
            }

        }
        else { Debug.Log("Arm Build Fail"); }
    }

    public void CheckLegBuildAccuracy()
    {
        Debug.Log("Hip: " + hipList[hiInt] + " || Knee: " + kneeList[kInt] + " || Foot: " + footList[fInt] + " ||");

        if (hipList[hiInt] == kneeList[kInt] || hipList[hiInt] == footList[fInt] || kneeList[kInt] == footList[fInt])
        {
            Debug.Log("Leg Build Success");
            if (hipList[hiInt] == legInt)
            {
                legCheck.SetActive(true);
                legRequestMet = true;
                legObject.SetActive(false);
                armObject.SetActive(true);
                SetInitialLegImage();

                if (legRequestMet) { buildUI.SetActive(false); }
            }
        }
        else { Debug.Log("Leg Build Fail"); }
    }

    public void UncoverBlocker()
    {
        if(armRequestMet && legRequestMet)
        {
            blockers[rewardInt].SetActive(false);
            buildUI.SetActive(false);

            if (CheckWin())
            {
                Win();
            }
            else { Request(); }
            
        }
    }

    public bool CheckWin()
    {
        bool uncovered = true;
        for (int i = 0; i < blockers.Length; i++)
        {
            if (blockers[i].activeInHierarchy)
            {
                uncovered = false;
                break;
            }
           
        }
        return uncovered;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        isPaused = false;
    }

    public void Win()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Lose()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

}
