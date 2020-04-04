﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using Alsein.Extensions.IO;

public class MessageBox : MonoBehaviour
{
    public Text TitleText;
    public Text MessageText;
    public Text YesText;
    public Text NoText;
    public GameObject YesButton;
    public GameObject NoButton;
    public GameObject Buttons;
    public ITubeInlet sender;
    public ITubeOutlet receiver;
    //private IAsyncDataSender sender;
    //private IAsyncDataReceiver receiver;
    public RectTransform Context;
    private void Awake()
    {
        (sender, receiver) = Tube.CreateSimplex();
    }
    public void Wait(string title, string message)
    {
        Buttons.SetActive(false);
        TitleText.text = title;
        MessageText.text = message;
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
        Buttons.SetActive(true);
    }
    public Task<bool> Show(string title, string message, string yes = "确定", string no = "取消", bool isOnlyYes = false)
    {
        Buttons.SetActive(true);
        if (isOnlyYes)
        {
            YesButton.SetActive(true);
            NoButton.SetActive(false);
        }
        else
        {
            YesButton.SetActive(true);
            NoButton.SetActive(true);
        }
        TitleText.text = title;
        MessageText.text = message;
        YesText.text = yes;
        NoText.text = no;
        gameObject.SetActive(true);
        // LayoutRebuilder.ForceRebuildLayoutImmediate(Context);
        return receiver.ReceiveAsync<bool>();
    }
    public void YesClick()
    {
        sender.SendAsync<bool>(true);
        gameObject.SetActive(false);
    }
    public void NoClick()
    {
        sender.SendAsync<bool>(false);
        gameObject.SetActive(false);
    }
}
