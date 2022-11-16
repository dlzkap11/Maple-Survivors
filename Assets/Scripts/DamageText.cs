using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMesh Pro 사용

public class DamageText : MonoBehaviour
{
    public float moveSpeed; //텍스트 이동속도
    public float alphaSpeed; //색상 변환속도(알파값 = 투명도)
    public float destroyTime; //삭제 속도
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
