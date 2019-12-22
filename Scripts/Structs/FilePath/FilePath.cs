using System.IO;
namespace AsagiHandyScripts
{
    [System.Serializable]
    public struct FilePath
    {
        public string path;

        public FilePath(string _path)
        {
            path = _path;
        }

        public string FullPath()
        {
            return Path.GetFullPath(path);
        }

        public string Directory()
        {
            return Path.GetDirectoryName(path);
        }

        public string FileName()
        {
            return Path.GetFileName(path);
        }

        public string Extension()
        {
            return Path.GetExtension(path);
        }
    }
}