using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class Silah : NetworkBehaviour
{
    public string Adim;

    [SyncVar]public int durbunMode;
    [SyncVar]public int namluMode;

    public GameObject[] durbunler;
    public GameObject[] namluUcları;


    [Space]
    public int hasar;


    [Space]
    public float atisSikligi;
    [SyncVar]public int atesMode; //1 = tekli 2 = tarama

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

    [SyncVar]public int sarjordekiMermiSayisi;
    [SyncVar]public int geriyeKalanMermiSayisi;
    public int sarjorKapasite;
    public int geriyeKalanKapasite;


    public TextMeshProUGUI MermiSayi_Text;

}
