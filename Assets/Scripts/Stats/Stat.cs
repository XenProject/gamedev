using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat {

    [SerializeField]
    private int base_value;

    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        int final_value = base_value;
        modifiers.ForEach(mod => final_value += mod);
        return final_value;
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }
}
