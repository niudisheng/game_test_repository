using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")]
    public Text textName;
    public Text textLabel;
    public Image faceImage;


    [Header("UI组件")]
    public TextAsset textFile;
    public int index;
    List<string> text_list = new List<string>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateText(string _name,string _text)
    {
        text_list.Clear();
        text_list.Add(_name);

    }
    public void GetText(string _name)
    {
        var row=textFile.text.Split("\n");
        Debug.Log(row[0]);
    }
}
