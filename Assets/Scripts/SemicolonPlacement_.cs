using UnityEngine;

public class SemicolonPlacement_ : MonoBehaviour
{
    public UI UI;
    public SemicolonPlacementBox SemicolonPlacementBox;

    public void CheckSemicolonPlacement()
    {
        if (!SemicolonPlacementBox.SemicolonInRightSpot)
        {
            UI.SendText();
        }
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
