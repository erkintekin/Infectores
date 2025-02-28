using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;

namespace Backend.BusinessLayer.Abstract
{
    public interface ISenseService
    {
        Task<Sense> CreateSense(Sense sense);
        Task<List<Sense>> GetAllSenses();
        Task<Sense> GetSenseById(int senseId);
        Task<bool> UpdateSense(Sense sense);
        Task<bool> DeleteSense(int senseId);
    }
}