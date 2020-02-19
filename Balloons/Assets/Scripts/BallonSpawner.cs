using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonSpawner : MonoBehaviour
{
    public GameObject redBalloon, purpleBalloon, BlueBalloon;
    private GameObject balloonholder;
    bool isredBaloon = false;
    float xPos = 0;
    int balloonSelector = 0;

    // Update is called once per frame
    void Update()
    {
        if (!isredBaloon)
        {
            isredBaloon = true;
            StartCoroutine(spawnRedBaloon());
        }
        Debug.Log(balloonSelector);
       
    }

    IEnumerator spawnRedBaloon()
    {
        yield return new WaitForSeconds(1.5f);
        RandomizeSpawnPos();
        ChooseBalloon();
        Instantiate(balloonholder, new Vector3 (transform.position.x + xPos,transform.position.y,transform.position.z), transform.rotation);
        isredBaloon = false;

    }

    private void ChooseBalloon()
    {
        balloonSelector = Random.Range(1, 4);
        switch (balloonSelector)
        {
            case 1:
                balloonholder = redBalloon;
                break;
            case 2:
                balloonholder = BlueBalloon;
                break;
            case 3:
                balloonholder = purpleBalloon;
                break;
            default:
                balloonholder = redBalloon;
                break;

        }
    }

    private void RandomizeSpawnPos()
    {
        xPos = Random.Range(-4f, 5f);
    }
}
