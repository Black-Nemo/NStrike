using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Gorunurluk : NetworkBehaviour
{
    public GameObject govde;

    void Start()
    {
        if(isLocalPlayer){
            govde.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void Update()
    {
        
    }
}
