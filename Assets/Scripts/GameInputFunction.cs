using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class GameInputFunction : MonoBehaviour
{
    public bool shoot;
    public bool jump;

    private void Update()
    {
        if (shoot == true)
        {
            Shoot();
        }

        if (jump == true)
        {
            Jump();
        }
    }

    #region Shoot
    public void onPointerDownShootNow()
    {
        shoot = true;
    }
    public void onPointerDownShootStop()
    {
        shoot = false;
    }
    void Shoot()
    {
        FindObjectOfType<Shootbullet>().ShootNOW();
    }
    #endregion

    public void Throw()
    {
        FindObjectOfType<PlayerGranade>().ThrowNade();
    }

    #region Jump
    public void onPointerDownJumpNow()
    {
        jump = true;
    }
    public void onPointerDownJumpStop()
    {
        jump = false;
    }
    void Jump()
    {
        FindObjectOfType<PlayerMovement>().Jump();
    }
    #endregion
}
