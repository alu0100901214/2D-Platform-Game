using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    public int maxEnergy = 100;
    public int currentEnergy;
    public EnergyBar energyBar;

    void Start(){
        currentEnergy = maxEnergy;
        energyBar.setMaxEnergy(maxEnergy);
    }

    public void loseEnergy(int energy){
        if((currentEnergy - energy) > 0 ){
            currentEnergy -= energy;
            energyBar.setEnergy(currentEnergy);
        } else {
            currentEnergy = 0;
            print("dead");
            energyBar.setEnergy(currentEnergy);
        }
    }

    public void gainEnergy(int energy){
        if((currentEnergy + energy) < maxEnergy ){
            currentEnergy += energy;
            energyBar.setEnergy(currentEnergy);
        } else {
            currentEnergy = maxEnergy;
            energyBar.setEnergy(currentEnergy);
        }
    }
}
