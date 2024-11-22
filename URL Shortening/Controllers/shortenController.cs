using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using URL_Shortening.Data;
using URL_Shortening.DTOs;
using URL_Shortening.Helpers;
using URL_Shortening.Models;

namespace URL_Shortening.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class shortenController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public shortenController(AppDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShortUrl([FromBody] UrlFromUserDto url)
        {
            if(!UrlValidation.isValidURL(url.url))
            {
                return BadRequest("URL Not Valid.");
            }

            string shortCode;
            do
            {
                shortCode = Guid.NewGuid().ToString("N").Substring(0, 6);
            } while (await _context.ShortUrls.AnyAsync(s => s.ShortCode == shortCode));

            var shortUrl = new ShortUrl
            {
                OriginalUrl = url.url,
                ShortCode = shortCode
            };
            _context.ShortUrls.Add(shortUrl);
            await _context.SaveChangesAsync();
            var urlDto = _mapper.Map<UrlDto>(shortUrl);

            return CreatedAtAction(nameof(GetOriginalUrl), new { shortCode = urlDto.ShortCode }, urlDto);
        }



        [HttpGet("{shortCode}")]
        public async Task<IActionResult> GetOriginalUrl(string shortCode)
        {
            var shortUrl = await _context.ShortUrls.FirstOrDefaultAsync(s => s.ShortCode == shortCode);
            if (shortUrl != null)
            {
                shortUrl.AccessCount++;
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            var urlDto = _mapper.Map<UrlDto>(shortUrl);
            return Ok(urlDto);

        }

        [HttpPut("{shortCode}")]
        public async Task<IActionResult> UpdateShortUrl(string shortCode, [FromBody] UrlFromUserDto newUrl)
        {
            if (!UrlValidation.isValidURL(newUrl.url))
            {
                return BadRequest("URL Not Valid.");
            }

            var shortUrl = await _context.ShortUrls.FirstOrDefaultAsync(s => s.ShortCode == shortCode);
            if (shortUrl == null)
                return NotFound();

            shortUrl.OriginalUrl = newUrl.url;
            shortUrl.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            var urlDto = _mapper.Map<UrlDto>(shortUrl);
            return Ok(urlDto);
        }

        [HttpDelete("{shortCode}")]
        public async Task<IActionResult> DeleteShortUrl(string shortCode)
        {
            var shortUrl = await _context.ShortUrls.FirstOrDefaultAsync(s => s.ShortCode == shortCode);
            if (shortUrl == null)
                return NotFound();

            _context.ShortUrls.Remove(shortUrl);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("{shortCode}/stats")]
        public async Task<IActionResult> GetUrlStats(string shortCode)
        {
            var shortUrl = await _context.ShortUrls.FirstOrDefaultAsync(s => s.ShortCode == shortCode);
            if (shortUrl == null)
                return NotFound();

            var urlDto = _mapper.Map<UrlStatsDto>(shortUrl);
            return Ok(urlDto);
        }

    }
}
