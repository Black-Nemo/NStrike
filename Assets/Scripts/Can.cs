using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Mirror;

public class Can : NetworkBehaviour
{

    [SyncVar] public int can = 100;
    [SyncVar] public bool oldum = true;
    public GameObject Obje;
    public GameObject Death;
    public GameObject kararmaEfekt;
    public Slider CanSlider;
    public TextMeshProUGUI CanText;

    public atesSistemi atessistemi;

    public karakterHareketPC karakterhareketPC;

    public Server server;

    public AudioSource olumSes;
    void Start()
    {
        Obje = GameObject.Find("Obje");
        CanSlider = Obje.GetComponent<Obje>().CanSlider;
        CanText = Obje.GetComponent<Obje>().CanText;
        server = GameObject.Find("Server").GetComponent<Server>();
        if (isLocalPlayer)
        {
        }
    }

    [Command]
    public void Vuruldum(int _vuran, int _hasar, int headShotmi)
    {
        if (can - _hasar <= 0)
        {
            server = GameObject.Find("Server").GetComponent<Server>();
            int _vurulan = gameObject.GetComponent<ID>()._ID;
            print(_vuran.ToString() + _vurulan.ToString() + headShotmi.ToString());
            server.Olme(_vuran, _vurulan, headShotmi);
        }
        can -= _hasar;

    }

    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            if (!oldum)
            {
                kararmaEfekt = Obje.GetComponent<Obje>().kararmaEfekt;
                kararmaEfekt.SetActive(false);
                Death = Obje.GetComponent<Obje>().Death;
                Death.SetActive(false);
            }

            server._localPlayer = gameObject;

            CanText.text = can.ToString();
            CanSlider.value = can;
            if (can <= 0 && !oldum)
            {
                kararmaEfekt = Obje.GetComponent<Obje>().kararmaEfekt;
                kararmaEfekt.SetActive(true);
                Death = Obje.GetComponent<Obje>().Death;
                Death.SetActive(true);
                gameObject.transform.position = Obje.GetComponent<Obje>().spawn.position;
                Oldum();
            }
        }
    }

    [SyncVar] public int Oses;
    [Command]
    void Oldum()
    {
        oldum = true;
        can = 0;
        atessistemi.atesEdebilirmi = false;
        RpcOldum(Oses);
        Oses++;
    }

    [ClientRpc]
    void RpcOldum(int _Oses)
    {
        if (_Oses == 0)
        {
            olumSes.Play();
        }
    }



    public void Canlandim()
    {
        CmdCanlandim();
    }

    public void CmdCanlandim()
    {
        oldum = false;
        can = 100;
        atessistemi.atesEdebilirmi = true;
        Oses = 0;
        if (gameObject.GetComponent<atesSistemi>().silah != null)
        {
            gameObject.GetComponent<atesSistemi>().silah.sarjordekiMermiSayisi = gameObject.GetComponent<atesSistemi>().silah.sarjorKapasite;
            gameObject.GetComponent<atesSistemi>().silah.geriyeKalanMermiSayisi = gameObject.GetComponent<atesSistemi>().silah.geriyeKalanKapasite;
            gameObject.GetComponent<atesSistemi>().silah.geriyeKalanMermiSayisi = gameObject.GetComponent<atesSistemi>().silah.geriyeKalanMermiSayisi;
            gameObject.GetComponent<atesSistemi>().silah.geriyeKalanMermiSayisi = gameObject.GetComponent<atesSistemi>().silah.geriyeKalanMermiSayisi;
        }

        RpcCanlandim();
    }

    [ClientRpc]
    void RpcCanlandim()
    {
        if (gameObject.GetComponent<Takimim>().takimim == 0)
        {
            if (Obje.GetComponent<Obje>().spawn.gameObject != null)
            {
                gameObject.transform.position = Obje.GetComponent<Obje>().spawn.position;
            }
            else
            {
                print("Bulunamadi");
            }
        }
        else if (gameObject.GetComponent<Takimim>().takimim == 1)
        {
            if (Obje.GetComponent<Obje>().takim1.spawnTransform.gameObject != null)
            {
                gameObject.transform.position = Obje.GetComponent<Obje>().takim1.spawnTransform.position;
            }
            else
            {
                print("Bulunamadi");
            }
        }
        else if (gameObject.GetComponent<Takimim>().takimim == 2)
        {
            if (Obje.GetComponent<Obje>().takim2.spawnTransform.gameObject != null)
            {
                gameObject.transform.position = Obje.GetComponent<Obje>().takim2.spawnTransform.position;
            }
            else
            {
                print("Bulunamadi");
            }
        }
    }
}