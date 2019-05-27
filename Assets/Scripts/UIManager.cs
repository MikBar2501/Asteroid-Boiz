using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        public Animator levelAnimator;

        private void Awake()
        {
            instance = this;
            //gameObject.SetActive(false);
        }

        public void ShowText(string text)
        {
           // gameObject.SetActive(true);

           // levelAnimator.ResetTrigger("anim");
            levelAnimator.enabled = true;
            levelAnimator.GetComponent<TextMeshProUGUI>().text = text;
            levelAnimator.Play("anim", 0, 0);
        }
    }
}
