using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTestScript : MonoBehaviour
{

    public Button sLB, sRB, eLB, eRb, hLB, hRB;
    public Image sImage, eImage, hImage;
    public Sprite[] sArray;
    public Sprite[] eArray;
    public Sprite[] hArray;

    int randNum;

    public void RandumNumber()
    {
        randNum = Random.Range(0, 5);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetInitialImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInitialImage()
    {
        RandumNumber();
        int sRInt = randNum;
        sImage.sprite = sArray[sRInt];

        RandumNumber();
        int eRInt = randNum;
        if (eRInt == sRInt) { RandumNumber(); eRInt = randNum; eImage.sprite = eArray[eRInt]; }
        else { eImage.sprite = eArray[eRInt]; }
        

        RandumNumber();
        int hRInt = randNum;
        if (hRInt == sRInt && hRInt == eRInt || hRInt == sRInt || hRInt == eRInt) { RandumNumber(); hRInt = randNum; hImage.sprite = hArray[hRInt]; }
        else { hImage.sprite = hArray[hRInt]; }

    }
}
