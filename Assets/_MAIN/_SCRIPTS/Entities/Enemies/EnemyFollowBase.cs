using UnityEngine;

public class EnemyFollowBase : EnemyController
{

    [SerializeField] protected Transform target;
    protected Vector3 directionToTarget;
    [SerializeField] protected float visionRadius;
    protected float distanceToTarget;
    [SerializeField] protected float rangeAttack = 9;
    protected bool chasing;

    protected float currentSpeed;
    public override void Start()
    {
        base.Start();
      
    }

    public override void Update()
    {
        base.Update();
        GetDirectionChase();
        GetDistanceTarget();
     
    }

    protected void LookAtTarget()
    {
        transform.rotation = Quaternion.LookRotation(directionToTarget);
        chasing = true;
    }
    public override void Move()
    {      
        FollowTarget();
    }
    private void FollowTarget()
    {
      
        if (target != null && distanceToTarget <= visionRadius) 
        {
            
            LookAtTarget();
            if (distanceToTarget > rangeAttack)
            {
                direction = directionToTarget;
                Vector3 move = Vector3.MoveTowards(transform.position, target.position, CurrentSpeed * Time.deltaTime);
                move.y = transform.position.y;
                transform.position = move;
            }
            else if (distanceToTarget < rangeAttack)
            {             
                direction = Vector3.zero;
            }
        }
        else
        {
            chasing = false;
            direction = Vector3.zero;
        }
        #region









        //if (dist <= visionRadius)
        //{
        //    chaseTarget = true;
        //    transform.rotation = Quaternion.LookRotation(dir);

        //    if (chaseTarget)
        //    {
        //        Attack();
        //        if (dist > rangeToChase)
        //        {
        //            Move(dirNormalize);
        //           /* anim.SetBool("Run", true);*/ //TODO: CAMBIAR DE LUGAR

        //        }
        //        else if (dist <= rangeToChase) 
        //        {
        //           /* anim.SetBool("Run", false);*/ //TODO: CAMBIAR DE LUGAR
        //        }          
        //    }                  
        //}
        //else
        //{
        //   /* anim.SetBool("Run", false);*/ //TODO: CAMBIAR DE LUGAR
        //}
        //
        #endregion

    }
    private Vector3 GetDirectionChase()
    {
        var dir = target.transform.position - transform.position;
        dir.y = 0;
        directionToTarget = dir.normalized;
        return directionToTarget;
    }
    private float GetDistanceTarget()
    {
        distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        return distanceToTarget;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
