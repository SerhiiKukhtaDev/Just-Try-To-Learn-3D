using System.Collections.Generic;
using System.Linq;
using Models;

namespace Database.Services
{
    public interface ISubjectsService
    {
        List<Subject> Subjects { get; }

        void SetSubjects(List<Subject> subjects);

        List<Question> GetAllByAllSubjects();

        List<Question> GetAllByAllClasses(Subject subject);

        List<Question> GetAllByAllThemes(Class @class);
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

        public List<Question> GetAllByAllSubjects()
        {
            List<Question> questions = new List<Question>();

            foreach (var theme in Subjects.SelectMany(subject => subject.Items.SelectMany(@class => @class.Items)))
            {
                questions.AddRange(theme.Items);
            }

            return questions;
        }

        public List<Question> GetAllByAllClasses(Subject subject)
        {
            List<Question> questions = new List<Question>();
            
            foreach (var theme in subject.Items.SelectMany(@class => @class.Items))
            {
                questions.AddRange(theme.Items);
            }

            return questions;
        }

        public List<Question> GetAllByAllThemes(Class @class)
        {
            List<Question> questions = new List<Question>();

            foreach (var theme in @class.Items)
            {
                questions.AddRange(theme.Items);
            }

            return questions;
        }
    }
    
    
}
