using MetaMindsCodingTask.Models;

namespace MetaMindsCodingTask.Repositories
{
    public class UserRepository : IUserRepository
    {
        private HttpClient _client = new HttpClient();
        private string baseUrl = "https://reqres.in/api/users";

        public UserRepository()
        {
            _client.BaseAddress = new Uri(baseUrl);
        }

        /// <summary>
        /// Get List of Users
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <returns></returns>
        public UserModel Get(int pageNumber = 1)
        {
            UserModel _user = new UserModel();

            var response = _client.GetAsync(String.Concat("?page=", pageNumber));
            response.Wait();

            var results = response.Result;
            if(results.IsSuccessStatusCode)
            {
                var readContents = results.Content.ReadAsAsync<UserModel>();
                readContents.Wait();

                _user = readContents.Result;
            }

            return _user;
        }

        /// <summary>
        /// Get specific User
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns></returns>
        public UserModel GetUser(int userID)
        {
            UserModel _user = new UserModel();

            var response = _client.GetAsync(userID.ToString());
            response.Wait();

            var results = response.Result;
            if (results.IsSuccessStatusCode)
            {
                var readContents = results.Content.ReadAsAsync<UserModel>();
                readContents.Wait();

                _user = readContents.Result;
            }

            return _user;
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="user">New User object</param>
        /// <returns></returns>
        public DataModel Create(DataModel user)
        {
            DataModel _data = new DataModel();
            List<AttendanceModel> attendances = new List<AttendanceModel>();

            // get last week's weekday dates
            DayOfWeek weekStart = DayOfWeek.Monday;
            DateTime startingDate = DateTime.Today;

            while (startingDate.DayOfWeek != weekStart)
                startingDate = startingDate.AddDays(-1);

            DateTime previousWeekStart = startingDate.AddDays(-7);
            DateTime previousWeekEnd = startingDate.AddDays(-1);

            Console.WriteLine(previousWeekStart);
            Console.WriteLine(previousWeekEnd);

            for (int counter = 0; counter < 5; counter++)
            {
                var attendance = new AttendanceModel();

                attendance.Id = counter;
                attendance.Date = startingDate.AddDays(-7 + counter);
                attendance.TimeIn = Convert.ToDateTime(String.Concat(attendance.Date.ToShortDateString() ," 08:00:00 AM"));
                attendance.TimeOut = Convert.ToDateTime(String.Concat(attendance.Date.ToShortDateString(), " 05:00:00 PM"));
                attendances.Add(attendance);
            }

            var postResponse = _client.PostAsJsonAsync<DataModel>("", user);
            postResponse.Wait();

            var results = postResponse.Result;
            if (results.IsSuccessStatusCode)
            {
                var postContent = results.Content.ReadAsAsync<DataModel>();
                postContent.Wait();

                _data = postContent.Result;
                _data.Attendance = attendances;
            }

            return _data;
        }

        /// <summary>
        /// Delete a User.
        /// </summary>
        /// <param name="userID">user Id</param>
        public void Delete(int userID)
        {
            var deleteTask = _client.DeleteAsync(userID.ToString());
            deleteTask.Wait();

            var result = deleteTask.Result;
        }
    }
}
