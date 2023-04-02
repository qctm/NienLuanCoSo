using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum State
{
    Idle,
    Run,
    Hit
}
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator m_Animatior;
    [SerializeField] private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private float m_WalkSpeed;
    [SerializeField] private float m_walkDistance; 

    private int m_ChangeParamHash;
    private int m_StateParamHash;
    private State m_CurrentState;
    private int m_Direction = 1;
    private Vector3 m_starPosition;
    // Start is called before the first frame update
    void Start()
    {
        m_ChangeParamHash = Animator.StringToHash("Change");
        m_StateParamHash = Animator.StringToHash("State");
        m_starPosition = transform.position;
        SetState(State.Idle);
        StartCoroutine(UpdateAI());
        SetDirection(1);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(transform.position.x - m_walkDistance,transform.position.y), 
                        new Vector2(transform.position.x + m_walkDistance,transform.position.y));
    }
    private void SetDirection(int direction)
    {
        m_Direction = direction;
        transform.localScale = new Vector3(m_Direction, 1, 1);
    }
    private void SetState(State state)
    {
        m_CurrentState = state;
        switch (state)
        {
            case State.Idle:
                PlayIdleAnimation();
                break;
            case State.Run:
                PlayRunAnimation();
                break ;
            case State.Hit:
                PlayHitAnimation();
                break;      
        }
    }
    private IEnumerator UpdateAI()
    {
        while (true)
        {
            if(m_CurrentState == State.Idle)
            {
                yield return new WaitForSeconds(3f);
                SetState(State.Run);
            }
            else if (m_CurrentState == State.Run)
            {
                float distance = Vector2.Distance(m_starPosition, transform.position);
                if (distance > m_walkDistance)
                {
                    if (transform.position.x > m_starPosition.x && m_Direction == 1)
                        SetDirection(-1);
                    else if (transform.position.x < m_starPosition.x && m_Direction == -1)
                        SetDirection(1);
                }
                m_Rigidbody2D.velocity = new Vector2(m_WalkSpeed * m_Direction, m_Rigidbody2D.velocity.y);
            }
            yield return null;
        }
    }

    [ContextMenu("Play Idle Animation")]
    private void PlayIdleAnimation()
    {
        m_Animatior.SetTrigger(m_ChangeParamHash);
        m_Animatior.SetInteger(m_StateParamHash, 1);
    }
    [ContextMenu("Play Run Animation")]

    private void PlayRunAnimation()
    {
        m_Animatior.SetTrigger(m_ChangeParamHash);
        m_Animatior.SetInteger(m_StateParamHash, 2);
    }
    [ContextMenu("Play Jump Animation")]

    private void PlayJumpAnimation()
    {
        m_Animatior.SetTrigger(m_ChangeParamHash);
        m_Animatior.SetInteger(m_StateParamHash, 3);
    }

    [ContextMenu("Play DoubleJumb Animation")]
    private void PlayDoubleJumpAnimation()
    {
        m_Animatior.SetTrigger(m_ChangeParamHash);
        m_Animatior.SetInteger(m_StateParamHash, 4);
    }

    [ContextMenu("Play Hit Animation")]
    private void PlayHitAnimation()
    {
        m_Animatior.SetTrigger(m_ChangeParamHash);
        m_Animatior.SetInteger(m_StateParamHash, 5);
    }
}
