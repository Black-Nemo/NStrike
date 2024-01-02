using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilahOzellestirmeMenu : MonoBehaviour
{
    [SerializeField]private Silah silah;
    public void DurbunDegistir(int sayi){
        silah.CmdDurbunDegistir(sayi);
    }

    public void NamluDegistir(int sayi){
        silah.CmdNamluDegistir(sayi);
    }
}
