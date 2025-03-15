using System.IO;

namespace Unvurn.Unity.IO
{
    public static class FileUtils
    {
        public static byte[] ReadAll(string filename)
        {
            var fileInfo = new FileInfo(filename);
            var stream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var buf = new byte[stream.Length];
            _ = stream.Read(buf, 0, buf.Length);

            return buf;
        }
    }
}
