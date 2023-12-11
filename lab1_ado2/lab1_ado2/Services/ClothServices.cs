using lab1_ado2.Models;
using lab1_ado2.Repository.Interface;
using lab1_ado2.Services.Interface;

namespace lab1_ado2.Services
{
    public class ClothServices : IClothService
    {
        private readonly IClothRepository _clothRepository;
        public ClothServices(IClothRepository clothRepository)
        {
            _clothRepository = clothRepository;
        }
        public int createCloth(Cloth cloth)
        {
            return _clothRepository.createCloth(cloth);
        }

        public int deleteCloth(int id)
        {
            return _clothRepository.deleteCloth(id);
        }

        public List<Cloth> getAllCloth()
        {
            return _clothRepository.getAllCloth();
        }

        public Cloth getCloth(int id)
        {
            return _clothRepository.getCloth(id);
        }

        public int updateCloth(Cloth cloth)
        {
            return _clothRepository.updateCloth(cloth);
        }
    }
}
