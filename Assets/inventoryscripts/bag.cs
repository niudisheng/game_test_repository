using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Tiem", menuName = "Inventory/new item")]
public class bag :ScriptableObject
{
   public List<item> items = new List<item>();
}
