using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class Server : NetworkBehaviour
{
    public GameObject _localPlayer;

    [SyncVar] public bool macBitti;

    public float zaman;
    // Start is called before the first frame update
    void Start()
    {
    }

    //[Command(requiresAuthority = false)]
    public void Vurulma(int _vuran, int _vurulan, int _hasar, int headShotmi, GameObject mermiDegmeObje)
    {
        if (isServer)
        {
            RpcVurulma(_vuran, _vurulan, _hasar, headShotmi);
            objeDelete(mermiDegmeObje);
            //GameObject.Find(_vurulan.ToString()).GetComponent<Can>().Vuruldum(_vuran,_hasar,headShotmi);  
        }
    }

    [ClientRpc]
    public void RpcVurulma(int _vuran, int _vurulan, int _hasar, int headShotmi)
    {
        if (_localPlayer.GetComponent<ID>()._ID == _vurulan)
        {
            GameObject.Find(_vurulan.ToString()).GetComponent<Can>().Vuruldum(_vuran, _hasar, headShotmi);
        }
    }

    public GameObject olumMesaj;

    //[Command(requiresAuthority = false)]
    public void Olme(int _vuran, int _vurulan, int headShotmi)
    {
        if (isServer)
        {
            GameObject _olumMesaj = Instantiate(olumMesaj, new Vector3(0, -110, 0), Quaternion.identity);
            _olumMesaj.GetComponent<OlumMesaj>().oldurenIsim = _vuran;
            _olumMesaj.GetComponent<OlumMesaj>().olenIsim = _vurulan;
            NetworkServer.Spawn(_olumMesaj);
        }
    }

    public void objeDelete(GameObject _gameObject)
    {
        Destroy(_gameObject);
    }


    void Update()
    {
        if (isServer)
        {
            CmdUpdate();
        }

    }


    [Server]
    void CmdUpdate()
    {
    }

    public void YeniOyuncuKatildi()
    {
        CmdYeniOyuncuKatildi();
    }
    
    void CmdYeniOyuncuKatildi()
    {
        if (isServer)
        {
            TakimSistemi takimSistemi = GameObject.Find("TakimSistemi").GetComponent<TakimSistemi>();
            foreach (var i in takimSistemi.oyuncular)
            {
                i.GetComponent<atesSistemi>().RpcSilahDeğisti(i.GetComponent<atesSistemi>().hangincil);
                print("ara: " + i.name);
            }
        }

    }
    void RpcYeniOyuncuKatildi()
    {

    }
}
