using Spotify_DataLayer.Models;
using System.Collections.Generic;

namespace SpotiAPI.Service.Interfaces
{
    public interface ISettingService
    {


        public void CreateSetting(


    bool lightTheme,
       bool goldPlan,
       bool freePlan,
       bool premiumPlan,

       User user,
      string selectedTimeZoneId);
            public string Delete(int id);

            public List <Setting> GetAllSettings();
            public Setting GetSingleSetting(int id);
            public void UpdateSetting(int id, Setting setting);
        }
}
