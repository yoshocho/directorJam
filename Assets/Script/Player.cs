using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody m_rb;
    [SerializeField] float m_speed;
    float m_h;
    float m_v;
    float m_f;
    float m_fh;
    float m_fv;
    Vector3 tmp;
    [SerializeField] int m_playerNum;

    bool m_fire = false;
    bool m_fireButton = false;
    [SerializeField]GameObject m_bullet;

    float m_timeElpsed;
    [SerializeField] float m_rate;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }


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
        m_h = Input.GetAxis("Horizontal" + m_playerNum);//横移動入力
        m_v = Input.GetAxis("Vertical" + m_playerNum);//縦移動入力
        m_fh = Input.GetAxisRaw("FireHorizontal" + m_playerNum);
        m_fv = Input.GetAxisRaw("FireVertical" + m_playerNum);
        m_f = Input.GetAxisRaw("Fire");
        tmp = this.transform.position;//自分の位置
    }

    void idou()
    {

        m_rb.velocity = new Vector3(m_speed * m_h, m_rb.velocity.y, m_rb.velocity.z);//横移動
        m_rb.velocity = new Vector3(m_rb.velocity.x, m_rb.velocity.y, m_speed * m_v);//縦移動

        m_rb.velocity = new Vector3(m_speed * m_h, m_rb.velocity.y, m_speed * m_v);//移動

    }

    void Fire()//攻撃処理
    {
        m_fire = false;
        if(m_fh != 0 || m_fv != 0)
        {
            m_fire = true;
        }

        m_fireButton = false;
        if (m_f < 0)
        {
            m_fireButton = true;
        }

        m_timeElpsed += Time.deltaTime;
        if (m_rate < m_timeElpsed && m_fire && m_fireButton)
        {
            Instantiate(m_bullet, new Vector3(tmp.x, tmp.y, tmp.z), this.transform.rotation);
            m_timeElpsed = 0;
        }
    }
}
