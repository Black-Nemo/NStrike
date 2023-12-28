using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;


public class raycast : NetworkBehaviour
{
    public Envanter envanter;
    public GameObject goz;
    RaycastHit hit;
    public GameObject ItemName_text;

    public GameObject Obje;

    private void Start() {
        Obje = GameObject.Find("Obje");
        ItemName_text = Obje.GetComponent<Obje>().ItemName_text;
    }

    private void Update() {
        if(isLocalPlayer){
            Ray();
        }
    }

    public void Ray(){
        if(Physics.Raycast(goz.transform.position,goz.transform.forward,out hit,3)){
            print(hit.transform.gameObject);
            if(hit.transform.tag=="Item"){
                ItemName_text.SetActive(true);
                ItemName_text.GetComponent<TextMeshProUGUI>().text = hit.transform.gameObject.GetComponent<Item>().item.itemName;
                if(Input.GetKeyDown(KeyCode.F)){
                    CmdRay(hit.transform.gameObject);
                }

            }else{
                ItemName_text.SetActive(false);
            }
        }
    }

    [Command]
    public void CmdRay(GameObject _hit){
        if(envanter.SCenvanter.AddItem(_hit.GetComponent<Item>().item)){
            NetworkServer.Destroy(_hit);
        }
    }

}

