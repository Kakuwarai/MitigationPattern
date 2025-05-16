using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mitigation.Models;
using Mitigation.UnitOfWork;

namespace Mitigation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidate(int id)
        {
            var candidate = await _unitOfWork.Candidates.GetCandidateById(id);
            if (candidate == null)
                return NotFound();

            return Ok(candidate);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCandidate(StoreItem StoreItem)
        {
            await _unitOfWork.Candidates.AddAsync(StoreItem);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetCandidate), new { id = StoreItem.Id }, StoreItem);
        }
    }
}
