using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class KamreaKontrol : NetworkBehaviour
{
    public GameObject Obje;
    public GameObject Kamera;
    public Transform playerKameraPos;
    // Start is called before the first frame update
    void Start()
    {
        Obje = GameObject.Find("Obje");
        Kamera = Obje.GetComponent<Obje>().Kamera1;
    }

    void LateUpdate()
    {
        if(isLocalPlayer){
            Kamera.transform.SetParent(playerKameraPos);
            Kamera.transform.localPosition=new Vector3(0,0,0);
            Kamera.transform.localRotation=Quaternion.Euler(0,0,0);
       }
    }
}
