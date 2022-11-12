using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NbaPlayerDotnet7.Data;
using NbaPlayerDotnet7.Services.Interface;

namespace NbaPlayerDotnet7.Services
{
    public class NbaPlayerService : INbaPlayerService
    {
        private readonly DataContext _context;

        public NbaPlayerService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<NbaPlayer>> AddPlayer(NbaPlayer nbaPlayer)
        {
            _context.NbaPlayers.Add(nbaPlayer);
            await _context.SaveChangesAsync();
            return await _context.NbaPlayers.ToListAsync();
        }

        public async Task<List<NbaPlayer>?> DeletePlayer(int id)
        {
            var nbaPlayer = await _context.NbaPlayers.FindAsync(id);
            if (nbaPlayer is null)
                return null;

            _context.NbaPlayers.Remove(nbaPlayer);
            await _context.SaveChangesAsync();

            return await _context.NbaPlayers.ToListAsync();
        }

        public async Task<List<NbaPlayer>> GetAllPlayers()
        {
            var players = await _context.NbaPlayers.ToListAsync();
            return players;
        }

        public async Task<NbaPlayer?> GetSinglePlayer(int id)
        {
            var nbaPlayer = await _context.NbaPlayers.FindAsync(id);
            if (nbaPlayer is null)
                return null;

            return nbaPlayer;
        }

        public async Task<List<NbaPlayer>?> UpdatePlayer(int id, NbaPlayer request)
        {
            var nbaPlayer = await _context.NbaPlayers.FindAsync(id);
            if (nbaPlayer is null)
                return null;

            nbaPlayer.FirstName = request.FirstName;
            nbaPlayer.LastName = request.LastName;
            nbaPlayer.Team = request.Team;

            await _context.SaveChangesAsync();

            return await _context.NbaPlayers.ToListAsync();
        }
    }
}