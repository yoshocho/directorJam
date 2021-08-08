using UnityEngine;

public class BombBullet : MonoBehaviour
{
    [SerializeField] float m_bombBulletSpeed = 3f;
    [SerializeField] float m_bombBulletLifeTime = 5f;
    [SerializeField] bool m_bombMood;
    [SerializeField] int m_damage = 1;
    void Start()
    {
        Rigidbody m_rb = GetComponent<Rigidbody>();
        if(m_bombMood)
        {
            m_rb.velocity = new Vector3(Random.Range(-1f, 1f) * m_bombBulletSpeed, m_rb.velocity.y, Random.Range(-1f, 1f) * m_bombBulletSpeed);
        }
        else
        {
            m_rb.velocity = new Vector3(Random.Range(-1f, 1f), m_rb.velocity.y, Random.Range(-1f, 1f)).normalized * m_bombBulletSpeed;
        }
       
        Destroy(this.gameObject, m_bombBulletLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var players = other.GetComponent<IDamage>();
        if (players != null)
        {
            players.AddDamage(m_damage);
        }

        Destroy(this.gameObject);
    }
}
