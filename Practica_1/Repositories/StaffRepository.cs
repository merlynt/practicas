using Microsoft.EntityFrameworkCore;
using Practica_1.Data;
using Practica_1.Models;

namespace Practica_1.Repositories
{
    public class StaffRepository
    {
        private readonly AplicationDbContext _aplicationDbContext;
    
            public StaffRepository(AplicationDbContext aplicationDbContext)
            {
                _aplicationDbContext = aplicationDbContext;
            }
    
            public List<StaffModel> GetAll()
            {
                return _aplicationDbContext.staffModel
                    .Include(s => s.StaffCategory)
                    .Include(s => s.Specialty) // Incluir la relación con StaffCategoryModel
                    .ToList();
        }
    
            public StaffModel GetById(int id)
            {
                return _aplicationDbContext.staffModel
                    .Include(s => s.StaffCategory)
                    .Include(s => s.Specialty)
                    .FirstOrDefault(sm => sm.Id == id);
            }
    
            public void Add(StaffModel staffModel)
            {
                _aplicationDbContext.staffModel.Add(staffModel);
                _aplicationDbContext.SaveChanges();
            }
    
            public void Update(StaffModel staffModel)
            {
                _aplicationDbContext.staffModel.Update(staffModel);
                _aplicationDbContext.SaveChanges();
            }
    
            public void Delete(int id)
            {
                var staff = _aplicationDbContext.staffModel.Find(id);
    
                if (staff != null)
                {
                    _aplicationDbContext.staffModel.Remove(staff);
                    _aplicationDbContext.SaveChanges();
                }
        }
    }
}
