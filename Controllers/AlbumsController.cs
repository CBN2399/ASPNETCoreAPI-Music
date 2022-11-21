#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyect.Data;
using ApiProyect.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiProyect.Controllers
{
    //[Authorize]
    [Route("/")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly ChinookContext _context;

        public AlbumsController(ChinookContext context)
        {
            _context = context;
        }

        // GET: api/Albums
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await _context.Albums
                .Include(e => e.Artist)
                .Include(e => e.Tracks)
                .OrderByDescending(e => e.Title)
                .Take(10)
                .ToListAsync();
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await _context.Albums.Include(a => a.Artist).Include(a=> a.Tracks).FirstOrDefaultAsync(a => a.AlbumId == id);
           
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutAlbum(int id, Album album)
        {
            if (!AlbumExists(id))
            {
                return NotFound("El album no se encuentra en la base de datos");
            }

            if (ModelState.IsValid) 
            {
                var artistas = await _context.Artists.ToListAsync();
                Artist artist = artistas.Find(e => e.Name == album.Artist.Name);
                if (artist == null)
                {
                    return BadRequest("El artista no se encuentra en la base de datos");
                }

                try
                {
                    album.AlbumId = id;
                    album.ArtistId = artist.ArtistId;
                    album.Artist = artist;
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return BadRequest("El album editado es invalido");
        }

        // POST: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PostAlbum(Album album)
        {
            if (ModelState.IsValid)
            {
                var artistas = await _context.Artists.ToListAsync();
                Artist artist = artistas.Find(e => e.Name == album.Artist.Name);
                if (artist == null)
                {
                    return BadRequest("El artista no se encuentra en la base de datos");
                }

                album.Artist = artist;
                album.ArtistId = artist.ArtistId;
                _context.Albums.Add(album);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetAlbum", new { id = album.AlbumId }, album);
            }
            return BadRequest();
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
      //  [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }
    }
}
