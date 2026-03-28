// PROTOTYPE - NOT FOR PRODUCTION
// Question: Is the hit-and-gain-resource loop satisfying?
// Date: 2026-03-26

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public GameObject BottlePrefab;
    public Transform ThrowPoint;
    public int Ammo = 3;

    void Update()
    {
        // Simple movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h, 0, v) * MoveSpeed * Time.deltaTime);

        // Throwing
        if (Input.GetButtonDown("Fire1") && Ammo > 0)
        {
            ThrowBottle();
        }
    }

    void ThrowBottle()
    {
        Ammo--;
        GameObject bottle = Instantiate(BottlePrefab, ThrowPoint.position, transform.rotation);
        bottle.GetComponent<DyeBottle>().Owner = this;
    }

    public void OnHitTarget()
    {
        // Core Loop: Hitting grants ammo!
        Ammo += 2; 
        Debug.Log("Hit target! Ammo increased to: " + Ammo);
    }
}
