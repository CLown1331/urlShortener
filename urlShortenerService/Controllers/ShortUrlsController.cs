using System.Collections.Generic;
using urlShortenerService.Models;
using urlShortenerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace urlShortenerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUrlsController : ControllerBase
    {
        private readonly ShortUrlService _shortUrlService;

        public ShortUrlsController(ShortUrlService shortUrlService)
        {
            _shortUrlService = shortUrlService;
        }

        [HttpGet]
        public ActionResult<List<ShortUrl>> Get()
        {
            return _shortUrlService.Get();
        }

        [HttpGet("{url}", Name="GetShortUrl")]
        public ActionResult<ShortUrl> Get(string url)
        {
            var shortUrl = _shortUrlService.Get(url);

            if (shortUrl == null)
            {
                return NotFound();
            }

            return shortUrl;
        }

        [HttpPost]
        public ActionResult<ShortUrl> Create(ShortUrl shortUrl)
        {
            _shortUrlService.Create(shortUrl);

            return CreatedAtRoute("GetShortUrl", new { url = shortUrl.Url.ToString() }, shortUrl);
        }

        [HttpPut("{url}")]
        public IActionResult Update(string url, ShortUrl shortUrlIn)
        {
            var shortUrl = _shortUrlService.Get(url);

            if (shortUrl == null)
            {
                return NotFound();
            }

            _shortUrlService.Update(shortUrl.Id, shortUrlIn);

            return NoContent();
        }

        [HttpDelete("{url}")]
        public IActionResult Delete(string url)
        {
            var shortUrl = _shortUrlService.Get(url);

            if (shortUrl == null)
            {
                return NotFound();
            }

            _shortUrlService.Remove(shortUrl.Id);

            return NoContent();
        }
    }
}