using UnityEngine;
[CreateAssetMenu(fileName = "New Chef", menuName = "Chef")]
public class ChefStats : ScriptableObject
{
    public string Name;
    public float timeToCook = 2;
    public Sprite icon;
}
