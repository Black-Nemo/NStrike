using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Mermi : NetworkBehaviour
{

    void Start()
    {
        //gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward*7000);
        Destroy(gameObject,10f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*5000);
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        //CmdOnTriggerEnter(other.gameObject);
    }


}
