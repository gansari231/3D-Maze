using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [HideInInspector]
    public Animator playerAnimator;
    PlayerController _playerController;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _playerController.PlayerMovement();
        _playerController.PlayerAttack();
    }

    public void SetPlayerController(PlayerController _playerController)
    {
        this._playerController = _playerController;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player Taking Damage: " + damage);
        PlayerHurt();
        _playerController.UpdateHealth(damage);
    }

    void PlayerHurt()
    {
        playerAnimator.SetTrigger("Hurt");
    }

    public void PlayerDeath()
    {      
        playerAnimator.SetTrigger("Die");
        UIManager.Instance.GameOver();
    }
}
