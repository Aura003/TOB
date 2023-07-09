using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour, ITrapHandler
{
    public float currentHP;
    public int damage;
    public Tag myTag;
    public List<Tag> myTagsList = new List<Tag>();
    public ITrapHandler Owner;
    public int Damage => damage;

    public Tag MyTag => myTag;

    public float HP => currentHP;

    public void ApplyToHealth(int value, ITrapHandler agent)
    {
        currentHP += value;
    }

    private void OnTriggerEnter(Collider other)
    {
        ITrapHandler target = other.gameObject.GetComponent<ITrapHandler>();
        if (target == null)
            return;
        if (myTagsList.Contains(target.MyTag))
        {
            target.ApplyToHealth(-damage, Owner != null ? Owner : this);
        }
    }
}
