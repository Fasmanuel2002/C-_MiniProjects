
using Microsoft.EntityFrameworkCore;

namespace StudentRestApi.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Student> AddStudent(Student Student)
        {
            var result = await appDbContext.Students.AddAsync(Student);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteStudent(int studentId)
        {
           
            var result = await appDbContext.Students
                .FirstOrDefaultAsync(e => e.StudentId == studentId);

            if (result != null)
            {
                appDbContext.Students.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Student> GetStudent(int studentId)
        {
            return await appDbContext.Students.
                FirstOrDefaultAsync(e => e.StudentId == studentId);
        }

        public async Task<Student> GetStudentByEmail(string email)
        {
            return await appDbContext.Students.
                  FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await appDbContext.Students.ToListAsync();
        }

        public async Task<IEnumerable<Student>> Search(string name, Gender? gender)
        {
            IQueryable<Student> query = appDbContext.Students;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                || e.LastName.Contains(name));

            }
            if(gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }
            return await query.ToListAsync();
        }

        public async Task<Student> UpdateStudent(Student Student)
        {
            var result = await appDbContext.Students
                .FirstOrDefaultAsync(e => e.StudentId == Student.StudentId);

            if (result != null)
            {
                result.FirstName = Student.FirstName;
                result.LastName = Student.LastName;
                result.Email = Student.Email;
                result.DateOfBirth = Student.DateOfBirth;
                result.Gender = Student.Gender;
                if (Student.DepartmentId != 0) { 
                
                    result.DepartmentId = Student.DepartmentId;
                }
                result.PhotoPath = Student.PhotoPath;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
