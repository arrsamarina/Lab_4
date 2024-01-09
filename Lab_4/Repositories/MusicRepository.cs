﻿using Lab_4.DB;
using Lab_4.Models;
using Lab_4.Services;
using Microsoft.EntityFrameworkCore;

namespace Lab_4.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        private readonly MusicCatalogContext _dbContext;

        public MusicRepository(MusicCatalogContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Реализация метода из интерфейса
        public async Task<List<MusicModel>> GetAll()
        {
            if (_dbContext.Musics == null) return new List<MusicModel>();
            return await _dbContext.Musics.ToListAsync();
        }

        // Реализация метода из интерфейса
        public Task AddMusic(MusicModel music)
        {
            _dbContext.Musics.Add(music);
            return _dbContext.SaveChangesAsync();
        }

        // Реализация метода из интерфейса
        public async Task<List<MusicModel>> FindByPartOfName(string PartOfName)
        {
            var musics = await GetAll();
            return new List<MusicModel>(musics.Where(m => m.composition.Contains(PartOfName)));
        }

        // Реализация метода из интерфейса
        public Task DeleteMusic(string title)
        {
            var elements = title.Split("-");
            MusicModel music = _dbContext.Musics.FirstOrDefault(music => music.author == elements[0] && music.composition == elements[1]);
            _dbContext.Remove(music);
            return _dbContext.SaveChangesAsync();
        }
    }
}