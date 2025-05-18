using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contexts;
using DAL.Entities;

namespace Repo
{
    public class DepartmentRepository
    {
        private readonly CompanyDBContext _context;

        public DepartmentRepository()
        {
            _context = new CompanyDBContext();
        }

        public IEnumerable<Department> GetAll() => _context.Departments.ToList();
        public Department GetById(int id) => _context.Departments.Find(id);

        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges();
        }

        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }

        public int Delete(Department department)
        {
            _context.Departments.Remove(department);
            return _context.SaveChanges();
        }
    }
}
