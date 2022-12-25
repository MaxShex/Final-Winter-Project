using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "SO/NewItemData")]
public class ItemData : ScriptableObject
{
    public string name;
    [TextArea]
    public string description;
    public int houseNum;
}