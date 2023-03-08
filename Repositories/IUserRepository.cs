using MetaMindsCodingTask.Models;

namespace MetaMindsCodingTask.Repositories
{
    public interface IUserRepository
    {
        UserModel Get(int pageNumber = 1);
        SingleUserModel GetUser(int userID); 
        DataModel Create(string user);
        void Delete(int userID);
    }
}
