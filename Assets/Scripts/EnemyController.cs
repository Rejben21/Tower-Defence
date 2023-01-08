using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    [HideInInspector]
    public float speedMod = 1;
    public Transform target;
    private Path path;
    private int curPoint;
    private bool reachedEnd;

    public float timeBetweenAttacks, damagePerAttack;
    private float attackCounter;

    private Castle castle;
    public int whichCastle;

    private int selectAttackPoint;

    public bool isFlying;
    public float flyingHeight;

    void Start()
    {
        if(path == null)
        {
            path = FindObjectOfType<Path>();
        }

        if(castle == null)
        {
            castle = FindObjectOfType<Castle>();
        }

        attackCounter = timeBetweenAttacks;

        if(isFlying)
        {
            transform.position += Vector3.up * flyingHeight;
            curPoint = path.pathPoints.Length - 1;
        }
    }

    void Update()
    {
        if (LevelManager.instance.levelActive)
        {
            if (!reachedEnd)
            {
                //transform.LookAt(path.pathPoints[curPoint]);

                if (!isFlying)
                {
                    transform.LookAt(path.pathPoints[curPoint]);

                    transform.position = Vector3.MoveTowards(transform.position, path.pathPoints[curPoint].position, moveSpeed * speedMod * Time.deltaTime);

                    if (Vector3.Distance(transform.position, path.pathPoints[curPoint].position) < .01f)
                    {
                        curPoint++;
                        if (curPoint >= path.pathPoints.Length)
                        {
                            reachedEnd = true;

                            selectAttackPoint = Random.Range(0, castle.attackPoints.Length);
                        }
                    }
                }
                else
                {
                    Vector3 lookAt = path.pathPoints[curPoint].position + (Vector3.up * flyingHeight);
                    transform.LookAt(lookAt);

                    transform.position = Vector3.MoveTowards(transform.position, path.pathPoints[curPoint].position + (Vector3.up * flyingHeight), moveSpeed * speedMod * Time.deltaTime);

                    if (Vector3.Distance(transform.position, path.pathPoints[curPoint].position + (Vector3.up * flyingHeight)) < .01f)
                    {
                        curPoint++;
                        if (curPoint >= path.pathPoints.Length)
                        {
                            reachedEnd = true;

                            selectAttackPoint = Random.Range(0, castle.attackPoints.Length);
                        }
                    }
                }
            }
            else
            {
                if (!isFlying)
                {
                    transform.position = Vector3.MoveTowards(transform.position, castle.attackPoints[selectAttackPoint].position, moveSpeed * speedMod * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, castle.attackPoints[selectAttackPoint].position + (Vector3.up * flyingHeight), moveSpeed * speedMod * Time.deltaTime);
                }

                attackCounter -= Time.deltaTime;

                if (attackCounter <= 0)
                {
                    attackCounter = timeBetweenAttacks;

                    castle.TakeDamage(damagePerAttack);
                }
            }
        }
        else
        {

        }
    }

    public void Setup(Castle newCastle, Path newPath)
    {
        castle = newCastle;
        path = newPath;
    }
}
