using System.Collections.Generic;
using System.Linq;
using urlShortenerService.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace urlShortenerService.Services
{
    public class ShortUrlService
    {
        private readonly IMongoCollection<ShortUrl> _shortUrl;

        public ShortUrlService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("UrlShortenerDB"));
            var database = client.GetDatabase("UrlShortenerDB");
            _shortUrl = database.GetCollection<ShortUrl>("ShortUrls");
        }

        public List<ShortUrl> Get()
        {
            return _shortUrl.Find(shortUrl => true).ToList();
        }

        public ShortUrl Get(string url)
        {
            return _shortUrl.Find<ShortUrl>(shortUrl => shortUrl.Url == url).FirstOrDefault();
        }

        public ShortUrl Create(ShortUrl shortUrl)
        {
            // shortUrl.Url = GenerateShortUrl();
            _shortUrl.InsertOne(shortUrl);
            return shortUrl;
        }

        public void Update(string id, ShortUrl shortUrlIn)
        {
            _shortUrl.ReplaceOne(shortUrl => shortUrl.Id == id, shortUrlIn);
        }

        public void Remove(ShortUrl shortUrlIn)
        {
            _shortUrl.DeleteOne(shortUrl => shortUrl.Id == shortUrlIn.Id);
        }

        public void Remove(string id)
        {
            _shortUrl.DeleteOne(shortUrl => shortUrl.Id == id);
        }

        private string GenerateShortUrl() {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}