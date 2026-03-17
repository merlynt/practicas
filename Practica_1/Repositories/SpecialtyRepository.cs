using Practica_1.Data;
using Practica_1.Models;

namespace Practica_1.Repositories
{
    public class SpecialtyRepository
    {
        private readonly AplicationDbContext _aplicationDbContext;

        public SpecialtyRepository(AplicationDbContext aplicationDbContext)
        {
            _aplicationDbContext = aplicationDbContext;
        }

        public List<SpecialtyModel> GetAll()
        {
            return _aplicationDbContext.specialtyModel.ToList();
        }

        public SpecialtyModel GetById(int id)
        {
            return _aplicationDbContext.specialtyModel.FirstOrDefault(p => p.Id == id);
        }

        public void Add(SpecialtyModel specialtyModel)
        {
            _aplicationDbContext.specialtyModel.Add(specialtyModel);
            _aplicationDbContext.SaveChanges();
        }

        public void Update(SpecialtyModel specialtyModel)
        {
            _aplicationDbContext.specialtyModel.Update(specialtyModel);
            _aplicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var specialty = _aplicationDbContext.specialtyModel.Find(id);

            if (specialty != null)
            { 
                _aplicationDbContext.specialtyModel.Remove(specialty);
                _aplicationDbContext.SaveChanges();
            }
        }
    }
}
