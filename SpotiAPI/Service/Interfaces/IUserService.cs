using Spotify_DataLayer.Models;
using System.Collections.Generic;

namespace SpotiAPI.Service.Interfaces
{
    public interface IUserService
    {
        public void CreateUser(
        string username,
   string password,

      string email,

 Radio setting);

        public string Delete(int id);

        public List<User> GetAllUsers();
        public User GetSingleUser(int id);
        public void UpdateUser(int id, User user);
    }
}
