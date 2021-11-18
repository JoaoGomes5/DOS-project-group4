using Code.Models;

namespace Code.Services
{ 
  public class FlatService
  {
      public float calculateFlatCost(Flat flat, float squareMeterCost){

        float flatCost = flat.SquareMeters * squareMeterCost;
        return flatCost;
      }
  }  
}