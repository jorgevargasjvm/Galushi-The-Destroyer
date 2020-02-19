using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public GameObject ship;
    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-1 * Time.deltaTime * 10f, 0, 0);
    }
}
