using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;

using TMPro;

public class LeaderBoardController : MonoBehaviour
{

    public TMP_InputField MemberID, PlayerScore;
    public int ID;
    private int MaxScores = 4;
    public TMP_Text[] Entries;


    void Start()
    {

        //accessing the child object that holds the text 
        PlayerScore = PlayerScore.GetComponent<TMP_InputField>();
        MemberID = MemberID.GetComponent<TMP_InputField>();

        string playerIdentifier = "unique_player_identifier_here";
        LootLockerSDKManager.StartSession(playerIdentifier, (response) =>
        {
            if (response.success)
            {
                Debug.Log("session with LootLocker started");
            }
            else
            {
                Debug.Log("failed to start sessions" + response.Error);
            }
        });
    }

    public void ShowScores()
    {

        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success)
            {
                ///get top scores from online
                ///LootLockerGetByListOfMembersResponse
                LootLockerLeaderboardMember[] scores = response.items;
                
                
                for (int i = 0; i < scores.Length; i++)
                {

                    Entries[i].text = scores[i].rank + ".   " + scores[i].score;
                    
                }


                ///if we have less scores online than we can show on the leaderboard
                if(scores.Length < MaxScores)
                {
                    for(int i = scores.Length; i < MaxScores; i++)
                    {
                        Entries[i].text = (i + 1).ToString() + ".   none";
                    }
                }


            }
            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(PlayerScore.text), ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully submitted score");
            }
            else
            {
                Debug.Log("Faild to submit score");
            }
        });
    }
    
}
