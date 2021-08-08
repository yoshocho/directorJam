using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float m_bulletSpeed = 3f;
    [SerializeField] float m_bulletLifeTime = 5f;
    float m_fh;
    float m_fv;
    [SerializeField] int m_playerNum;
    [SerializeField] int m_damage = 1;

    void Start()
    {
        m_fh = Input.GetAxisRaw("FireHorizontal" + m_playerNum);
        m_fv = Input.GetAxisRaw("FireVertical" + m_playerNum);
        Rigidbody m_rb = GetComponent<Rigidbody>();
        m_rb.velocity = new Vector3(m_fh, m_rb.velocity.y, m_fv).normalized * m_bulletSpeed;
        Destroy(this.gameObject, m_bulletLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var players = other.GetComponent<IDamage>();
        players.AddDamage(m_damage);
    }

}
