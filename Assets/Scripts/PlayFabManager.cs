using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using Newtonsoft.Json;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;

    //Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest{
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }
    void OnSuccess(LoginResult result)
    {
        Debug.Log("Success Login");
    }


    void OnError(PlayFabError error)
    {
        Debug.Log("Fail Login");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate
                {
                    StatisticName="score",
                    Value=score
                }
             }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Leaderboard sent!");
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "score",
            StartPosition = 0,
            MaxResultsCount = 4
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }
    

    void OnLeaderboardGet(GetLeaderboardResult result) {

        foreach (Transform item in rowsParent)
        {
            if (item.gameObject!= null)
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position+1 + " " + item.PlayFabId + " " + item.StatValue);
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.PlayFabId;
            texts[2].text = item.StatValue.ToString();
        }
    
    }
}