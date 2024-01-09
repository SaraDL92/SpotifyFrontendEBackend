using SpotiAPI.Repo;
using SpotiAPI.Service.Interfaces;
using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;

namespace SpotiAPI.Service
{
    public class RadioService:IRadioService { 
   private readonly IGenericRepository<Radio> _radioRepository;

    public RadioService(IGenericRepository<Radio> radioRepo)
    {

        _radioRepository = radioRepo;
    }

    public void CreateRadio(

      string titleOfRadio,

    ICollection<Song> songs)
        {        _radioRepository.Create(new Radio{ TitleOfRadio=titleOfRadio,Songs=songs});
    }

    public string Delete(int id)
    {
        try
        {
            return _radioRepository.Delete(id);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    public List<Radio> GetAllRadios() { return _radioRepository.GetAll(); }

    public Radio GetSingleRadio(int id) { return _radioRepository.GetSingle(id); }
    public void UpdateRadio(int id, Radio radio) { _radioRepository.Update(id, radio); }
}
}

