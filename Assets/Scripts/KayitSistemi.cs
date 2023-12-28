using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;
using TMPro;

public class KayitSistemi : NetworkBehaviour
{
    public GameObject login;
    public GameObject kayit;


    public TextMeshProUGUI kullaniciAdi_text;
    public TextMeshProUGUI sifre_text;


    public string kullaniciAdi;
    public string sifre;
    public string ID;

    const string glyphs= "abcdefghijklmnopqrstuvwxyz0123456789"; //add the characters you want

    string id;
    public void GirisYap(){
        CmdGirisYap(kullaniciAdi_text.text,sifre_text.text);
    }

    [Command(requiresAuthority = false)]
    public void CmdGirisYap(string _kullaniciAdi, string _sifre){
        kullaniciAdi = _kullaniciAdi;
        sifre = _sifre;

        
        StartCoroutine(GirisYapma());
    }



    public void KayitOl(){

        int charAmount = Random.Range(20, 20); //set those to the minimum and maximum length of your string
        for(int i=0; i<charAmount; i++)
        {
            id += glyphs[Random.Range(0, glyphs.Length)];
        }

        CmdKayitOl(kullaniciAdi_text.text,sifre_text.text,id);

    }

    [Command(requiresAuthority = false)]
    public void CmdKayitOl(string _kullaniciAdi, string _sifre, string _ID){
        kullaniciAdi = _kullaniciAdi;
        sifre = _sifre;
        ID = _ID;


        StartCoroutine(KayitOlma());
    }


    IEnumerator KayitOlma()
    {
        WWWForm form = new WWWForm();
        form.AddField("ovastrike", "kayitOlma");

        form.AddField("kullaniciAdi", kullaniciAdi);
        form.AddField("sifre", sifre);
        form.AddField("ID", ID);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ovastrike.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Sorgu Sonuc" + www.downloadHandler.text);
            }
        }
    }

    IEnumerator GirisYapma()
    {
        WWWForm form = new WWWForm();
        form.AddField("ovastrike", "girisYapma");

        form.AddField("kullaniciAdi", kullaniciAdi);
        form.AddField("sifre", sifre);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ovastrike.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Sorgu Sonuc" + www.downloadHandler.text);
                string _id = www.downloadHandler.text;
                ID = _id.Substring(_id.LastIndexOf("-")+1);

            }
        }
    }
}
