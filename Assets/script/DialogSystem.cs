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

    static public DialogSystem instance;

    bool text_finished = true;
    Coroutine text_display;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
    void Start()
    {
        talk_ui.SetActive(false);
        max_index = GetText(textFile)-1;
        index = -1;
    }
    static public void awake_talk_ui(TextAsset textFile)
    {
        instance.talk_ui.SetActive(false);
        instance.max_index = GetText(textFile) - 1;
        instance.index = -1;
    }
    // Update is called once per frame
    void Update()
    {   
       
    }
    static public bool blit_text()
    {
        if (!instance.talk_ui.activeSelf)
        {
            instance.talk_ui.SetActive(true);
            return updateText();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {           
            return updateText();
        }
        return false;
    }
    static public  bool updateText()
    {   

        Debug.Log("updateText");
        if (instance.index < instance.max_index)
        {
            if (instance.text_finished)
            {
                instance.index++;
                instance.text_display = instance.StartCoroutine(instance.setTextUI(instance.index)); 
                instance.text_finished = false;
            }
            else //文本没结束的时候再按R
            {
                instance.StopCoroutine(instance.text_display);
                instance.textLabel.text = instance.text_list[instance.index];
                instance.text_finished = true;
            }
            return true;
        }
        else
        {
            instance.talk_ui.SetActive(false);
            return false;
        }
    }
    static public int GetText(TextAsset textFile)
    {
        instance.text_list.Clear();
        var rows = textFile.text.Split('\n');
        foreach (var row in rows)
        {
            string text = row.ToString();
            string[] row_list = text.Split(',');
            var sign = row_list[0];
            var content = row_list[3];
            Debug.Log(row_list[1]);
            instance.text_list.Add(content);
        }
        return instance.text_list.Count;
    }
     public IEnumerator setTextUI(int index)
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
