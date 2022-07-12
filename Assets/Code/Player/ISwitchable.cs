using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player.Components
{
    public interface ISwitchable
    {
        bool IsEnabled { get; set; }
    }
}
