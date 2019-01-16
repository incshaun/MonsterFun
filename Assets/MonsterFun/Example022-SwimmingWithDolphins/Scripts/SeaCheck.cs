using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaCheck {

   // Height of the sea floor
   private int seaFloor;
   // Height of the sea surface
   private int seaSurface;
   
   public SeaCheck (int floor, int surface)
   {
     seaFloor = floor;
     seaSurface = surface;
   }
   
   // Checks to see if the height value provided as a
   // parameter is in the sea i.e. between floor and 
   // surface.
   public bool inSea (float height)
   {
     if (((int) height > seaFloor) && ((int) height < seaSurface))
     {
       return true;
     }
     return false;
   }
}
