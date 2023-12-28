using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Recoil : NetworkBehaviour
{
    public float minX, maxX;
    public float minY, maxY;
    public Vector3 rotS;
    public Vector3 rotC;
    public GameObject silah;
    public GameObject Kamera;
    public karakterHareketPC KarakterHareketPC;
    public void Ates()
    {
        CmdAtes();
    }

    //[Command]
    public void CmdAtes()
    {
        float recx;
        float recy;
        if (KarakterHareketPC.Mode == 0)
        {
            recx = Random.Range(minX, maxX);
            recy = Random.Range(minY, maxY);
            silah.transform.localRotation = Quaternion.Euler(rotS.x, rotS.y + recx, rotS.z);
            Kamera.transform.localRotation = Quaternion.Euler(rotC.x - recy, rotC.y, rotC.z);
        }
        if (KarakterHareketPC.Mode == 1)
        {
            recx = Random.Range(minX * 2, maxX * 2);
            recy = Random.Range(minY * 2, maxY * 2);
            silah.transform.localRotation = Quaternion.Euler(rotS.x, rotS.y + recx, rotS.z);
            Kamera.transform.localRotation = Quaternion.Euler(rotC.x - recy, rotC.y, rotC.z);
        }
        if (KarakterHareketPC.Mode == 2)
        {
            recx = Random.Range(minX * 1.2f, maxX * 1.2f);
            recy = Random.Range(minY * 1.2f, maxY * 1.2f);
            silah.transform.localRotation = Quaternion.Euler(rotS.x, rotS.y + recx, rotS.z);
            Kamera.transform.localRotation = Quaternion.Euler(rotC.x - recy, rotC.y, rotC.z);
        }
    }

    [ClientRpc]
    public void RpcAtes()
    {
        float recx;
        float recy;
        if (KarakterHareketPC.Mode == 0)
        {
            recx = Random.Range(minX, maxX);
            recy = Random.Range(minY, maxY);
            silah.transform.localRotation = Quaternion.Euler(rotS.x, rotS.y + recx, rotS.z);
            Kamera.transform.localRotation = Quaternion.Euler(rotC.x - recy, rotC.y, rotC.z);
        }
        if (KarakterHareketPC.Mode == 1)
        {
            recx = Random.Range(minX * 2, maxX * 2);
            recy = Random.Range(minY * 2, maxY * 2);
            silah.transform.localRotation = Quaternion.Euler(rotS.x, rotS.y + recx, rotS.z);
            Kamera.transform.localRotation = Quaternion.Euler(rotC.x - recy, rotC.y, rotC.z);
        }
        if (KarakterHareketPC.Mode == 2)
        {
            recx = Random.Range(minX * 1.2f, maxX * 1.2f);
            recy = Random.Range(minY * 1.2f, maxY * 1.2f);
            silah.transform.localRotation = Quaternion.Euler(rotS.x, rotS.y + recx, rotS.z);
            Kamera.transform.localRotation = Quaternion.Euler(rotC.x - recy, rotC.y, rotC.z);
        }
    }

    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            CmdUpdate();
        }
    }
    [Command]
    void CmdUpdate()
    {
        RpcUpdate();
    }
    [ClientRpc]
    void RpcUpdate()
    {
        rotS = silah.transform.localRotation.eulerAngles;
        rotC = Kamera.transform.localRotation.eulerAngles;
        if (rotC.x != 0 || rotC.y != 0)
        {
            Kamera.transform.localRotation = Quaternion.Slerp(Kamera.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 3);
        }
        if (rotS.x != 0 || rotS.y != 0)
        {
            silah.transform.localRotation = Quaternion.Slerp(silah.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 3);
        }
    }
}
