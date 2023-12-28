using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public bool canStackable;
    public Sprite itemIcon;
    public GameObject itemYereDusen;
    public int maxStack;
    public int kapladigiYer;
}

