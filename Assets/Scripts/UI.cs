using System.Collections;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject GuidanceCounselorText;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
