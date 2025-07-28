namespace StudentRestApi.Models
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> Search(string name, Gender? gender);
        Task<Student> GetStudent(int StudentId);

        Task<IEnumerable<Student>> GetStudents();

        Task<Student> GetStudentByEmail(string Email);

        Task<Student> AddStudent(Student Student);

        Task<Student> UpdateStudent(Student Student);

        Task DeleteStudent(int StudentId);


    }
}
