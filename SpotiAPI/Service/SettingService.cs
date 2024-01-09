using SpotiAPI.Repo;
using SpotiAPI.Service.Interfaces;
using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpotiAPI.Service
{
    public class SettingService:ISettingService
    {
        private readonly IGenericRepository<Setting> _settingRepository;

        public SettingService(IGenericRepository<Setting> settingRepo)
        {

            _settingRepository = settingRepo;
        }

        public void CreateSetting(

        
      bool lightTheme,
         bool goldPlan ,
         bool freePlan,
         bool premiumPlan,
        
         User user ,
        string selectedTimeZoneId )
        {
            _settingRepository.Create(new Setting { LightTheme=lightTheme,GoldPlan=goldPlan,FreePlan=freePlan,PremiumPlan=premiumPlan,User=user,SelectedTimeZoneId=selectedTimeZoneId });
        }

        public string Delete(int id)
        {
            try
            {
                return _settingRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Setting> GetAllSettings() { return _settingRepository.GetAll(); }

        public Setting GetSingleSetting(int id) { return _settingRepository.GetSingle(id); }
        public void UpdateSetting(int id,Setting setting) { _settingRepository.Update(id, setting); }
    }
}

