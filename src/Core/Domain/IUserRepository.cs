using SikhResearchInstitute.Core.Domain.Model;

namespace SikhResearchInstitute.Core.Domain
{
    public interface IUserRepository : IKeyedRepository<User>    
    {
        User GetByUserName(string username);
    }
}
