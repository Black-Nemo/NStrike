using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SarjorDoldur : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (isServer)
        {
            if (other.gameObject.tag == "Govde")
            {
                other.GetComponent<Parca>().Player.GetComponent<atesSistemi>().silah.geriyeKalanMermiSayisi += 30;
                Destroy(gameObject);
            }
        }
    }
}
