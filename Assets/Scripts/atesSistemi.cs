using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
public class atesSistemi : NetworkBehaviour
{
    [SyncVar] public string elimdekiSilahAdi;
    [SyncVar] public int hangincil;
    public GameObject birincil;
    public GameObject ikincil;
    public GameObject[] silahlar;
    public GameObject[] birincilSilahlar;
    public GameObject[] ikincilSilahlar;

    [SyncVar] public string sifirincilSilahim;
    [SyncVar] public string birincilSilahim;
    [SyncVar] public string ikincilSilahim;

    public GameObject elimdekiSilahim;


    [SyncVar] public int _ID;
    public float zaman;

    public Recoil recoil;

    RaycastHit hit;




    public TextMeshProUGUI MermiSayi;


    [SyncVar] public bool atesEdebilirmi;

    public Obje obje;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            obje = GameObject.Find("Obje").GetComponent<Obje>();
            MermiSayi = obje.MermiSayi;
        }
    }

    [ClientRpc]
    public void RpcSilahDeğisti(int _hangicil)
    {
        if (_hangicil == 0)
        {
            birincil.SetActive(false);
            ikincil.SetActive(false);
            elimdekiSilahAdi = sifirincilSilahim;
        }
        if (_hangicil == 1)
        {
            birincil.SetActive(true);
            ikincil.SetActive(false);
            elimdekiSilahAdi = birincilSilahim;
        }
        if (_hangicil == 2)
        {
            birincil.SetActive(false);
            ikincil.SetActive(true);
            elimdekiSilahAdi = ikincilSilahim;
        }
        foreach (GameObject i in silahlar)
        {
            if (elimdekiSilahAdi == i.GetComponent<Silah>().Adim)
            {
                elimdekiSilahim = i;
                silah = elimdekiSilahim.GetComponent<Silah>();

                elimdekiSilahim.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }
        }

    }

    [Command]
    public void CmdSilahDeğisti(int _hangicil)
    {
        hangincil = _hangicil;
        if (_hangicil == 0)
        {
            birincil.SetActive(false);
            ikincil.SetActive(false);
            elimdekiSilahAdi = sifirincilSilahim;
        }
        if (_hangicil == 1)
        {
            birincil.SetActive(true);
            ikincil.SetActive(false);
            elimdekiSilahAdi = birincilSilahim;
        }
        if (_hangicil == 2)
        {
            birincil.SetActive(false);
            ikincil.SetActive(true);
            elimdekiSilahAdi = ikincilSilahim;
        }
        foreach (GameObject i in silahlar)
        {
            if (elimdekiSilahAdi == i.GetComponent<Silah>().Adim)
            {
                elimdekiSilahim = i;
                silah = elimdekiSilahim.GetComponent<Silah>();
                elimdekiSilahim.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }
        }
        RpcSilahDeğisti(_hangicil);
    }

    public Silah silah;
    void Update()
    {
        if (isLocalPlayer)
        {
            MermiSayi.text = (silah.sarjordekiMermiSayisi + " / " + silah.geriyeKalanMermiSayisi);
            /*
            foreach(RuntimeAnimatorController i in _animations.animasyonlar){
                if(elimdekiSilahAdi == i.name){
                    _animations.anim.runtimeAnimatorController = i;
                }
            }
            */

            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                CmdSilahDeğisti(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CmdSilahDeğisti(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CmdSilahDeğisti(2);
            }

            if (silah.sarjordekiMermiSayisi > 0)
            {
                if (atesEdebilirmi == true)
                {
                    if (silah.atesMode == 1)
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse0))
                        {
                            Ates();
                        }
                    }
                    if (silah.atesMode == 2)
                    {
                        if (Input.GetKey(KeyCode.Mouse0))
                        {
                            Ates();
                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Skop(1);
                obje.Cross.SetActive(false);
            }
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                Skop(0);
                obje.Cross.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (silah.sarjordekiMermiSayisi != silah.sarjorKapasite)
                {
                    if (silah.geriyeKalanMermiSayisi != 0)
                    {
                        int alinacakMermi = silah.sarjorKapasite - silah.sarjordekiMermiSayisi;
                        if (alinacakMermi <= silah.geriyeKalanMermiSayisi)
                        {
                            CmdSarjor(alinacakMermi);
                            alinacakMermi = 0;
                        }
                        if (alinacakMermi > silah.geriyeKalanMermiSayisi)
                        {
                            CmdSarjor(silah.geriyeKalanMermiSayisi);
                            alinacakMermi = 0;

                        }
                    }

                }
            }
            if(silah != null){
                silah.MermiSayi_Text.text = silah.sarjordekiMermiSayisi.ToString()+"/"+silah.geriyeKalanMermiSayisi.ToString();
            }
        }
    }

    [Command]
    void CmdSarjor(int _alinacakMermi)
    {
        silah.sarjordekiMermiSayisi += _alinacakMermi;
        silah.geriyeKalanMermiSayisi -= _alinacakMermi;
    }



    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            zaman += 1 * Time.deltaTime;
            if (zaman >= silah.atisSikligi)
            {
                CmdAnim();
            }
        }
    }

    public void Ates()
    {
        if (isLocalPlayer)
        {
            if (zaman >= silah.atisSikligi)
            {
                CmdAtes();
                zaman = 0;
            }
        }

    }

    [Command]
    void CmdAtes()
    {
        silah.sarjordekiMermiSayisi--;
        if (Physics.Raycast(silah.namluUcu.transform.position, silah.namluUcu.transform.forward, out hit, 300))
        {
            GameObject _mermiDegme = Instantiate(silah.MermiDegme, hit.point, Quaternion.identity);
            _mermiDegme.GetComponent<MermiDegme>().hasar = silah.hasar;
            _mermiDegme.GetComponent<MermiDegme>().vuranId = _ID;
            NetworkServer.Spawn(_mermiDegme);
            GameObject _delik = Instantiate(silah.Delik, hit.point, Quaternion.LookRotation(hit.normal));
            NetworkServer.Spawn(_delik);
            GameObject _mermi = Instantiate(silah.Mermi, silah.namluUcu.position, silah.namluUcu.transform.rotation);
            NetworkServer.Spawn(_mermi);
        }
        zaman = 0;
        recoil.CmdAtes();
        AtisaHazir();
        //NetworkServer.Spawn(_mermi);
    }

    [ClientRpc]
    void AtisaHazir()
    {
        silah.animator.SetInteger("Ates", 1);
        if (silah.namluMode == 1)
        {
            if (silah.AtesSes != null)
            {
                silah.AtesSes.pitch = 1.7f;
            }
        }
        if (silah.namluMode == 0)
        {
            if (silah.AtesSes != null)
            {
                silah.AtesSes.pitch = 1.7f;
            }
        }
        if (silah.AtesSes != null)
        {
            silah.AtesSes.Play();
        }
        if (silah.Muzzle != null)
        {
            silah.Muzzle.Play();
        }
        /*
        if (Physics.Raycast(namluUcu.transform.position, namluUcu.transform.forward, out hit, 300))
        {
            Instantiate(Delik, hit.point, Quaternion.LookRotation(hit.normal));
            Instantiate(Mermi, namluUcu.position, namluUcu.transform.rotation);
        }*/
        GameObject _kovan = Instantiate(silah.Kovan, silah.kovanCikis.position, gameObject.transform.rotation);
        _kovan.transform.SetParent(silah.kovanCikis.transform);
        _kovan.GetComponent<Rigidbody>().AddForce(_kovan.transform.right * Random.Range(200, 500));
        _kovan.GetComponent<Rigidbody>().AddForce(_kovan.transform.up * Random.Range(10, 30));
    }

    [Command]
    void CmdAnim()
    {
        RpcAnim();
    }

    [ClientRpc]
    void RpcAnim()
    {
        silah.animator.SetInteger("Ates", 0);
    }

    public void Skop(int _deger)
    {
        if (isLocalPlayer)
        {
            if (_deger == 1)
            {
                if (silah.durbunMode == 0)
                {
                    CmdSkop(_deger);
                }
                if (silah.durbunMode == 1)
                {
                    CmdSkop(2);
                }
            }
            if (_deger == 0)
            {
                CmdSkop(_deger);
            }
        }
    }
    [Command]
    public void CmdSkop(int _deger)
    {
        RpcSkop(_deger);
    }
    [ClientRpc]
    public void RpcSkop(int _deger)
    {
        silah.animator.SetInteger("Skop", _deger);
    }
}
