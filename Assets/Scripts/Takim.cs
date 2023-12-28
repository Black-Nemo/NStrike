using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class Takim : NetworkBehaviour
{
    [SyncVar] public int takimScore;
    [SyncVar] public int takimSayi;
    [SyncVar] public int takimCanliSayi;
    [SyncVar] public int takimOluSayi;
    public List<GameObject> takimOyuncular;
    public List<GameObject> takim_Canli;
    public List<GameObject> takim_Olu;

    public Transform spawnTransform;

    public TextMeshProUGUI skorText;
    public TextMeshProUGUI oyuncuSayiText;
    private void Update()
    {
        skorText.text = takimScore.ToString();
        oyuncuSayiText.text = takimSayi.ToString() + "/" + takimCanliSayi.ToString();
        if (isServer)
        {
            takimSayi = takimOyuncular.Count;
            takimCanliSayi = takim_Canli.Count;
            takimOluSayi = takim_Olu.Count;
        }

        foreach (var i in takimOyuncular)
        {
            if (i.GetComponent<Can>().oldum == false && !takim_Canli.Contains(i))
            {
                takim_Canli.Add(i);
            }
            else if (i.GetComponent<Can>().oldum == true && takim_Canli.Contains(i))
            {
                takim_Canli.Remove(i);
            }
            else if (i.GetComponent<Can>().oldum == true && !takim_Olu.Contains(i))
            {
                takim_Olu.Add(i);
            }
            else if (i.GetComponent<Can>().oldum == false && takim_Olu.Contains(i))
            {
                takim_Olu.Remove(i);
            }
            if (i == null)
            {
                takimOyuncular.Remove(i);
            }
        }
        foreach (var i in takim_Olu)
        {
            if (i == null)
            {
                takim_Olu.Remove(i);
            }
        }
        foreach (var i in takim_Canli)
        {
            if (i == null)
            {
                takim_Canli.Remove(i);
            }
        }
    }
}
