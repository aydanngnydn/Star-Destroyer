using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private GameObject bulletDestroyEffect;
    [SerializeField] private float destroyTime;
    [SerializeField] private Score[] scoreTexts;
    [SerializeField] private float scorePerKill;

    private void OnEnable()
    {
        //foreach (Score score in scoreTexts)
        //scoreTexts = FindObjectOfType<Score>();
        ResetHealth();
    }

    public void DecraseHealth(int damage)
    {
        currentHealth -= damage;

        if (!AliveCheck())
        {
            DestroyObject();
        }
    }

    public void IncreaseHealth(int refill)
    {
        currentHealth += refill;
    }

    public bool AliveCheck()
    {
        return currentHealth > 0;
    }

    public void DestroyObject()
    {
        //scoreText.score += scorePerKill;
        Destroy(gameObject);
    }

    private void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void DestroyPlayerBullet(GameObject playerBullet, Vector2 contact)
    {
        Destroy(playerBullet);
        GameObject destroyedObject = Instantiate(bulletDestroyEffect, contact, Quaternion.identity);
        Destroy(destroyedObject, destroyTime);
    }
}
