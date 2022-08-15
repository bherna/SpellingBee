using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;

using TMPro;

public class LeaderBoardController : MonoBehaviour
{

    public TMP_InputField MemberID, PlayerScore;
    public int ID;


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
