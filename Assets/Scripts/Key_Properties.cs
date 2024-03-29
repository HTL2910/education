using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Properties : Door_Properties
{
   void Update()
   {
        base.InputNear(KeyCode.G);
   }    
}
