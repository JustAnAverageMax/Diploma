using System;
using UnityEngine;
using System.Collections.Generic;

public class HandCardSlotsManager : MonoBehaviour
{
	[SerializeField] private List<GameObject> slots;
	
	
	public Transform leftBound;
	public Transform rightBound;
	
	public List<GameObject> Slots
	{
		get => slots;
		set => slots = value;
	}

	public void AddNewSlot(Component sender, object data)
    {
	    GameObject slot = Instantiate(leftBound.gameObject, sender.transform.position, Quaternion.identity); 
	    //slot.transform.parent = transform;
	    slot.name = (slots.Count + 1).ToString();
	    slots.Add(slot);
	    ReArrangeSlots(sender, data);
    }

    public void RemoveSlot(Component sender, object data)
    {
	    GameObject slotObject = slots[(int) data];
	    slots.Remove(slotObject);
	    Destroy(slotObject);
	    ReArrangeSlots(sender, data);
    }

    public void ReArrangeSlots(Component sender, object data)
    {
	    if (slots.Count <= 0) return;
	    Vector3 firstElementPos = leftBound.transform.position;
	    Vector3 lastElementPos = rightBound.transform.position;

	    float xDist = (lastElementPos.x - firstElementPos.x) / (slots.Count + 1);

	    Vector3 dist = new Vector3(xDist, 0, 0);
	    slots[0].transform.position = firstElementPos + dist;
		
	    for (int i = 1; i < slots.Count; i++)
	    {
		    slots[i].transform.position = slots[i - 1].transform.position + dist;
	    }
    }
}
