using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMesh Pro ���

public class DamageText : MonoBehaviour
{
    public float moveSpeed; //�ؽ�Ʈ �̵��ӵ�
    public float alphaSpeed; //���� ��ȯ�ӵ�(���İ� = ����)
    public float destroyTime; //���� �ӵ�
    TextMeshPro text;
    Color alpha;

    public float dmg;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.text = dmg.ToString();
        alpha = text.color;

        Invoke("DestroyText", destroyTime);
    }

    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a , 0, Time.deltaTime * alphaSpeed);
        text.color = alpha;
    }

    void DestroyText()
    {
        Destroy(gameObject);
    }
}
