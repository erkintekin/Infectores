using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;

namespace Backend.BusinessLayer.Abstract
{
    public interface IToolService
    {
        Task<Tool> CreateTool(Tool tool);
        Task<List<Tool>> GetAllTools();
        Task<Tool> GetToolById(int toolId);
        Task<bool> UpdateTool(Tool tool);
        Task<bool> DeleteTool(int toolId);
    }
}