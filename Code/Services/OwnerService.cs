using Code.Models;

namespace Code.Services
{ 
  public class OwnerService
  {
      FlatService flatService = new FlatService();
      public float calculateOwnerFlatsCost(Owner owner, float squareMetersCost){
        float total = 0;

        owner.Flats.ForEach(flat => {
          total += flatService.calculateFlatCost(flat, squareMetersCost);
        });

        return total;
        
      }
  }  
}