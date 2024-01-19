using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
//using UnityEngine.UIElements;

public class DialogSystem : MonoBehaviour
{
    [Header("UI���")]
    public GameObject talk_ui;
    public Text textLabel;
    public Text name_text;
    Image faceImage;
    //TMPro.TextMeshPro textMeshPro;

    [Header("�Ի�����")]
    public TextAsset textFile;  //�Ի��ļ�
    public int index;
    public int max_index= 0;   
    public float textSpeed = 0.1f;

    [Header("ͼƬ��Դ")]
    public Sprite heroine;
    public Sprite female_2;
    Dictionary<string,Sprite>image_dic=new Dictionary<string, Sprite>();

    List<string> name_list = new List<string>();
    List<string> text_list = new List<string>();
    static public DialogSystem instance;
    bool text_finished = true;
    Coroutine text_display;
    private void Awake()   //������Ĭ��д��
    {   
        image_dic.Clear();
        image_dic["Ů����"]=heroine;
        image_dic["Ů��"]= female_2;
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
        return true;      //������������talk״̬
    }
    static public  bool updateText()   //�����������
    {          
        if (instance.index < instance.max_index)   //��������û�в���
        {         
            if (instance.text_finished)
            {
                instance.index++;
                string content = instance.text_list[instance.index];
                instance.name_text.text = instance.name_list[instance.index];                
                instance.text_display = instance.StartCoroutine(instance.setTextUI(content)); 
                instance.text_finished = false;
            }
            else //�ı�û������ʱ���ٰ�R
            {
                instance.name_text.text = instance.name_list[instance.index];
                instance.StopCoroutine(instance.text_display);
                string content = instance.text_list[instance.index];
                instance.textLabel.text = content;
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
            //string sign = row_list[0];
            string name = row_list[2];
            string content = row_list[3];
            instance.name_list.Add(name);
            instance.text_list.Add(content);
        }
        return instance.text_list.Count;
    }
     public IEnumerator setTextUI(string content)
    {   
        textLabel.text= string.Empty;
        //string content=text_list[index];
        for (int i = 0; i < content.Length; i++)
        {
            textLabel.text += content[i];
            yield return new WaitForSeconds(textSpeed);
        }
        text_finished=true;
    }
}
