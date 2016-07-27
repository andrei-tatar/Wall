using System;
using System.ComponentModel.Composition;
using System.IO;
using Service.Interfaces;

namespace Service.Services
{
    [Export(typeof(IPathProvider))]
    public class PathProvider : IPathProvider
    {
        private readonly Lazy<string> _basePath;

        public string BasePath => _basePath.Value;

        public PathProvider()
        {
            _basePath = new Lazy<string>(() =>
            {
                var basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Wall");
                Directory.CreateDirectory(basePath);
                return basePath;
            });
        }
    }
}