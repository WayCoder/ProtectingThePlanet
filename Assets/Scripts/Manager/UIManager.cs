using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    [SerializeField] private Image darkPanel;

    [SerializeField] private TextMeshProUGUI titleText;

    [SerializeField] private TextMeshProUGUI buttonText;

    [SerializeField] private Image timerImage;

    [SerializeField] private TextMeshProUGUI timeText;



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);

            return;
        }

        instance = this;
    }

    public void SetDarkPanelUI(bool value)
    {
        darkPanel.gameObject.SetActive(value);
    }

    public void SetTitlePanelUI(bool value, string titleText = null, string buttonText = null)
    {
        SetDarkPanelUI(value);

        this.titleText.gameObject.SetActive(value);

        if (value)
        {
            this.titleText.text = titleText;

            this.buttonText.text = buttonText;
        }
    }

    //public void 

   
    public void SetTimerUI(bool value, float amount = 0f, int time = 0)
    {
        timerImage.gameObject.SetActive(value);

        if (value)
        {
            RuntimeDataSO data = GameManager.instance.data;

            timerImage.fillAmount = amount;
       
            timerImage.color = time <= data.gamestateData.gameplayTime / 2 ? data.uiData.timerRedColor : data.uiData.timerBaseColor;

            int seconds = time % 60;

            int minutes = (time / 60) % 60;

            timeText.text = $"{minutes:00}:{seconds:00}";

        }
    }



}
