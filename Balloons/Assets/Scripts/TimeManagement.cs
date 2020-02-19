using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManagement : MonoBehaviour
{
    public TextMeshProUGUI seconds, minutes;
    float secondsF = 0, minutesF = 0, tenSecCounter = 0;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        secondsF = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeCalculator();
        TenSecHelium();
        
        
    }

    private void TenSecHelium()
    {
        tenSecCounter += Time.deltaTime;
        if (tenSecCounter >= 10)
        {
            tenSecCounter = 0;
            gameManager.setHeliumAmmount(-5f);
        }
    }

    private void TimeCalculator()
    {
        secondsF += Time.deltaTime;

        if (secondsF >= 59)
        {
            minutesF++;
            secondsF = 0;
        }

        if (secondsF <= 9)
        {
            seconds.text = "0" + Mathf.RoundToInt(secondsF).ToString();
        }
        else
        {
            seconds.text = Mathf.RoundToInt(secondsF).ToString();
        }

        if (minutesF <= 9)
        {
            minutes.text = "0" + minutesF.ToString();
        }
        else
        {
            minutes.text = minutesF.ToString();
        }
    }
}
