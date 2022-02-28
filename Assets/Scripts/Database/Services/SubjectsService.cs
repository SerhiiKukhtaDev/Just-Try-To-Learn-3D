using System.Collections.Generic;
using Models;

namespace Database.Services
{
    public interface ISubjectsService
    {
        List<Subject> Subjects { get; }

        void SetSubjects(List<Subject> subjects);
    }

    public class SubjectsService : ISubjectsService
    {
        private List<Subject> _subjects;

        public SubjectsService() : this(null) {}

        public SubjectsService(List<Subject> subjects)
        {
            _subjects = subjects;
        }

        public void SetSubjects(List<Subject> subjects)
        {
            _subjects = subjects;
        }

        public List<Subject> Subjects => _subjects;
    }
    
    
}
