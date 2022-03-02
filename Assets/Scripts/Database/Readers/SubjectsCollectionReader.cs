using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Interfaces;
using Database.Utils;
using Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Utils.Comparers;

namespace Database.Readers
{
    
    public class SubjectsCollectionReader : ISubjectsCollectionReader
    {
        private readonly IMongoCollection<School> _collection;

        public SubjectsCollectionReader(IMongoCollection<School> collection)
        {
            _collection = collection;
        }

        public async Task<List<Subject>> ReadWithValidation()
        {
            var subjects = await ReadSubjectsAsync();

            RemoveAllEmptyThemes(subjects);
            RemoveAllEmptyClasses(subjects);
            RemoveAllEmptySubjects(ref subjects);
            
            subjects.ForEach(s => s.Items.Sort(new ClassComparer()));

            return subjects;
        }
        
        

        private async Task<List<Subject>> ReadSubjectsAsync()
        {
            var subjects = await _collection.AsQueryable().Where(school => school.Name == "BerSchool")
                .SelectMany(x => x.Items)
                .Where(x => x.Items.Count > 0)
                .ToListAsync();

            return subjects;
        }

        private void RemoveAllEmptyThemes(List<Subject> roots)
        {
            roots.ForEach(sub => sub.Items.ForEach(cl =>
                ReaderHelpers.RemoveAllEmptyItems<Theme, Question, Class>(cl.Items, cl)));
        }

        private void RemoveAllEmptyClasses(List<Subject> roots)
        {
            roots.ForEach(sub => ReaderHelpers.RemoveAllEmptyItems<Class, Theme, Subject>(sub.Items, sub));
        }

        private void RemoveAllEmptySubjects(ref List<Subject> subjects)
        {
            subjects = subjects.Where(subject => subject.Items.Count > 0).ToList();
        }
    }
}
