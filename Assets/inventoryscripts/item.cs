using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Tiem", menuName = "Inventory/new item")]
public class item : ScriptableObject
{
    //����������
    public string Name;
   public string describe;
    //������Ŀ
    public int numItem;
   public bool isGet;//�жϴ˵����Ƿ񱻻�ȡ
    public string Cd;
    public string RollTime;//��ҡ
}
