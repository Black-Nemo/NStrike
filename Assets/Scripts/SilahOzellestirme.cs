using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilahOzellestirme : MonoBehaviour
{
    [SerializeField]private atesSistemi atesSistemi;
    
    private bool ozellestirmedemi;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.V)){
            if(ozellestirmedemi){
                atesSistemi.atesEdebilirmi = true;
                atesSistemi.silah.animator.SetBool("ozellestirme",false);
                atesSistemi.silah.silahOzellestirmeMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                ozellestirmedemi = false;
            }else{
                atesSistemi.atesEdebilirmi = false;
                atesSistemi.silah.animator.SetBool("ozellestirme",true);
                atesSistemi.silah.silahOzellestirmeMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                ozellestirmedemi = true;
            }
        }
    }
}
