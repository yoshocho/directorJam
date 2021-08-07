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

<<<<<<< HEAD
=======
    float m_timeElpsed;
    [SerializeField] float m_rate;

    // Start is called before the first frame update
>>>>>>> b292e8d2cab6b22aa62f9e3a390da44da808d01e
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
<<<<<<< HEAD
        m_rb.velocity = new Vector3(m_speed * m_h, m_rb.velocity.y, m_rb.velocity.z);//横移動
        m_rb.velocity = new Vector3(m_rb.velocity.x, m_rb.velocity.y, m_speed * m_v);//縦移動
=======
        m_rb.velocity = new Vector3(m_speed * m_h, m_rb.velocity.y, m_speed * m_v);//移動

        //if (m_h != 0 || m_v != 0)
        //{
        //    var direction = new Vector3(m_h, 0, m_v);
        //    agent.Move(direction * Time.deltaTime);
        //}

        //if (m_fh != 0 || m_fv != 0)
        //{
        //    var direction = new Vector3(m_fh, 0, m_fv);
        //    transform.localRotation = Quaternion.LookRotation(direction);
        //}
>>>>>>> b292e8d2cab6b22aa62f9e3a390da44da808d01e
    }

    void Fire()//攻撃処理
    {
        m_fire = false;
        if(m_fh != 0 || m_fv != 0)
        {
            m_fire = true;
        }

        m_timeElpsed += Time.deltaTime;
        if (m_rate < m_timeElpsed && m_fire)
        {
            Instantiate(m_bullet, new Vector3(tmp.x, tmp.y, tmp.z), this.transform.rotation);
            m_timeElpsed = 0;
        }
    }
}
