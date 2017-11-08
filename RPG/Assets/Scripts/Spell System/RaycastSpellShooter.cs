using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSpellShooter : MonoBehaviour
{
    [HideInInspector] public int spellDamage = 1;                       // Set the number of hitpoints that this spell will take away from shot objects with a health script.
    [HideInInspector] public float spellRange = 50f;                    // Distance in unity units over which the player can fire.
    [HideInInspector] public float hitForce = 100f;                     // Amount of force which will be added to objects with a rigidbody shot by the player.
    public Transform castPos;                                           // Holds a reference to the Cast Position object.
    [HideInInspector] public LineRenderer laserLine;                    // Reference to the LineRenderer component which will display our laserline.

    private Camera cam;                                                 // Holds a reference to the camera.
    private WaitForSeconds shotDuration = new WaitForSeconds(0.2f);     // WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible.


    public void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        cam = GetComponentInParent<Camera>();
    }

    public void Fire()
    {
        Vector3 rayOrigin = castPos.position;
        
        Vector3 rayDirection;

        Vector2 mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Ray ray = Camera.main.ScreenPointToRay(mouse);
        RaycastHit mouseHit;

        // Check if our mouse is over some ground
        if (Physics.Raycast(ray, out mouseHit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
        {
            Vector3 targetPosition = mouseHit.point;
            targetPosition.y += castPos.localPosition.y;
            rayDirection = (targetPosition - rayOrigin).normalized;
            
            RaycastHit hit;
            StartCoroutine(ShotEffect());
            laserLine.SetPosition(0, rayOrigin);

            //Check if our raycast has hit anything
            if (Physics.Raycast(rayOrigin, rayDirection, out hit, spellRange))
            {
                //Set the end position for our laser line 
                laserLine.SetPosition(1, hit.point);

                CharacterStats stats = hit.collider.GetComponent<CharacterStats>();

                if (stats != null)
                {
                    stats.TakeDamage(spellDamage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                //if we did not hit anything, set the end of the line to a position directly away from
                laserLine.SetPosition(1, rayOrigin + (rayDirection * spellRange));
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;

        yield return shotDuration;
        
        laserLine.enabled = false;
    }
}
