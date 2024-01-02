using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class Silah : NetworkBehaviour
{
    public string Adim;

    [SyncVar] public int durbunMode;
    [SyncVar] public int namluMode;

    public GameObject[] durbunler;
    public GameObject[] namluUcları;


    [Space]
    public int hasar;


    [Space]
    public float atisSikligi;
    [SyncVar] public int atesMode; //1 = tekli 2 = tarama

    public Animator animator;
    public Transform namluUcu;
    public Transform kovanCikis;

    public GameObject Mermi;
    public GameObject MermiDegme;
    public GameObject Kovan;


    public AudioSource AtesSes;
    public GameObject Delik;
    RaycastHit hit;

    public ParticleSystem Muzzle;

    [SyncVar] public int sarjordekiMermiSayisi;
    [SyncVar] public int geriyeKalanMermiSayisi;
    public int sarjorKapasite;
    public int geriyeKalanKapasite;


    public TextMeshProUGUI MermiSayi_Text;

    public GameObject silahOzellestirmeMenu;

    private void Update()
    {
        if (durbunMode == 0)
        {
            foreach (var i in durbunler)
            {
                i.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < durbunler.Length; i++)
            {
                if (i == durbunMode - 1)
                {
                    durbunler[i].SetActive(true);
                }
                else
                {
                    durbunler[i].SetActive(false);
                }

            }
        }




        if (namluMode == 0)
        {
            foreach (var i in namluUcları)
            {
                i.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < namluUcları.Length; i++)
            {
                if (i == namluMode - 1)
                {
                    namluUcları[i].SetActive(true);
                }
                else
                {
                   namluUcları[i].SetActive(false);
                }

            }
        }
    }

    [Command]
    public void CmdDurbunDegistir(int sayi){
        durbunMode = sayi;
    }

    [Command]
    public void CmdNamluDegistir(int sayi){
        namluMode = sayi;
    }

}
