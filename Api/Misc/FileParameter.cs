namespace ChasterSharp
{

    public sealed class FileParameter
    {
        public byte[] Data { get; private set; }
        public string? FileName { get; private set; }
        public string? ContentType { get; private set; }

        public FileParameter(byte[] data, string? fileName = null, string? contentType = null)
        {
            Data = data;
            FileName = fileName;
            ContentType = contentType;
        }
    }
}