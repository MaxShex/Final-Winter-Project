using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputZone : MonoBehaviour
{
    public static Action OnDropDown;

    private List<GameObject> objects;
    private int counter;

    void Start()
    {
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
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (!other.GetComponent<Player>().IsInventoryEmpty)
            {
                if (counter < objects.Count)
                {

                    OnDropDown?.Invoke();
                    objects[counter].SetActive(true);
                    counter++;
                }
            }
        }
    }
}
