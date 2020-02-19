using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSpeed : MonoBehaviour
{
   
    void Update()
    {
        transform.position += new Vector3(-8f * Time.deltaTime, 0, 0);
    }
}
