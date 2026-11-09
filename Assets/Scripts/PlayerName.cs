using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour
{
    public TMP_Text userNameInputText;
    public string playername;

    void Start() 
    {
        userNameInputText = canvas.transform.Find("UserNameInputField/Text").GetComponent<TMP_Text>(); //You'll need to put in the actual path in your own hierarchy.
    }

    void Update()
    {
        print("userNameInputText: " + userNameInputText.text);
    }

    public void InputYourName() 
    {
        playername = userNameInputText.text;
    }
    public GameObject canvas;
    
}


