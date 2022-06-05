using UnityEngine;

public class CatCollisionProcessor
{
    private Rigidbody _rb;
    private string _wallTag = "Wall";

    public CatCollisionProcessor(Rigidbody rb)
    {
        this._rb = rb;
        // Shall we handle collision or just return and modifiy the movmenet back at movement stuff?
    }

    public void HandleCollision(Collision collision)
    {
        if(collision.gameObject.CompareTag(_wallTag))
        {
            Debug.Log("Wall hit");
            // Calculate bounce strength depening on speed


            // Somehow bounce AWAY from the wall
            // With strength according to the force of collision

            // Example change in the code
            this.name = "Kupa";
        }
    }
}