using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class TakimSecimi : NetworkBehaviour
{
    public Server server;
    public TakimSistemi takimSistemi;
    public UIManager uIManager;
    int takim;

    public void TakimSec(int _takim)
    {
        CmdTakimSec(_takim, server._localPlayer.GetComponent<ID>()._ID);
        uIManager.panel = UIManager.Panels.gamePanel;
    }


    [Command(requiresAuthority = false)]
    private void CmdTakimSec(int _takim, int id)
    {
        GameObject oyuncu = GameObject.Find(id.ToString());
        if (oyuncu.GetComponent<Takimim>().takimim == 1)
        {
            takimSistemi.takim1.takimOyuncular.Remove(oyuncu);
            takimSistemi.takim1.takim_Canli.Remove(oyuncu);
            takimSistemi.takim1.takim_Olu.Remove(oyuncu);
        }
        else if (oyuncu.GetComponent<Takimim>().takimim == 2)
        {
            takimSistemi.takim2.takimOyuncular.Remove(oyuncu);
            takimSistemi.takim2.takim_Canli.Remove(oyuncu);
            takimSistemi.takim2.takim_Olu.Remove(oyuncu);
        }

        if (_takim == 1)
        {
            oyuncu.GetComponent<Takimim>().takimim = 1;
            takimSistemi.takim1.takimOyuncular.Add(oyuncu);
        }
        else if (_takim == 2)
        {
            oyuncu.GetComponent<Takimim>().takimim = 2;
            takimSistemi.takim2.takimOyuncular.Add(oyuncu);
        }
    }
}
