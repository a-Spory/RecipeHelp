using System.Linq;

namespace RecipeHelp.Models
{
    public interface IUserRepo
    {
        //CREATE

        public User Create(User u);

        //READ

        public IQueryable<User> GetAllUsers();
        public User GetUserByEmail(string email);
        public User GetUserById(int id);
        public bool Login(User u);
        public void Logout();
        public bool IsUserLoggedIn();
        public int GetLoggedInUserId();
        public string GetLoggedInUserName();
        


        //UPDATE

        public User Update(User u);
        public bool ChangePassword(string oldPass, string newPass);

        //DELETE

        public bool DeleteUser(int id);

        public bool DeleteUser(User user);
    }
}
