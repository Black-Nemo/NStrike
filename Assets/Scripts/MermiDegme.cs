using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MermiDegme : NetworkBehaviour
{
    [SyncVar] public int hasar;
    [SyncVar] public int vuranId;
    [SyncVar] public int vurulanId;

    [SyncVar] public GameObject vurulan;

    public bool _Destroy;

    public Server server;
    private void Awake() {
        server = GameObject.Find("Server").GetComponent<Server>();  
    }

    void Start()
    {
        if(!isServer){
            Destroy(gameObject);
        }
        
        if (_Destroy)
        {
            Destroy(gameObject, 0.2f);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (isServer)
        {
            if (other.gameObject.tag == "Kafa")
            {
                vurulan = other.GetComponent<Parca>().Player;
                vurulanId = vurulan.GetComponent<ID>()._ID;
                Vurma(vuranId, vurulanId, hasar * 4, 1);
            }else if (other.gameObject.tag == "Govde")
            {
                vurulan = other.GetComponent<Parca>().Player;
                vurulanId = vurulan.GetComponent<ID>()._ID;
                Vurma(vuranId, vurulanId, hasar, 0);
            }
            else if (_Destroy)
            {
                server.objeDelete(gameObject);
            }
        }
    }

    //[Command(requiresAuthority = false)]
    public void Vurma(int _vuran, int _vurulan, int _hasar, int headShotmi)
    {
        if (_vuran != _vurulan)
        {
            server.Vurulma(_vuran, _vurulan, _hasar, headShotmi,gameObject);
        }
    }

}
