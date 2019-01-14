using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleFormDataSend : MonoBehaviour {

    public GameObject userName;
    public GameObject userEmail;
    public GameObject userMobileNo;
    public GameObject commentForGame;

    private string userNameText;
    private string userEmailText;
    private string userMobileNoText;
    private string commentForGameText;

    public Toggle toggleYes;
    public Toggle toggleNo;

    //private bool toggleOnOff;
    private string toggleOnOffStr;

    //[SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSeKGpPJ-2uuJ9DJIi-8CFGGLRqUjeWfSZJl4p7MYHKnu1CMXQ/formResponse";

    public void SendData (){
        userNameText = userName.GetComponent<InputField>().text;
        userEmailText = userEmail.GetComponent<InputField>().text;
        userMobileNoText = userMobileNo.GetComponent<InputField>().text;
        commentForGameText = commentForGame.GetComponent<InputField>().text;

        if(toggleYes.isOn) {
            toggleOnOffStr = "Yes";
        }
        else if (toggleNo.isOn) {
            toggleOnOffStr = "No";
        } else {
            toggleOnOffStr = "...";
        }

        StartCoroutine(PostToGoogle(userNameText, userEmailText, userMobileNoText, toggleOnOffStr, commentForGameText));
    }


    IEnumerator PostToGoogle (string name, string email, string phone, string toggleOnOff, string comment){
        WWWForm form = new WWWForm();
        form.AddField("entry.1543016901", name);
        form.AddField("entry.1273497035", email);
        form.AddField("entry.1231738938", phone);// error
        form.AddField("entry.350110141", toggleOnOff);
        form.AddField("entry.584298038", comment);

        byte[] rawdata = form.data;
        
        WWW www = new WWW(BASE_URL, rawdata);
        yield return www;
    }


    //Output the new state of the Toggle into Text
    public void ToggleValueChangedYes(Toggle change)
    {
        Debug.Log(toggleYes.isOn);
    }

    //Output the new state of the Toggle into Text
    public void ToggleValueChangedNo(Toggle change)
    {
        Debug.Log(toggleNo.isOn);
    }



}
