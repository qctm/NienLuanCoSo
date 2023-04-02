using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    private int m_ChangeParamHash;
    private int m_StateParamHash;
    void Start()
    {
        m_ChangeParamHash = Animator.StringToHash("Change");
        m_StateParamHash = Animator.StringToHash("State");
    }
    [ContextMenu("play cherry")]
    private void PlayCherryAnimation()
    {
        m_Animator.SetTrigger(m_ChangeParamHash);
        m_Animator.SetTrigger(m_StateParamHash);
    }
   
}
