using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Mirror;

public class OlumMesaj : NetworkBehaviour
{
    public float zaman;
    public OlumMesajTablo olumMesajTablo;

    [SyncVar]public int oldurenIsim;
    [SyncVar]public int olenIsim;


    public TextMeshProUGUI olduren;
    public TextMeshProUGUI olen;

    public Image silah;
    public Image kuruKafa;


    public int baslangictakisayi;

    private void Start() {
        olumMesajTablo = GameObject.Find("Olenler").GetComponent<OlumMesajTablo>();
        olumMesajTablo.sayi++;
        baslangictakisayi = olumMesajTablo.sayi;
        Transform _parent =GameObject.Find("Olenler").transform;
        gameObject.transform.SetParent(_parent);
        gameObject.transform.localPosition=new Vector3(0,-110,0);
        gameObject.transform.localScale= new Vector3(1,1,1);
    }
    private void LateUpdate() {
        zaman+=1*Time.deltaTime;
        transform.Translate(0,10*Time.deltaTime,0);
        if(baslangictakisayi<olumMesajTablo.sayi){
            if(zaman<3){
                transform.localPosition += new Vector3(0,30,0);
                zaman = 3.5f;
            }
        }
        if(zaman>10){
            Destroy(gameObject);
        }
        
        olduren.text = oldurenIsim.ToString();
        olen.text = olenIsim.ToString();
    }
}
