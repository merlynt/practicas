using Practica_1.Data;
using Practica_1.Models;

namespace Practica_1.Repositories
{
    public class StaffCategoryRepository
    {
        private readonly AplicationDbContext _aplicationDbContext;

        public StaffCategoryRepository(AplicationDbContext aplicationDbContext)
        {
            _aplicationDbContext = aplicationDbContext;
        }

        public List<StaffCategoryModel> GetAll()
        {
            return _aplicationDbContext.staffCategoryModel.ToList();
        }

        public StaffCategoryModel GetById(int id)
        {
            return _aplicationDbContext.staffCategoryModel.FirstOrDefault(p => p.Id == id);
        }

        public void Add(StaffCategoryModel staffCategoryModel)
        {
            _aplicationDbContext.staffCategoryModel.Add(staffCategoryModel);
            _aplicationDbContext.SaveChanges();
        }

        public void Update(StaffCategoryModel staffCategoryModel)
        {
            _aplicationDbContext.staffCategoryModel.Update(staffCategoryModel);
            _aplicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var staffCategory = _aplicationDbContext.staffCategoryModel.Find(id);

            if (staffCategory != null)
            {
                _aplicationDbContext.staffCategoryModel.Remove(staffCategory);
                _aplicationDbContext.SaveChanges();
            }
        }
    }
}
