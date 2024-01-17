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
    //TMPro.TextMeshPro textMeshPro;

    [Header("对话参数")]
    public TextAsset textFile;  //对话文件
    public int index;
    public int max_index= 0;   
    public float textSpeed = 0.1f;
    List<string> text_list = new List<string>();

    bool text_finished = true;
    Coroutine text_display;
    void Start()
    {
        talk_ui.SetActive(false);
        max_index = GetText(textFile)-1;
        index = -1;
    }

    // Update is called once per frame
    void Update()
    {   

        if (Input.GetKeyDown(KeyCode.R))
        {            
            if(!talk_ui.activeSelf)
            {
                talk_ui.SetActive(true);
            }            

            updateText();            
        }
    }
    public void updateText()
    {
        Debug.Log("updateText");
        if (index < max_index)
        {
            if (text_finished)
            {
                index++;
                text_display=StartCoroutine(setTextUI(index)); 
                text_finished = false;
            }
            else 
            { 
                StopCoroutine(text_display);
                textLabel.text = text_list[index];
                
                text_finished = true;
            }
        }
        else
        {
            talk_ui.SetActive(false);
        }
    }
    public int GetText(TextAsset textFile)
    {
        text_list.Clear();
        var rows = textFile.text.Split('\n');
        foreach (var row in rows)
        {
            string text = row.ToString();
            string[] row_list = text.Split(',');
            var sign = row_list[0];
            var content = row_list[3];
            Debug.Log(row_list[1]);
            text_list.Add(content);
        }
        return text_list.Count;
    }
    IEnumerator setTextUI(int index)
    {   
        textLabel.text= string.Empty;
        for (int i = 0; i < text_list[index].Length; i++)
        {
            textLabel.text += text_list[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        text_finished=true;
    }
}
