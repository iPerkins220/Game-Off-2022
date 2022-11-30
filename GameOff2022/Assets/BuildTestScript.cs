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


    // request UI
    public Image aRImage, lRImage, rImage;
    public int armInt, legInt, rewardInt;
    public Sprite[] armArray;
    public Sprite[] legArray;
    public Sprite[] rewardArray;
    public GameObject armCheck, legCheck;

    // robot UI
    public GameObject[] blockers;


    int randNum;
    int sInt, eInt, hInt;
    int hiInt, kInt, fInt;
    int resetInt = 4;

    public int rangeMax = 5, rangeMin = 0, listCount = 5;

    public List<int> randList = new List<int>();
    List<int> shoulderList = new List<int>(new int[5]); 
    List<int> elbowList = new List<int>(new int[5]); 
    List<int> handList = new List<int>(new int[5]);
    List<int> hipList = new List<int>(new int[5]);
    List<int> kneeList = new List<int>(new int[5]);
    List<int> footList = new List<int>(new int[5]);

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

    // Start is called before the first frame update
    void Start()
    {
        SetInitialArmImage();
        SetInitialLegImage();
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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetInitialArmImage()
    {

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
        


    }

    public void SetInitialLegImage()
    {

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



    }


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
            sInt = shoulderList.Count - 1;
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
            eInt = elbowList.Count - 1;
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
            hInt = handList.Count - 1;
            hImage.sprite = hArray[handList[hInt]];
        }

        hImage.sprite = hArray[handList[hInt]];

    }public void HipRightButtonClick()
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
            hiInt = shoulderList.Count - 1;
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
            kInt = kneeList.Count - 1;
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
            fInt = footList.Count - 1;
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
            }
        }
        else { Debug.Log("Leg Build Fail"); }
    }

    public void UncoverBlocker()
    {
        if(armRequestMet && legRequestMet)
        {
            blockers[rewardInt].SetActive(false);
            Request();
        }
    }
}
