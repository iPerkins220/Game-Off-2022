using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTestScript : MonoBehaviour
{

    public Image sImage, eImage, hImage;
    public Sprite[] sArray;
    public Sprite[] eArray;
    public Sprite[] hArray;

    int randNum;
    int sInt, eInt, hInt;
    int resetInt = 4;

    public int rangeMax = 5, rangeMin = 0, listCount = 5;

    public List<int> randList = new List<int>();
    List<int> shoulderList = new List<int>(new int[5]); 
    List<int> elbowList = new List<int>(new int[5]); 
    List<int> handList = new List<int>(new int[5]);

    List<int> usedNum = new List<int>();

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
        //List<int> shoulderList = new List<int>(new int[listCount]);
        //List<int> elbowList = new List<int>(new int[listCount]);
        //List<int> handList = new List<int>(new int[listCount]);

        
        SetInitialImage();

        for( int i = 0; i < shoulderList.Count; i++) { print("Shoulder " + i + ": " + shoulderList[i].ToString() + " Image Number: " + (shoulderList[i] + 1)); }
        for( int i = 0; i < elbowList.Count; i++) { print("Elbow " + i + ": " + elbowList[i].ToString() + " Image Number: " + (elbowList[i]+ 1)); }
        for( int i = 0; i < handList.Count; i++) { print("Hand " + i + ": " + handList[i].ToString() + " Image Number: " + (i + 1)); }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetInitialImage()
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

    }
}
