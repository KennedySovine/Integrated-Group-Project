using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOptions : MonoBehaviour
{
    private OPTIONSANDPM options;

    void Start(){
        options = OPTIONSANDPM.Instance;
    }
}
