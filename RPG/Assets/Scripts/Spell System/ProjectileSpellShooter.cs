using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpellShooter : MonoBehaviour
{
    [HideInInspector] public GameObject projectilePrefab;       // Rigidbody variable to hold a reference to our projectile prefab
    public Transform castPos;                                   // Transform variable to hold the location where we will spawn our projectile
    [HideInInspector] public float speed = 10f;                // Float variable to hold the amount of force which we will apply to launch our projectiles

    public void Fire()
    {
        Vector3 rayOrigin = castPos.position;
        Vector3 projectileDirection;
        Vector2 mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Ray ray = Camera.main.ScreenPointToRay(mouse);
        RaycastHit mouseHit;

        // Check if our mouse is over some ground
        if (Physics.Raycast(ray, out mouseHit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
        {
            Vector3 targetPosition = mouseHit.point;
            targetPosition.y += castPos.localPosition.y;
            projectileDirection = (targetPosition - rayOrigin).normalized;
            
            //Instantiate a copy of our projectile
            GameObject projectile = Instantiate(projectilePrefab, castPos.position, Quaternion.LookRotation(projectileDirection));
            projectile.GetComponent<Rigidbody>().velocity = projectileDirection * speed;
        }
    }
}
