using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class merdiveneCikma : MonoBehaviour
{
    public bool Merdivendemi;
    void OnTriggerStay(Collider other)
    {
        if(other.tag=="Merdiven"){
            Merdivendemi = true;
        }
    }



    private void OnTriggerExit(Collider other) {
        if(other.tag=="Merdiven"){
            Merdivendemi = false;
        }
    }
}
