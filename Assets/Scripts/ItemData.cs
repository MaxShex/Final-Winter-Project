using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "SO/NewItemData")]
public class ItemData : ScriptableObject
{
    public string name;
    public string description;
    public int houseNum;
}