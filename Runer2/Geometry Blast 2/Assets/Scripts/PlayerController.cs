using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float _timeHeld = 0.0f;
    public float _timeForFullJump = 2.0f;
    public float _minJumpForce = 0.5f;
    public float _maxJumpForce = 2.0f;
    public float _leftJumpForce = 1.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _timeHeld = 0f;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _timeHeld += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        float verticalJumpForce = ((_maxJumpForce - _minJumpForce) * (_timeHeld / _timeForFullJump)) + _minJumpForce;
        if (verticalJumpForce > _maxJumpForce)
        {
            verticalJumpForce = _maxJumpForce;
        }
        Vector2 resolvedJump = new Vector2(-_leftJumpForce, verticalJumpForce);
        GetComponent<Rigidbody2D>().AddForce(resolvedJump, ForceMode2D.Impulse);
        Debug.Log(resolvedJump.ToString());
    }
}