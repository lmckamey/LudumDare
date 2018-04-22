using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int m_numOfTeleports = 2;
    [SerializeField] float m_teleportDistance = 6.0f;
    [SerializeField] Transform m_safeSpace;
    [SerializeField] GameObject m_TryAgainMenu;
    [SerializeField] Text m_teleportText;

    float TeleportDelay = 0.7f;
    float lossDelay = 1.0f;
    float TeleportDelayTimer;
    float lossDelayTimer;
    bool isTeleporting;
    public bool hasWon;


    AudioSource m_audioSource;
    Animator m_animator;
    SpriteRenderer m_spriteRenderer;
    Vector2 mouseLocation = Vector2.zero;

    private void Start()
    {
        m_audioSource = gameObject.GetComponent<AudioSource>();
        m_animator = gameObject.GetComponent<Animator>();
        m_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        m_teleportText.text = "Remaining Teleports: " + m_numOfTeleports;
    }

    void Update()
    {
        if (isTeleporting)
        {
            TeleportDelayTimer += Time.deltaTime;
            if (TeleportDelayTimer >= TeleportDelay)
            {
                m_audioSource.Play();
                Teleport(mouseLocation);
                isTeleporting = false;
                TeleportDelayTimer = 0.0f;
                m_animator.SetBool("isTelporting", isTeleporting);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            mouseLocation = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (Vector2)transform.position - (Vector2)mouseLocation;
            float distance = (direction).magnitude;
            if (distance < m_teleportDistance && m_numOfTeleports > 0)
                isTeleporting = true;
            m_animator.SetBool("isTelporting", isTeleporting);
        }
        if (m_numOfTeleports <= 0 && !hasWon)
        {
            lossDelayTimer += Time.deltaTime;
            if (lossDelayTimer >= lossDelay)
            {

                m_TryAgainMenu.SetActive(true);
            }
        }
    }

    public void Teleport(Vector2 pos)
    {
        transform.position = pos;
        m_numOfTeleports--;
        m_teleportText.text = "Remaining Teleports: " + m_numOfTeleports;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "KillBox" || collision.tag == "Arrows")
        {
            Teleport(m_safeSpace.position);
            m_TryAgainMenu.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Arrows")
        {
            Teleport(m_safeSpace.position);
            m_TryAgainMenu.SetActive(true);

        }
    }
}
