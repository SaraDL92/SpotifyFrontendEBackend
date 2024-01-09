using SpotiAPI.Repo;
using SpotiAPI.Service.Interfaces;
using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpotiAPI.Service
{
    public class UserService:IUserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User>userRepo)
        {

            _userRepository = userRepo;
        }

        public void CreateUser( 
         string username, 
    string password ,

       string email, 

  Radio setting )
        {
            _userRepository.Create(new User {Username=username,Password=password,Email=email,Setting=setting  });
        }

        public string Delete(int id)
        {
            try
            {
                return _userRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<User> GetAllUsers() { return _userRepository.GetAll(); }

        public User GetSingleUser(int id) { return _userRepository.GetSingle(id); }
        public void UpdateUser(int id, User user) { _userRepository.Update(id, user); }


    }
}
