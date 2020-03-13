using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using TourAgency.Bll.DTO;
using TourAgency.Bll.Helpers;
using TourAgency.Bll.Infrastructure;
using TourAgency.Bll.Services.Interfaces;
using TourAgency.Dal.UnitOfWork.Interfaces;

namespace TourAgency.Bll.Services
{
    public class AdminService : ManagerService, IAdminService
    {

        private readonly IUnitOfWork _dataBase;
        public AdminService(IUnitOfWork dataBase) : base(dataBase)
        {
            Log.Information("The time is {Now}", DateTime.Now); 
            _dataBase = dataBase;
        }
        public void RegisterManager(ManagerDTO managerDTO)
        {
            var manager = MappingDTO.MapManager(managerDTO);
            _dataBase.Managers.Register(manager);
            _dataBase.Save();
        }
        public void DeleteTour(int id)
        {
            var tour = _dataBase.Tours.Get(id);
            if (tour != null)
            {
                tour.IsDelete = true;
                _dataBase.Tours.Update(tour);
            }
            else
                throw new ValidationException("Failed to remove tour", "null error");
            _dataBase.Save();
        }
        public void CreateTour(TourDTO tourDTO)
        {
            var tour = MappingDTO.MapTour(tourDTO);
            _dataBase.Tours.Create(tour);
            _dataBase.Save();
            // throw new ValidationException("Failed to create tour", "null error");
        }
        public List<ManagerDTO> GetAllManagers()
        {
            var managers = _dataBase.Managers.GetAll();
            var managersDto = MappingDTO.MapManagerListDTO(managers.ToList());
            return managersDto;
        }

        public ManagerDTO GetManagerById(int id)
        {
            var manager = _dataBase.Managers.Get(id);
            var managerDto = MappingDTO.MapManagerDTO(manager);
            return managerDto;
        }

        public void BlockManager(int id)
        {
            var manager = _dataBase.Managers.Get(id);
            if (manager != null)
            {
                manager.IsBlock = true;
                _dataBase.Managers.Update(manager);
            }
            else
                throw new ValidationException("Failed to block manager", "null error");
            _dataBase.Save();
        }

        public void UnlockManager(int id)
        {
            var manager = _dataBase.Managers.Get(id);
            if (manager != null)
            {
                manager.IsBlock = false;
                _dataBase.Managers.Update(manager);
            }
            else
                throw new ValidationException("Failed to block manager", "null error");
            _dataBase.Save();
        }
    }
}
