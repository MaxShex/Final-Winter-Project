using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OutputZone : MonoBehaviour
{
    public static Action<int> OnPickUp;
    public static Action<ItemData> OnDescriptionShow;

    private List<GameObject> objects;
    private int counter;
    private bool IsInventoryEmpty = true;

    void Start()
    {
        InputZone.OnDropDown += CheckInventory;
        objects = new List<GameObject>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            objects.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
            
    }

    private void OnTriggerStay(Collider other)
    {
        if (counter < objects.Count && IsInventoryEmpty)
            objects[counter].GetComponent<Outline>().OutlineWidth = 3;
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (other.GetComponent<Player>().IsInventoryEmpty)
            {
                if (counter < objects.Count)
                {
                    OnPickUp?.Invoke(objects[counter].GetComponent<Item>().GetItemData.houseNum);
                    IsInventoryEmpty = false;
                    OnDescriptionShow?.Invoke(objects[counter].GetComponent<Item>().GetItemData);
                    objects[counter].SetActive(false);
                    counter++;
                }
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (counter < objects.Count)
            objects[counter].GetComponent<Outline>().OutlineWidth = 0;
    }

    public void CheckInventory()
    {
        IsInventoryEmpty = true;
    }
}
