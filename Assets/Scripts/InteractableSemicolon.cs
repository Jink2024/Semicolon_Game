using UnityEngine;

public class InteractableSemicolon : InteractableObject
{
    void Start()
    {
        
    }

    public override void Interact()
    {
        Player.HasSemicolon = true;
        KeyboardInput.ConsumeInteractInput();
        
        Destroy(gameObject);
    }
}
