using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrapHandler 
{
    float HP { get; }
    int Damage { get; }
    void ApplyToHealth(int value, ITrapHandler agent);
    Tag MyTag { get; }

}

public enum Tag 
{ 
    None,
    Player,
    Trap
}


