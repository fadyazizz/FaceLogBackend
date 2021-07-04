using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using faceDetectionBackend.Models;

namespace faceDetectionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceLogsController : ControllerBase
    {
        private readonly FaceLogContext _context;

        public FaceLogsController(FaceLogContext context)
        {
            _context = context;
        }

        // GET: api/FaceLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FaceLog>>> GetFaceLog()
        {
            return await _context.FaceLog.ToListAsync();
        }

        // GET: api/FaceLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FaceLog>> GetFaceLog(int id)
        {
            var faceLog = await _context.FaceLog.FindAsync(id);

            if (faceLog == null)
            {
                return NotFound();
            }

            return faceLog;
        }

        // PUT: api/FaceLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaceLog(int id, FaceLog faceLog)
        {
            
            if (id != faceLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(faceLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaceLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FaceLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FaceLog>> PostFaceLog(FaceLog faceLog)
        {
            _context.FaceLog.Add(faceLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFaceLog", new { id = faceLog.Id }, faceLog);
        }

        // DELETE: api/FaceLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FaceLog>> DeleteFaceLog(int id)
        {
            var faceLog = await _context.FaceLog.FindAsync(id);
            if (faceLog == null)
            {
                return NotFound();
            }

            _context.FaceLog.Remove(faceLog);
            await _context.SaveChangesAsync();

            return faceLog;
        }

        private bool FaceLogExists(int id)
        {
            return _context.FaceLog.Any(e => e.Id == id);
        }
    }
}
