﻿using System.Collections.Generic;
using TourAgency.Bll.DTO;

namespace TourAgency.Bll.Services.Interfaces
{
    public interface IAdminService : IManagerService
    {
        void RegisterManager(ManagerDTO model);
        void CreateTour(TourDTO model);
        void DeleteTour(int id);
        List<ManagerDTO> GetAllManagers();
        ManagerDTO GetManagerById(int id);
        void BlockManager(int id);
        void UnlockManager(int id);
    }
}