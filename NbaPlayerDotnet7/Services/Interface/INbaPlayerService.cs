using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaPlayerDotnet7.Services.Interface
{
    public interface INbaPlayerService
    {
        Task<List<NbaPlayer>> GetAllPlayers();
        Task<NbaPlayer?> GetSinglePlayer(int id);
        Task<List<NbaPlayer>> AddPlayer(NbaPlayer player);
        Task<List<NbaPlayer>?> UpdatePlayer(int id, NbaPlayer request);
        Task<List<NbaPlayer>?> DeletePlayer(int id);
    }
}