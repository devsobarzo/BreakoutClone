using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 5;
    [SerializeField] float xLimit = 5;
    [SerializeField] float bigSizeTime = 10;
    [SerializeField] GameManager gameManager; 
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireRate = 1;
    [SerializeField] float bulletsTime = 10;
    [SerializeField] Vector3 bulletOffset;
    bool bulletsActive;
    public bool BulletsActive{
        get => bulletsActive;
        set{
            bulletsActive = value;
            StartCoroutine(ShootBullets());
            Invoke("ResetBulletsActive", bulletsTime);
        }
    }
    void ResetBulletsActive()
    {
        bulletsActive = false;
        gameManager.powerUpIsActive = false;
    }

    IEnumerator ShootBullets()
    {
        while (BulletsActive)
        {
           Instantiate(bulletPrefab, transform.position + bulletOffset, Quaternion.identity);
            yield return new WaitForSeconds(fireRate);     
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4, 0);
 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
      
        MoveLimits();
    }

    void Move()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * movement * Time.deltaTime * paddleSpeed;
    }

    void MoveLimits()
    {
        if(transform.position.x > 7.44f)
        {
            transform.position = new Vector3(7.44f, transform.position.y, 0);
        }
        else if(transform.position.x < -7.44f)
        {
            transform.position = new Vector3(-7.44f, transform.position.y, 0);
        }

    }

    public void IncreaseSize()
    {
        if(!gameManager.ballIsOnPlay)
            return;
        Vector3 newSize = transform.localScale;
        newSize.x = 1.2f;
        transform.localScale = newSize; 
        StartCoroutine(BackToOriginalSize());
    }

    IEnumerator BackToOriginalSize()
    {
        yield return new WaitForSeconds(bigSizeTime);
        transform.localScale = new Vector3(0.8f, 0.5f, 1);
        gameManager.powerUpIsActive = false;
    }

}
