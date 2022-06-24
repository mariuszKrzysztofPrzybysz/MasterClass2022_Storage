using Microsoft.AspNetCore.Mvc;
using Storage.Services;

namespace Storage.Controllers
{
    [Route("api/files/v1")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesService _service;

        public FilesController(IFilesService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{fileId}/content")]
        public async Task<IActionResult> DownloadFileAsync(string? fileId, CancellationToken cancellationToken)
        {
            if (await _service.FileExistsAsync(fileId!, cancellationToken))
            {
                return File(await _service.GetFileAsync(fileId!, cancellationToken), "application/octet-stream", fileId);
            }

            return NotFound();
        }
    }
}
