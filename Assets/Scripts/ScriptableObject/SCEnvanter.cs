using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Envanter",menuName ="Scriptable/Envanter")]
public class SCEnvanter : ScriptableObject {
    public List<Slot> envanterSlots = new List<Slot>();
    public int StackLimit = 5;
    public bool AddItem(SCItem _item){
        foreach(Slot slot in envanterSlots){
            if(slot.item == _item){
                if(slot.item.canStackable == true){
                    if(slot.itemCount < _item.maxStack){
                        slot.itemCount++;
                        if(slot.itemCount >= _item.maxStack){
                            slot.isfull=true;
                        }
                        return true;
                    }
                }
            }
            else if(slot.itemCount == 0)
            {
                slot.AddItemToSlot(_item);
                return true;
            }
        }
        return false;
    }

}

[System.Serializable]
public class Slot{
    public bool isfull;
    public int itemCount;
    public SCItem item;

    public void AddItemToSlot(SCItem _item){
        item = _item;
        if(item.canStackable == false){
            isfull = true;
        }
        itemCount++;
    }
}
