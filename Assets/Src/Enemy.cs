using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool attackable = true;
    private static int IDIndex = 0;
    public int ID = int.MaxValue;
    public bool applyforce = false;
    public bool invulnerable = false;
    [SerializeField]
    private float knockbackFactor = 1;

    private Rigidbody2D enemyrb;

    [SerializeField]
    private int _hp = 10;
    public int hp
    {
        get { return _hp; }
    }

    void Start()
    {
        ID = IDIndex;
        IDIndex++;
        enemyrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage, GameObject damager)
    {
        if (applyforce)
        {
            var dir = (this.transform.position - damager.transform.position).normalized;
            enemyrb.AddForce(dir * damage * knockbackFactor, ForceMode2D.Impulse);
        }

        if (invulnerable) return;
        _hp -= damage;
        if (_hp < 0) Die();
    }
}
