using lab1_ado2.Models;

namespace lab1_ado2.Repository.Interface
{
    public interface IClothRepository
    {
        List<Cloth> getAllCloth();
        Cloth getCloth(int id);
        int createCloth(Cloth cloth);
        int updateCloth(Cloth cloth);
        int deleteCloth(int id);
    }
}
