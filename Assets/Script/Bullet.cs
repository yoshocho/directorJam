using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float m_bulletSpeed = 3f;
    [SerializeField] float m_bulletLifeTime = 5f;
    float m_fh;
    float m_fv;
    [SerializeField] int m_playerNum;
    [SerializeField] int m_damage = 1;
    [SerializeField] int m_enemy;

    [SerializeField] AudioClip m_audioClip;

    void Start()
    {
        m_fh = Input.GetAxisRaw("FireHorizontal" + m_playerNum);
        m_fv = Input.GetAxisRaw("FireVertical" + m_playerNum);

        float radian = (float)Math.Atan2(m_fv, m_fh);
        float degree = (float)(radian * 180d / Math.PI);

        Quaternion q = Quaternion.Euler(0, degree, 0);

        Rigidbody m_rb = GetComponent<Rigidbody>();
        m_rb.velocity = new Vector3(m_fh, m_rb.velocity.y, m_fv).normalized * m_bulletSpeed;
        this.transform.rotation = q * this.transform.rotation;
        Destroy(this.gameObject, m_bulletLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var players = other.gameObject.GetComponent<IDamage>();
        if (players != null)
        {
            players.AddDamage(m_damage);
        }

        if (other.gameObject.tag == "Player" + m_enemy)
        {
            AudioSource.PlayClipAtPoint(m_audioClip, transform.position);
            Destroy(this.gameObject);
        }
    }

}
