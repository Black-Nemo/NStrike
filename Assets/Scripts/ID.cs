using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ID : NetworkBehaviour
{
    [SyncVar] public int _ID;
    public atesSistemi atessistemi;



    public override void OnStartClient()
    {
        base.OnStartClient();
        if (isLocalPlayer)
        {
            CmdOnStartClient();
        }

    }

    [Command]
    public void CmdOnStartClient()
    {

    }
    [ClientRpc]
    public void RpcOnStartClient(int id)
    {
        gameObject.name = id.ToString();
    }


    void Start()
    {
        CmdStart();
    }
    [Command]
    void CmdStart()
    {
        Server server = GameObject.Find("Server").GetComponent<Server>();
        server.YeniOyuncuKatildi();
    }

    void LateUpdate()
    {
        if (isLocalPlayer)
        {
            CmdUpdate();
        }

    }

    [Command]
    void CmdUpdate()
    {
        if (_ID == 0)
        {
            _ID = Random.Range(000000000, 999999999);
            gameObject.name = _ID.ToString();
            RpcOnStartClient(_ID);
        }
        else
        {
            RpcOnStartClient(_ID);
        }
        if (atessistemi._ID == 0)
        {
            atessistemi._ID = _ID;
        }
    }
}
