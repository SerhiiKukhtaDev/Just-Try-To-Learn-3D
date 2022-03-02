using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Database.Interfaces
{
    public interface ISubjectsCollectionReader
    {
        Task<List<Subject>> ReadWithValidation();
    }
}