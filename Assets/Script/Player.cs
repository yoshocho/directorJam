﻿using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody m_rb;
    [SerializeField] float m_speed;
    float m_h;
    float m_v;
    float m_fh;
    float m_fv;
    Vector3 tmp;

    bool m_fire = false;
    [SerializeField]GameObject m_bullet;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void FixedUpdate()
    {
        PlayerNow();
        idou();
    }

    void PlayerNow()
    {
        m_h = Input.GetAxis("Horizontal");//横移動入力
        m_v = Input.GetAxis("Vertical");//縦移動入力
        m_fh = Input.GetAxisRaw("FireHorizontal");
        m_fv = Input.GetAxisRaw("FireVertical");
        tmp = this.transform.position;//自分の位置
    }

    void idou()
    {
        m_rb.velocity = new Vector3(m_speed * m_h, m_rb.velocity.y, m_rb.velocity.z);//横移動
        m_rb.velocity = new Vector3(m_rb.velocity.x, m_rb.velocity.y, m_speed * m_v);//縦移動
    }

    void Fire()//攻撃処理
    {
        m_fire = false;
        if(m_fh != 0 || m_fv != 0)
        {
            m_fire = true;
        }

        if (m_fire)
        {
            Instantiate(m_bullet, new Vector3(tmp.x, tmp.y, tmp.z), this.transform.rotation);
        }
    }
}
