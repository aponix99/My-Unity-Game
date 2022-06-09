using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayFabManagerScene0 : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;
    [SerializeField] GameObject message;
    public InputField usernameInput;
    public InputField emailInput;
    public InputField passwordInput;
    [SerializeField] GameObject registerPanel;
    [SerializeField] GameObject loginPanel;
    [SerializeField] GameObject confirmPanel;
    //Start is called before the first frame update
    void Start()
    {

    }
    public void OpenRegisterMenu()
    {
        loginPanel.SetActive(false);
        registerPanel.SetActive(true);
        message.SetActive(false);
    }

    public void GoBack()
    {
        loginPanel.SetActive(true);
        registerPanel.SetActive(false);
        confirmPanel.SetActive(false);
        message.SetActive(false);
    }
    public void OpenConfirmMenu()
    {
        loginPanel.SetActive(false);
        registerPanel.SetActive(false);
        confirmPanel.SetActive(true);
        message.SetActive(false);
    }

    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "Password too short!";
        }
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = usernameInput.text,
            Username = usernameInput.text,
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnErrorRegister);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and logged in!";
        loginPanel.SetActive(false);
        registerPanel.SetActive(false);
        confirmPanel.SetActive(true);
        AddOrUpdateContactEmail(emailInput.text);
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest{
            Email=emailInput.text,
            Password=passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnErrorLogin);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        message.SetActive(true);
        messageText.text = "Login success";
        Debug.Log("Login success");
        SceneManager.LoadScene("menuScene");
        

    }

   // void Login()
    //{
      //  var request = new LoginWithCustomIDRequest
        //{
          //  CustomId = SystemInfo.deviceUniqueIdentifier,
            //CreateAccount = true
        //};
        //PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    //}


    void OnSuccess(LoginResult result)
    {
        Debug.Log("Success Login");
    }


    void OnErrorRegister(PlayFabError error)
    {
        message.SetActive(true);
        Debug.Log("Error");
        messageText.text = "Register Not Succesful";
    }
    void OnErrorLogin(PlayFabError error)
    {
        message.SetActive(true);
        Debug.Log("Error");
        messageText.text = "Login not successful!  Try Again!";
    }
    /*
    void AddContactEmailToPlayer()
    {
       var loginReq = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier, // replace with your own Custom ID
            CreateAccount = true // otherwise this will create an account with that ID
        }; 
        var request= new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, loginRes =>
        {
            Debug.Log("Successfully logged in player with PlayFabId: " + loginRes.PlayFabId);
            AddOrUpdateContactEmail(emailInput.text);
        }, OnError);
    } 
    
    var emailAddress = emailInput.text; // Set this to your own email for testing

    PlayFabClientAPI.LoginWithCustomID(loginReq, loginRes =>
        {
            Debug.Log("Successfully logged in player with PlayFabId: " + loginRes.PlayFabId),
            AddOrUpdateContactEmail(emailAddress);
        }, FailureCallback);  */

    void AddOrUpdateContactEmail(string emailAddress) {
    var request = new AddOrUpdateContactEmailRequest
    {
        EmailAddress = emailAddress
    };
    PlayFabClientAPI.AddOrUpdateContactEmail(request, result =>
    {
        Debug.Log("The player's account has been updated with a contact email");
    }, FailureCallback);
}

    void FailureCallback(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your API call. Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
    

}