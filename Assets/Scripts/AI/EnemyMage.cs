using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMage : MonoBehaviour
{

    public float speed;
    public GameObject Player;
    public Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        EnemyActive();
    }
    void EnemyActive()
    {
        float dist = Vector3.Distance(Player.transform.position, this.transform.position);

        if (dist <= 10f && enemyAnimator.GetBool("isDead") == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }

        
    }
}
