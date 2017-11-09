using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellShooter : MonoBehaviour
{
    public Transform castPos;                                           // Transform variable to hold the location where we will spawn our projectile

    private LineRenderer laserLine;                                     // LineRenderer used for laser spells
    private WaitForSeconds shotDuration = new WaitForSeconds(0.2f);     // WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible.

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    Vector3? GetTargetPosition()
    {
        Vector2 mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Ray ray = Camera.main.ScreenPointToRay(mouse);
        RaycastHit mouseHit;

        // Check if our mouse is over some ground
        if (Physics.Raycast(ray, out mouseHit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
        {
            return mouseHit.point;
        }

        return null;
    }

    public void Fire(ProjectileSpell spell)
    {
        Debug.Log("Casting Projectile: " + spell.name);
        Vector3? targetPos = GetTargetPosition();
        if (targetPos != null)
        {
            Vector3 targetPosition = (Vector3)targetPos;
            targetPosition.y += castPos.localPosition.y;
            Vector3 direction = (targetPosition - castPos.position).normalized;

            //Instantiate a copy of our spellPrefab
            GameObject spellClone = Instantiate(spell.spellPrefab, castPos.position, Quaternion.LookRotation(direction));
            spellClone.GetComponent<Projectile>().spell = spell;
            spellClone.GetComponent<Rigidbody>().velocity = direction * spell.speed;
        }
    }

    public void Fire(AoESpell spell)
    {
        Debug.Log("Casting AoE: " + spell.name);
        Vector3? targetPos = GetTargetPosition();
        if (targetPos != null)
        {
            Vector3 targetPosition = (Vector3)targetPos;

            //Instantiate a copy of our spellPrefab
            GameObject spellClone = Instantiate(spell.spellPrefab, targetPosition + (Vector3.up * 10), transform.rotation);
            spellClone.GetComponent<AoE>().spell = spell;
            spellClone.GetComponent<Rigidbody>().velocity = Vector3.up * -20f;
        }
    }

    public void Fire(LaserSpell spell)
    {
        Debug.Log("Casting Laser: " + spell.name);
        Vector3? targetPos = GetTargetPosition();
        if (targetPos != null)
        {
            Vector3 targetPosition = (Vector3)targetPos;
            targetPosition.y += castPos.localPosition.y;
            Vector3 direction = (targetPosition - castPos.position).normalized;

            RaycastHit hit;

            laserLine.material = new Material(Shader.Find("Unlit/Color"));
            laserLine.material.color = spell.laserColor;
            StartCoroutine(ShotEffect(spell));
            laserLine.SetPosition(0, castPos.position);

            //Check if our raycast has hit anything
            if (Physics.Raycast(castPos.position, direction, out hit, spell.range))
            {
                //Set the end position for our laser line 
                laserLine.SetPosition(1, hit.point);

                CharacterStats stats = hit.collider.GetComponent<CharacterStats>();

                if (stats != null)
                {
                    for (int i = 0; i < spell.components.Length; i++)
                    {
                        spell.components[i].ApplyComponentEffect(stats);
                    }
                }
            }
            else
            {
                //if we did not hit anything, set the end of the line to a position directly away from
                laserLine.SetPosition(1, castPos.position + (direction * spell.range));
            }
        }
    }

    public void Fire(SelfSpell spell)
    {
        Debug.Log("Casting Self: " + spell.name);
    }

    private IEnumerator ShotEffect(LaserSpell spell)
    {
        laserLine.enabled = true;

        yield return shotDuration;

        laserLine.enabled = false;
    }
}
