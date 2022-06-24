using HashidsNet;

namespace Storage.Services
{
    public class FilesService : IFilesService
    {
        private readonly Hashids _fileIdProvider = new("1234567", 7);

        public async Task<byte[]> GetFileAsync(string fileId, CancellationToken cancellationToken)
        {
            var fileSize = _fileIdProvider.DecodeSingle(fileId);

            await Task.Delay(fileSize / 553, cancellationToken);

            var result = new byte[fileSize];
            Random.Shared.NextBytes(result);

            return result;
        }

        public async Task<bool> FileExistsAsync(string fileId, CancellationToken cancellationToken)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(53), cancellationToken);

            if (_fileIdProvider.TryDecodeSingle(fileId, out int rawFileId))
            {
                return rawFileId % 23 > 5;
            }

            return false;
        }
    }
}
