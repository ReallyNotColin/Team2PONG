using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows us to make multiple speedbuff objects with properties we can manipulate; We can have variations of the same power up
[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
 
public class SpeedBuff : Powerup // Calls PowerUpObject
{
    public float speed_amount;
    public override void Apply(GameObject target)
    {
        // How to apply duration to this??? 
        Debug.Log(target);
        if (target.ToString()[0] == 'B') {
            target.GetComponent<Ball>().speed += speed_amount;
        }
        else if (target.ToString()[0] == 'P') {
            target.GetComponent<Paddle>().speed += speed_amount;
        }

    }

                

}
