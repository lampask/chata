using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brokolica : Plant {
    protected override void Start() {
        base.death_sound = "Brok_Karf_Death";
        base.plant_sound = "Brok_Karf_Sadenie";
        base.Start();
    }
}
