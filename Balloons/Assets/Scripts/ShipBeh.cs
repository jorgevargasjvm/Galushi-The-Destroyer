using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBeh : MonoBehaviour
{

    
    float shipSpeed = 3f;
    float mousePosWhileClicking;

    Vector2 _mousePosition;
    public GameObject shooTPrefab, explosion, shootPivot;
    bool canShoot = true, isDead = false;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {


        ShipMoveCalculation();
        if(gameManager.getPauseState() == false)
        {
            ShipMovement();
        }
       
       
        
    }

    private void ShipMoveCalculation()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shipSpeed += -10f * Time.deltaTime;
    }

    private void ShipMovement()
    {
        if (canShoot)
        {
            shoot();
            canShoot = false;
            StartCoroutine(shootingRate());
        }


        if (Input.GetButton("Fire1"))
        {

            transform.position = new Vector3(shipSpeed, _mousePosition.y, 0);
            mousePosWhileClicking = _mousePosition.y;

        }
        else if (!Input.GetButton("Fire1"))
        {
            transform.position = new Vector3(shipSpeed, mousePosWhileClicking, 0);
        }

    }


    IEnumerator shootingRate()
    {
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }

    private void shoot()
    {
        Instantiate(shooTPrefab, shootPivot.transform.position, shootPivot.transform.rotation);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Wall" || collision.transform.tag == "UpWall")
        {
            ExplodeShip();
        }

    }

    public void ExplodeShip()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        gameManager.setShipState(true);
        Destroy(this.gameObject);
    }


}
