using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//이 라이브러리 추가하면 Image객체 사용 가능하다.

public class UIAction : MonoBehaviour {
    public float skillCoolTime = 3.0f;
    public Image skillImage;
    public Image hpImage;
    public Image expImage;
    public Text hpText;
    public int maxHP = 100;
    public int currentHP = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (skillImage.fillAmount > 0f)
            skillImage.fillAmount -= Time.deltaTime / skillCoolTime;
        if (skillImage.fillAmount < 0.0f)
            skillImage.fillAmount = 0.0f;
	}

    public void UseSkill() 
    {
        if (CanUseSkill())
        {
            skillImage.fillAmount = 1.0f;
            currentHP -= 10;
            hpImage.fillAmount = (float)currentHP / maxHP;
            hpText.text = currentHP + "/" + maxHP;
            expImage.fillAmount += 0.05f;
        }
    }

    public bool CanUseSkill()
    {
        if (skillImage.fillAmount > 0.0f)
            return false;
        return true;
    }
}
