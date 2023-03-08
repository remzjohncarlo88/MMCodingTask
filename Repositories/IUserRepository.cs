using MetaMindsCodingTask.Models;

namespace MetaMindsCodingTask.Repositories
{
    public interface IUserRepository
    {
        UserModel Get(int pageNumber = 1);
        UserModel GetUser(int userID); 
        DataModel Create(DataModel user);
        void Delete(int userID);
    }
}
