using UnityEngine;

public class SemicolonPlacementBox : MonoBehaviour
{
    public GameObject SemicolonPrefab;
    public GameManager GameManager;
    public bool SemicolonInRightSpot = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Semicolon"))
        {
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
