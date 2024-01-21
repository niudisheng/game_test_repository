using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.UIElements;

public class DialogSystem : MonoBehaviour
{
    [Header("UI���")]
    public GameObject talk_ui;
    public Text textLabel;
    public Text name_text;

    [Header("�Ի�����")]
    public TextAsset textFile;  //�Ի��ļ�
    public int index;
    public int max_index= 0;   
    public float textSpeed = 0.1f;

    [Header("ͼƬ��Դ")]
    public GameObject heroine;
    public GameObject female_2;
    Dictionary<string,GameObject> GameObject_dic = new Dictionary<string, GameObject>();

    [Header("�����ƶ�����")]
    private float left=-2500;
    private float middle=-1000;
    private float right=500;
    public float move_time =0.5f;

    [Header("�ƶ����ĸ�����")]
    public int sceneNum ;
    List<string> name_list = new List<string>();
    List<string> text_list = new List<string>();
    List<string[]> image_list = new List<string[]>();
    static public DialogSystem instance;
    bool text_finished = true;
    Coroutine text_display;
    private void Awake()   //������Ĭ��д��
    {   
        GameObject_dic.Clear();
        GameObject_dic["Ů��"]=heroine;
        GameObject_dic["Ů��"]= female_2;
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
    void Start()
    {   
        heroine.SetActive(false);
        female_2.SetActive(false);
        talk_ui.SetActive(false);
        max_index = GetText(textFile)-1;
        index = -1;
    }
    static public void awake_talk_ui(TextAsset textFile)
    {
        instance.heroine.SetActive(false);
        instance.female_2.SetActive(false);
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
            string[] image_pos = instance.image_list[0];
            instance.talk_ui.SetActive(true);
            image_update(image_pos);
            
            return updateText();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {           
            return updateText();     
        }
        return true;      //������������talk״̬
    }
    static public void image_update(string[] image_pos)
    {
        string sign = image_pos[0];
        char pos = image_pos[1][0];
        if (sign == "ȡ��") 
        {
            return;
        }
        GameObject ga = instance.GameObject_dic[sign];
        Transform tran = ga.transform;
        Sprite sprite = ga.GetComponent<Sprite>();
        float x_coordinate=instance.middle;
        //string m = "m1";
        if (pos == 'm')
        {
            x_coordinate = instance.middle;
        }
        else if (pos == 'l')
        {
            x_coordinate = instance.left;
        }
        else 
        {
            x_coordinate = instance.right;
        }
        Debug.Log(x_coordinate);
        if (!ga.activeSelf)
        {
            ga.SetActive(true);
            //tran.localPosition = new Vector3(x_coordinate, tran.localPosition.y, tran.localPosition.z);
            tran.localPosition = new Vector3(x_coordinate, 1500, tran.localPosition.z);
        }
        if (tran.localPosition.x != x_coordinate)
        tran.DOLocalMoveX(x_coordinate, instance.move_time);

    }
    static public void closeUi() 
    {
        foreach (GameObject value in instance.GameObject_dic.Values)
        {
            value.SetActive(false);
        }
        Debug.Log("closeUi");
        instance.talk_ui.SetActive(false);
    }
    static public  bool updateText()   //�����������
    {          
        if (instance.index < instance.max_index)   //��������û�в���
        {   
            
            if (instance.text_finished)
            {   

                instance.index++;
                string content = instance.text_list[instance.index];
                if (content == "��ת")
                {   
                    closeUi();
                    sceneManager.Instance.changeScene(instance.sceneNum);
                }

                instance.name_text.text = instance.name_list[instance.index];
                string[] image_pos = instance.image_list[instance.index];
                image_update(image_pos);
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

            closeUi();
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
            string sign = row_list[0];
            if (sign == "�����־")
            {
                continue;
            }
            
            string position = row_list[4];
            string name = row_list[2];
            string content = row_list[3];
            instance.name_list.Add(name);
            instance.text_list.Add(content);
            instance.image_list.Add(new string[2] {sign,position});
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
        //StopCoroutine(text_display);

    }
}
