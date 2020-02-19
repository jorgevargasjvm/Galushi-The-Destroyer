using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyME());
    }

    IEnumerator destroyME()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

}
