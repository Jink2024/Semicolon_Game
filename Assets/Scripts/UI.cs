using System.Collections;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject GuidanceCounselorText;
    //public PlayerName PlayerName;
    public TMP_Text playerOverHead;
    
    [SerializeField] private GameObject pauseMenuPanel;

    public void SendText()
    {
        GuidanceCounselorText.SetActive(true);
        Invoke("UnSendText", 2f);
    }

    public void UnSendText()
    {
        GuidanceCounselorText.SetActive(false);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //PlayerName.InputYourName();
        playerOverHead.text = PlayerName.playername;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}