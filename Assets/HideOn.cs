using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOn : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
