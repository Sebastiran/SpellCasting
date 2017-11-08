using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : ScriptableObject
{
    new public string name = "New Name";
    public Sprite icon;
    public AudioClip sound;
    public float manaCast = 1f;
    
    public Transform caster;

    public abstract void Initialize(GameObject obj);
    public abstract void CastSpell();
}