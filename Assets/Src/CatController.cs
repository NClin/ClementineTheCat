using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CatController : MonoBehaviour
{
    GameObject target;

    [SerializeField]
    GameObject damageTextPrefab;
    [SerializeField]
    GameObject cursorObject;

    [SerializeField]
    float speed = 0.8f;
    Rigidbody2D catrb;

    [SerializeField]
    float attackCD = 0.5f;
    private float timeOfLastAttack = float.MaxValue;
    int attackDamage = 4;

    private bool _attacking;
    public bool attacking
    {
        get
        {
            return _attacking;
        }
    }

    Vector2 destination;
    void Start()
    {
        catrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!AtDestination(0.1f))
        {
            Vector2 transV2 = new Vector2(transform.position.x, transform.position.y);
            var dir = (destination - transV2).normalized;
            catrb.AddForce(dir * speed);
        }
    }

    private void Update()
    {
        GetClosestEnemy(0.3f);

        if(DoControllerInput() || DoKeyboardMouseInput())
        {

        }

        


    }

    private bool DoControllerInput()
    {
        bool ret = false;
        Vector2 input = Vector2.zero;

        var x = Input.GetAxis("Horizontal");
        if (x != 0)
        {
            input.x = x;
            ret = true;
        }

        var y = Input.GetAxis("Vertical");
        if (y != 0)
        {
            input.y = y;
            ret = true;
        }

        var inputNorm = input == Vector2.zero ? input : input.normalized;



        return ret;
    }

    private bool DoKeyboardMouseInput()
    {
        bool ret = false;
        if (Input.GetMouseButtonDown(1))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ret = true;
        }


        if (target && AtDestination(0.2f) && Vector2.Distance(transform.position, target.transform.position) < 0.3f)
        {
            _attacking = true;
            AttackTarget();
        }
        else
        {
            _attacking = false;
        }


        return ret;
    }

    private bool AtDestination(float threshold)
    {
        return Vector2.Distance(transform.position, destination) < threshold;
    }

    private void GetClosestEnemy(float range)
    {
        var targets = Physics2D.OverlapCircleAll(transform.position, range);
        float closest = float.MaxValue;
        if (targets != null)
        {
            foreach (var target in targets)
            {
                if (target.GetComponent<Enemy>())
                {
                    if (Vector2.Distance(transform.position, target.transform.position) < closest)
                    {
                        this.target = target.gameObject;
                    }
                }
            }
        }
    }

    private void AttackTarget()
    {
        if (Time.time - timeOfLastAttack > attackCD || timeOfLastAttack == float.MaxValue)
        {
            if (target.GetComponent<Enemy>())
            {
                target.GetComponent<Enemy>().TakeDamage(attackDamage, gameObject);
                timeOfLastAttack = Time.time;
                ShowDamageText(target.transform.position, attackDamage.ToString());
            }
        }
    }

    private void ShowDamageText(Vector2 location, string content, float scale = 1)
    {
        var txt = Instantiate(damageTextPrefab);
        txt.GetComponent<TMP_Text>().text = content;
        txt.transform.localScale *= scale; // maybe?
        txt.transform.position = location;
    }

}
