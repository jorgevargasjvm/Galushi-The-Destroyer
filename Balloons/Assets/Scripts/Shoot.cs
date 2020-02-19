using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    

    // Update is called once per frame

    

    void Update()
    {
        transform.position += new Vector3(-25f * Time.deltaTime, 0, 0);

        if(this.gameObject.GetComponent<SpriteRenderer>().isVisible == false)
        {
            Destroy(this.gameObject);
        }
    }
}
