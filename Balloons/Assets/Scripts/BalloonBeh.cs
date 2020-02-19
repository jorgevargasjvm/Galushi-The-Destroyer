using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBeh : MonoBehaviour
{
    float speed;
   
    private GameManager gameManager;
    public GameObject red, blue, purple;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(this.transform.tag == "Blue")
        {
            speed = Random.Range(5f, 8f);
        }
        else
        {
            speed = Random.Range(1f, 3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += (Vector3.up * speed * Time.deltaTime) + new Vector3 (-8f * Time.deltaTime,0,0);


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "UpWall")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            Destroy(collision.transform.gameObject);
            if(this.transform.tag == "Blue")
            {
                Instantiate(blue, transform.position, transform.rotation);
                gameManager.setHeliumAmmount(10);
            }
            else if (this.transform.tag == "Red")
            {
                Instantiate(red, transform.position, transform.rotation);
                gameManager.setHeliumAmmount(1);
            }
            else if(this.transform.tag == "Purple")
            {
                Instantiate(purple, transform.position, transform.rotation);
                gameManager.setHeliumAmmount(1);
            }


           
            Destroy(this.gameObject);
        }
    }
}
