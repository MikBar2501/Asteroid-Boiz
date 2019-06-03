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

        public string[] deathTexts;

        public TextMeshProUGUI tbestScore;
        public TextMeshProUGUI tscore;

        int score;
        int bestScore;

        private void Awake()
        {
            instance = this;
            bestScore = GetBestScore();
            if(bestScore > 0)
                tbestScore.text = "Best" + "\n" + bestScore;
            else
                tbestScore.text = "";
            //gameObject.SetActive(false);
        }

        public void SetScore(int score)
        {
            this.score = score;

            tscore.text = score + "";
            if (score > bestScore)
            {
                if (bestScore > 0)
                {
                    tscore.color = Color.yellow;
                    tbestScore.color = Color.yellow;
                    tbestScore.text = "Best" + "\n" + score;
                }

                PlayerPrefs.SetInt("score", score);
            }
        }

        int GetBestScore()
        {
            if (!PlayerPrefs.HasKey("score"))
                return 0;

            return PlayerPrefs.GetInt("score");
        }

        public void ShowText(string text)
        {
           // gameObject.SetActive(true);

           // levelAnimator.ResetTrigger("anim");
            levelAnimator.enabled = true;
            levelAnimator.GetComponent<TextMeshProUGUI>().text = text;
            levelAnimator.Play("anim", 0, 0);
        }

        public void DeathSequence()
        {
            StopAllCoroutines();
            StartCoroutine(IDeathSequence());

        }

        IEnumerator IDeathSequence()
        {
            ShowText("Game Over");

            yield return new WaitForSeconds(2);

            GameManager.instance.SetState(State.playerDead);

            yield return new WaitForSeconds(2);

            while (true)
            {
                ShowText(deathTexts[Random.Range(0, deathTexts.Length)]);
                yield return new WaitForSeconds(3);
            }

        }

#if UNITY_EDITOR
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                PlayerPrefs.DeleteAll();
                tbestScore.text = "";
            }
        }
#endif
    }
}
