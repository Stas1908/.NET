using lab1_ado2.Models;

namespace lab1_ado2.Services.Interface
{
    public interface IClothService
    {
        List<Cloth> getAllCloth();
        Cloth getCloth(int id);
        int createCloth(Cloth cloth);
        int updateCloth(Cloth cloth);
        int deleteCloth(int id);
    }
}
