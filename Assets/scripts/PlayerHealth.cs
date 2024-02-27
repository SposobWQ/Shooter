using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public RectTransform ValueRectTransform;
    public float Health;
    public GameObject GamePlayUI;
    public GameObject GameOverScreen;

    private float _maxhealth;
    public void Start()
    {
        _maxhealth = Health;
    }
    public void DealDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }
    private void DrawHealthBar()
    {
        ValueRectTransform.anchorMax = new Vector2(Health / _maxhealth, 1);
    }
    public void PlayerIsDead()
    {
        Time.timeScale = 0;
        GamePlayUI.gameObject.SetActive(false);
        GameOverScreen.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GetComponent<PlayerController>().enabled=false;
        GetComponent<FireBallCaster>().enabled = false;
        GetComponent<Camerarot>().enabled = false;
    }
    

    
}
