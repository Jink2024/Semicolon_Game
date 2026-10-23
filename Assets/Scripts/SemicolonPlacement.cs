using UnityEngine;

public class SemicolonPlacement : MonoBehaviour
{
    public GameObject SemicolonPrefab;
    public GameManager GameManager;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Semicolon"))
        {
            print("the semicolon is in the correct place");
            GameManager.GameWon();
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
