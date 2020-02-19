using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool isPaused = false, shipisDead = false;
    public GameObject pause;
    public Sprite pausedImage, playImage;
    private float HeliumAmmountF = 1;
    public TextMeshProUGUI heliumText;
    ShipBeh ship;
    public GameObject YouWinPanel, YouLosePanel, PausePanel;

    
    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.Find("SpaceShip").GetComponent<ShipBeh>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shipisDead == false)
        {
            CalculatePause();
        }
        
        CalculateHeliumLevel();
        if (shipisDead)
        {
            YouLosePanel.SetActive(true);
            
        }

        if(HeliumAmmountF >= 100)
        {
            YouWinPanel.SetActive(true);
        }

        if(HeliumAmmountF <= 0)
        {
            ship.ExplodeShip();
            shipisDead = true;
        }


    }

    private void CalculatePause()
    {
        if (isPaused)
        {
            pause.GetComponent<Image>().sprite = pausedImage;
            PausePanel.SetActive(true);
       
        }
        else if (!isPaused)
        {
            pause.GetComponent<Image>().sprite = playImage;
            PausePanel.SetActive(false);
            
        }
    }

    private void CalculateHeliumLevel()
    {
        if(HeliumAmmountF < 10)
        {
            heliumText.text = "000" + HeliumAmmountF.ToString();
        }
        else if(HeliumAmmountF < 100)
        {
            heliumText.text = "00" + HeliumAmmountF.ToString();
        }
        else if(HeliumAmmountF < 1000)
        {
            heliumText.text = "0" + HeliumAmmountF.ToString();
        }
        else if(HeliumAmmountF < 10000)
        {
            heliumText.text = HeliumAmmountF.ToString();
        }
    }


    public void Pause_Play()
    {
        if (shipisDead == false)
        {
            if (isPaused)
            {
                isPaused = false;
                Time.timeScale = 1;
            }
            else if (!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0;
            }
        }
       
     
       
    }

    public void setHeliumAmmount(float ammount)
    {
        HeliumAmmountF += ammount;
        if(HeliumAmmountF < 0)
        {
            HeliumAmmountF = 0;
        }
    }

    public void setShipState(bool shipDead)
    {
        shipisDead = shipDead;
    }

    public bool getPauseState()
    {
        return isPaused;
    }

}
