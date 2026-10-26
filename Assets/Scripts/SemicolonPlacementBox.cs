using UnityEngine;

public class SemicolonPlacementBox : MonoBehaviour
{
    public GameObject SemicolonPrefab;
    public GameManager GameManager;
    public static bool SemicolonInRightSpot = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Semicolon"))
        {
            print("the semicolon is in the correct place");
            GameManager.GameWon();
            SemicolonInRightSpot = true;
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
