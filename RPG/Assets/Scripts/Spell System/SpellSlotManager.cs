using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSlotManager : MonoBehaviour
{
    #region Singleton
    
    public static SpellSlotManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SpellSlotManager>();
            }
            return _instance;
        }
    }
    static SpellSlotManager _instance;

    void Awake()
    {
        _instance = this;
    }

    #endregion

    public SpellSlotCaster[] spellSlots;
    public Spell[] spells;

    private List<Spell> spellQueue;
    private List<SpellSlotCaster> spellSlotQueue;

    private void Start()
    {
        spellSlotQueue = new List<SpellSlotCaster>();
        for (int i = 0; i < spellSlots.Length; i++)
        {
            spellSlotQueue.Add(spellSlots[i]);
        }

        List<Spell> spellsList = new List<Spell>();
        for (int i = 0; i < spells.Length; i++)
        {
            spellsList.Add(spells[i]);
        }

        spellQueue = HustleOrder(spellsList);

        UpdateSpellSlots();
    }

    private void UpdateSpellSlots()
    {
        while (spellQueue.Count > 0 && spellSlotQueue.Count > 0)
        {
            GiveSpellToSlot(spellSlotQueue[0]);
        }
    }

    public void SpellCasted(Spell spell, SpellSlotCaster spellSlot)
    {
        spellQueue.Add(spell);
        spellSlotQueue.Add(spellSlot);

        UpdateSpellSlots();
    }

    void GiveSpellToSlot(SpellSlotCaster spellSlot)
    {
        Spell nextSpell = GetNextSpell();
        if (nextSpell != null)
        {
            spellSlot.Initialize(nextSpell);
            spellSlotQueue.Remove(spellSlot);
        }
    }

    Spell GetNextSpell()
    {
        if (spellQueue.Count > 0)
        {
            Spell nextSpell = spellQueue[0];
            spellQueue.RemoveAt(0);
            return nextSpell;
        }
        return null;
    }

    Spell GetRandomSpell()
    {
        return spells[Random.Range(0, spells.Length)];
    }
    

    private List<T> HustleOrder<T>(List<T> list)
    {
        List<T> hustledList = new List<T>();
        while (list.Count > 0)
        {
            int index = Random.Range(0, list.Count);
            hustledList.Add(list[index]);
            list.RemoveAt(index);
        }
        return hustledList;
    }
}