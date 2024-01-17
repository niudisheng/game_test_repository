using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")]
    public GameObject talk_ui;
    public Text textLabel;
    Image faceImage;
    TMPro.TextMeshPro textMeshPro;

    [Header("UI组件")]
    public TextAsset textFile;
    public int index;
    public int max_index= 0;
    List<string> text_list = new List<string>();
    void Start()
    {
        talk_ui.SetActive(false);
        max_index = GetText(textFile);
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {   

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(talk_ui.activeSelf);
            if(!talk_ui.activeSelf)
            {
                talk_ui.SetActive(true);
            }
            Debug.Log($"index:{index}");
            updateText(index);
            index += 1;
        }
    }
    public void updateText(int index)
    {
        textLabel.text=text_list[index];
    }
    public int GetText(TextAsset textFile)
    {
        text_list.Clear();
        var rows = textFile.text.Split('\n');
        foreach (var row in rows)
        {
            string[] row_list = row.Split(',');
            var sign = row_list[0];
            Debug.Log(row_list[0]);
            text_list.Add(row_list[0]);
        }
        return text_list.Count;
    }
}
