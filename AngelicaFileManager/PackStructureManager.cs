using Gpckx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pck_Guy_View
{
    public class PackStructureManager
    {
        public FolderTreeModel root;
        public string fiullFilePath;
        public string Title;
        public PackStructureManager(string _Title)
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
                    var title = path.First();
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

        public List<PckEntry> getAllFIles(FolderTreeModel rootx)
        {
            if (root == null)
            {
                return new List<PckEntry>();
            }
            List<PckEntry> files = new List<PckEntry>();
            Action<FolderTreeModel> ensureExists = null;
            ensureExists = (root) =>
            {
                if (root.File != null)
                    files.Add(root.File);

                foreach (FolderTreeModel ftm in root.Rows)
                {
                    if (ftm.File != null)
                        files.Add(ftm.File);

                    if (ftm.Rows != null && ftm.Rows.Count > 0)
                        ensureExists(ftm);
                }
            };
            ensureExists(rootx);
            return files;
        }

        public List<FolderTreeModel> GetDirectory2(string DirPath)
        {
            if (root == null)
            {
                return new List<FolderTreeModel>();
            }
            string[] splitedPath = DirPath.ToLower().Split(Path.DirectorySeparatorChar);
            FolderTreeModel directory = null;
            Action<IEnumerable<string>, FolderTreeModel> getDirectory = null;
            getDirectory = (path, pckentry) =>
            {
                if (path.Any())
                {
                    var title = path.First().ToLower();
                    var child = pckentry.Rows.Where(x => x.Title.ToLower() == title).SingleOrDefault();
                    if (child != null && child.Title.ToLower() == path.Last().ToLower())
                    {
                        directory = child;
                    }
                    getDirectory(path.Skip(1), child);
                }
            };
            getDirectory(splitedPath, root);
            if(directory != null)
            {
                if(directory.Rows == null || directory.Rows != null && directory.Rows.Count == 0)
                    return new List<FolderTreeModel>();

                return directory.Rows.OrderBy(x=>x.File != null).ToList();
            }
            return new List<FolderTreeModel>();
        }
        public List<PckEntry> GetDirectory(string DirPath, bool isFileNameOnly = false, string fileName = "")
        {
            if(root == null)
            {
                return new List<PckEntry>();
            }
            string[] splitedPath = DirPath.ToLower().Split(Path.DirectorySeparatorChar);
            FolderTreeModel directory = null;
            List<PckEntry> files = null;
            Action<IEnumerable<string>, FolderTreeModel> getDirectory = null;
            getDirectory = (path, pckentry) =>
            {
                if (path.Any())
                {
                    var title = path.First().ToLower();
                    var child = pckentry.Rows.Where(x => x.Title.ToLower() == title).FirstOrDefault();
                    if (child != null && child.Title.ToLower() == path.Last().ToLower())
                    {
                        directory = child;
                    }
                    if(child != null)
                        getDirectory(path.Skip(1), child);
                }
            };
            getDirectory(splitedPath, root);
            if(directory != null)
            {
                if (!isFileNameOnly)
                {
                    files = new List<PckEntry>();
                    Action<FolderTreeModel> ensureExists = null;
                    ensureExists = (root) =>
                    {
                        if (root.File != null)
                            files.Add(root.File);

                        foreach (FolderTreeModel ftm in root.Rows)
                        {
                            if (ftm.File != null)
                                files.Add(ftm.File);

                            if (ftm.Rows != null && ftm.Rows.Count > 0)
                                ensureExists(ftm);
                        }
                    };
                    ensureExists(directory);
                }
                else
                {
                    files = new List<PckEntry>();
                    Action<FolderTreeModel> ensureExists = null;
                    ensureExists = (root) =>
                    {
                        if (root.File != null && root.Title.ToLower().Equals(fileName.ToLower()))
                            files.Add(root.File);

                        foreach (FolderTreeModel ftm in root.Rows)
                        {
                            if (ftm.File != null && ftm.Title.ToLower().Equals(fileName.ToLower()))
                                files.Add(ftm.File);

                            if (ftm.Rows != null && ftm.Rows.Count > 0)
                                ensureExists(ftm);
                        }
                    };
                    ensureExists(directory);
                }
            }
            if(files == null)
                return new List<PckEntry>();

            return files;
        }
    }
}
