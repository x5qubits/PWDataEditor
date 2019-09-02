using Gpckx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pck_Guy_View
{
    public class PackStructureManager
    {
        public FolderTreeModel root;
        public string fiullFilePath;
        public string Title;
        public PackStructureManager(String _Title)
        {
            Title = _Title;
            root = new FolderTreeModel() { Title = _Title, Rows = new List<FolderTreeModel>() };
        }

        public void addfille(PckEntry file)
        {
            Action<FolderTreeModel, IEnumerable<string>, PckEntry> ensureExists = null;
            ensureExists = (root, path, pckentry) =>
            {
                if (path.Any())
                {
                    var title = path.First().ToLower();
                    var child = root.Rows.Where(x => x.Title == title).SingleOrDefault();
                    if (child == null)
                    {
                        child = new FolderTreeModel()
                        {
                            Title = title,
                            Rows = new List<FolderTreeModel>(),
                        };
                        if (Path.HasExtension(title))
                        {
                            child.File = pckentry;
                        }
                        root.Rows.Add(child);
                    }
                    ensureExists(child, path.Skip(1), pckentry);
                }
            };
            string[] splitedPath = file.filePath.Split(Path.DirectorySeparatorChar);
            ensureExists(root, splitedPath, file);
        }

        public FolderTreeModel GetDirectory(string DirPath)
        {
            string[] splitedPath = DirPath.ToLower().Split(Path.DirectorySeparatorChar);
            FolderTreeModel last = null;
            for (int i =0; i < splitedPath.Length; i++)
            {
                string title = splitedPath[i];
                if(last == null)
                    last = root.Rows.Where(x => x.Title == title).SingleOrDefault();
                else
                    last = last.Rows.Where(x => x.Title == title).SingleOrDefault();
            }
            return last;
        }
    }
}
