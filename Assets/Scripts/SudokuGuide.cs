using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SudokuGuide : MonoBehaviour
{
    public GameObject GuideMask;
    public GuideNode[] guideSteps;

    private Button currentBtn;
    private GuideNode currentStep;

    private void Start()
    {
        currentStep = guideSteps[0];
        for (int i = 0; i < guideSteps.Length; i++)
        {
            guideSteps[i].next = i + 1 < guideSteps.Length ? guideSteps[i + 1] : null;
        }
        SetSetp();
    }

    public void SetSetp()
    {
        if (currentStep != null)
        {
            GuideMask.SetActive(true);
            currentBtn = Instantiate(currentStep.target.gameObject, GuideMask.transform).GetComponent<Button>();
            currentBtn.onClick.AddListener(OnGuideClick);
        }
    }

    public void OnGuideClick()
    {
        currentStep = currentStep.next;
        Destroy(currentBtn.gameObject);
        GuideMask.SetActive(false);
        SetSetp();
    }
}

[Serializable]
public class GuideNode
{
    public Button target;
    public GuideNode next;
}