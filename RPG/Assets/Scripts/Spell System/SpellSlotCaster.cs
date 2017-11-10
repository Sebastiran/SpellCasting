using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlotCaster : MonoBehaviour
{
    public string spellButtonAxisName = "Fire1";
    public Spell spell;

    [SerializeField] private CharacterStats caster;
    [SerializeField] private Image spellIcon;


    void Start()
    {
        if (spell != null)
            Initialize(spell);
    }

    public void Initialize(Spell selectedSpell)
    {
        spell = selectedSpell;
        spellIcon.enabled = true;
        spellIcon.sprite = spell.icon;
        //spell.Initialize(caster);
    }

    void Update()
    {
        if (Input.GetButtonDown(spellButtonAxisName))
        {
            if (spell != null)
                TryCastSpell();
        }   
    }

    private void TryCastSpell()
    {
        bool succes = SpellHelper.instance.StartCastingSpell(caster, spell);
        if (succes)
        {
            Spell castedSpell = spell;

            spellIcon.sprite = null;
            spellIcon.enabled = false;
            spell = null;

            SpellSlotManager.instance.SpellCasted(castedSpell, this);
        }
    }
}
