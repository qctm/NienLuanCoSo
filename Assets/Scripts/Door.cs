using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Sprite m_OpenDoorSprite;
    [SerializeField] private Sprite m_CloseDoorSprite;

    private Collider2D m_Collider;
    private Collider2D m_SpriteRenderer;
  
    void Start()
    {
        TryGetComponent(out m_Collider);
        TryGetComponent(out m_SpriteRenderer);
    }

    private void OpenDoor()
    {
        m_Collider.enabled = true;
        //m_SpriteRenderer.sprite = m_OpenDoorSprite;
    }
    private void CloseDoor()
    {
        m_Collider.enabled = false;
        //m_CloseDoorSprite.sprite = m_CloseDoorSprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GamePlayManager.Instance.GameOver(true);
        }
    }
    private void OnDestroy()
    {
     
    }
    private void OnCherryFinal()
    {
      
    }
}
