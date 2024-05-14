using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZebraLightBlink : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LightSequence());
    }

    IEnumerator LightSequence()
    {
        while (true)
        {
            GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(1);
            GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(1);
        }
  
    }
}
