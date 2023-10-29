using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player2 : MonoBehaviour
{
    [SerializeField]
    private string m_InputName;

    [SerializeField]
    private float m_Speed;

    private Rigidbody2D m_Rigibody2D;
    private Vector2 m_Velocity;

    void Start()
    {
        m_Rigibody2D = GetComponent<Rigidbody2D>();
        m_Velocity = m_Rigibody2D.velocity;
    }

    void FixedUpdate()
    {
        m_Velocity.y = Input.GetAxisRaw("Player2") * m_Speed;
        m_Rigibody2D.velocity = m_Velocity;
    }
}
