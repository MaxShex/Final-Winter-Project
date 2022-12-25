using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputZone : MonoBehaviour
{
    [SerializeField] private int houseNum;

    public static Action OnDropDown;
    public static Action<ItemData> OnDescriptionShow;

    private List<GameObject> objects;
    private int counter;
    private bool IsInventoryEmpty = true;

    void Start()
    {
        OutputZone.OnPickUp += CheckInventory;
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
        if(other.GetComponent<Player>().WhichHouse == houseNum)
        {
            if (counter < objects.Count && !IsInventoryEmpty)
                objects[counter].GetComponent<Outline>().OutlineWidth = 3;
            if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
            {
                if (!other.GetComponent<Player>().IsInventoryEmpty)
                {
                    if (counter < objects.Count)
                    {

                        OnDropDown?.Invoke();
                        objects[counter].transform.GetChild(0).gameObject.SetActive(true);
                        IsInventoryEmpty = true;
                        if (counter < objects.Count)
                            objects[counter].GetComponent<Outline>().OutlineWidth = 0;
                        OnDescriptionShow?.Invoke(objects[counter].GetComponent<Item>().GetItemData);
                        counter++;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (counter < objects.Count)
            objects[counter].GetComponent<Outline>().OutlineWidth = 0;
    }

    public void CheckInventory(int a)
    {
        IsInventoryEmpty = false;
    }
}
