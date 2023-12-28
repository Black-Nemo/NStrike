using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Linq;
using TMPro;

public class TakimSistemi : NetworkBehaviour
{
    public List<GameObject> oyuncular;

    public Server server;
    public Takim takim1;
    public Takim takim2;

    public TextMeshProUGUI sayacText;

    public bool roundBitti;

    [SyncVar] public float sayac;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sayacText.text = ((int)sayac).ToString();
        if (isServer)
        {
            if (takim1.takimSayi != 0 && takim2.takimSayi != 0)
            {
                Control();
            }
            CmdOyuncuTanimla();
        }
    }

    //[Command(requiresAuthority = false)]
    void CmdOyuncuTanimla()
    {
        GameObject[] _oyuncular = GameObject.FindGameObjectsWithTag("Player");
        oyuncular = _oyuncular.ToList();
    }

    //[Command(requiresAuthority = false)]
    void Control()
    {
        for (int i = 0; i < oyuncular.Count; i++)
        {
            if(oyuncular[i] == null){
                oyuncular.Remove(oyuncular[i]);
            }
            if (oyuncular[i].GetComponent<Takimim>().takimim == 0)
            {
                oyuncular[i].GetComponent<atesSistemi>().atesEdebilirmi = false;
            }
            if (takim1.takimOluSayi != 0 || takim2.takimOluSayi != 0)
            {
                if (takim1.takimSayi == takim1.takimOluSayi)
                {
                    if (!roundBitti)
                    {
                        takim2.takimScore++;
                        MacBitti();
                    }

                }
                else if (takim2.takimSayi == takim2.takimOluSayi)
                {
                    if (!roundBitti)
                    {
                        takim1.takimScore++;
                        MacBitti();
                    }
                }
            }

        }


        if (roundBitti)
        {
            sayac -= 1 * Time.deltaTime;
        }
        if (sayac < 0 && roundBitti == true)
        {
            MacBaslat();
        }
    }


    void MacBitti()
    {
        sayac = 10;
        roundBitti = true;
        print("Mac bitti");
    }


    void MacBaslat()
    {
        print("Mac basladi");
        foreach (var i in oyuncular)
        {
            i.GetComponent<Can>().CmdCanlandim();
        }
        Invoke("RoundBasladi",0.5f);
    }

    void RoundBasladi()
    {
        roundBitti = false;
    }
}
