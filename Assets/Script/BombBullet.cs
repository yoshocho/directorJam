using System;
using UnityEngine;

public class BombBullet : MonoBehaviour
{
    [SerializeField] float m_bombBulletSpeed = 3f;
    [SerializeField] float m_bombBulletLifeTime = 5f;
    [SerializeField] bool m_bombMood;
    [SerializeField] int m_damage = 1;
    [SerializeField] GameObject m_me;
    Rigidbody m_rb;

[SerializeField] AudioClip m_audioClip;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        float randomx = UnityEngine.Random.Range(-1f, 1f);
        float randomy = UnityEngine.Random.Range(-1f, 1f);

        float radian = (float)Math.Atan2(randomy, randomx);
        float degree = (float)(radian * 180d / Math.PI);

        Quaternion q = Quaternion.Euler(0, degree, 0);
        this.transform.rotation = q * this.transform.rotation;

        if (m_bombMood)
        {
            m_rb.velocity = new Vector3(randomx * m_bombBulletSpeed, m_rb.velocity.y, randomy * m_bombBulletSpeed);
        }
        else
        {
            m_rb.velocity = new Vector3(randomx, m_rb.velocity.y, randomy).normalized * m_bombBulletSpeed;
        }
        AudioSource.PlayClipAtPoint(m_audioClip, transform.position);
        Destroy(this.gameObject, m_bombBulletLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var players = other.gameObject.GetComponent<IDamage>();
        if (players != null)
        {
            players.AddDamage(m_damage);
        }

        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            AudioSource.PlayClipAtPoint(m_audioClip, transform.position);
            Destroy(this.gameObject);
        }

        if(other.gameObject.tag == "kabe")
        {
            m_rb.velocity = new Vector3(this.transform.position.x * -1, m_rb.velocity.y, this.transform.position.z *-1).normalized * m_bombBulletSpeed;
        }
    }
}
