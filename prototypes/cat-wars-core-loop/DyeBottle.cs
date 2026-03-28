// PROTOTYPE - NOT FOR PRODUCTION
// Question: Is the hit-and-gain-resource loop satisfying?
// Date: 2026-03-26

using UnityEngine;

public class DyeBottle : MonoBehaviour
{
    public float ThrowForce = 10f;
    public PlayerController Owner;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * ThrowForce;
        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject != Owner.gameObject)
        {
            // Paint the target (simulated)
            collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
            
            // Reward the thrower
            if (Owner != null) Owner.OnHitTarget();
            
            Destroy(gameObject);
        }
    }
}
