using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sirenix.OdinInspector;
using UnityEngine;
using Yuumix.OdinToolkits.Core;
using Yuumix.OdinToolkits.Editor.Shared;

namespace Yuumix.OdinToolkits.Editor
{
    public class FolderTreeGen : OdinEditorScriptableSingleton<FolderTreeGen>, IOdinToolkitsReset
    {
        public static string[] ContainsFile =
        {
            "CHANGELOG.md"
        };

        [FolderPath(RequireExistingPath = true)]
        public string folderPath;

        public int maxDepth;

        [TextArea(10, 20)]
        [LabelText("结果")]
        public string resultText;

        public void OdinToolkitsReset()
        {
            folderPath = "Assets";
            maxDepth = 0;
            resultText = "";
        }

        [Button]
        public void Analyze()
        {
            if (!Directory.Exists(folderPath))
            {
                Debug.LogError("路径不存在");
                return;
            }

            var dir = new DirectoryInfo(folderPath);
            DirectoryClass root = CreateDirectoryClass(dir, 0);
            GenerateTreeView(root);
        }

        DirectoryClass CreateDirectoryClass(DirectoryInfo directoryInfo, int depth)
        {
            var dirClass = new DirectoryClass
            {
                Directory = directoryInfo
            };

            // 递归处理子目录
            if (depth < maxDepth)
            {
                foreach (DirectoryInfo subDir in directoryInfo.GetDirectories())
                {
                    DirectoryClass subDirClass = CreateDirectoryClass(subDir, depth + 1);
                    dirClass.SubDirectories.Add(subDirClass);
                }
            }

            // 处理文件
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                if (Array.IndexOf(ContainsFile, file.Name) >= 0)
                {
                    dirClass.SubFiles.Add(new FileClass
                    {
                        File = file,
                        Name = file.Name
                    });
                }
            }

            return dirClass;
        }

        void GenerateTreeView(DirectoryClass directory, int indentLevel = 0)
        {
            var sb = new StringBuilder();

            // 使用递归生成树形结构文本
            GenerateTreeRecursive(directory, sb, indentLevel);

            resultText = sb.ToString();
        }

        static void GenerateTreeRecursive(DirectoryClass directory, StringBuilder sb, int indentLevel)
        {
            // 添加当前目录
            string indent = GetIndentation(indentLevel);
            string dirName = directory.Directory.Name + "/";

            if (indentLevel > 0)
            {
                sb.AppendLine(indent + "├─ " + dirName);
            }
            else
            {
                sb.AppendLine(dirName);
            }

            // 添加子目录
            foreach (DirectoryClass subDir in directory.SubDirectories)
            {
                GenerateTreeRecursive(subDir, sb, indentLevel + 1);
            }

            // 添加文件
            foreach (FileClass file in directory.SubFiles)
            {
                string fileIndent = GetIndentation(indentLevel + 1);
                sb.AppendLine(fileIndent + "├─ " + file.Name);
            }
        }

        static string GetIndentation(int level)
        {
            var indent = "";
            for (var i = 0; i < level; i++)
            {
                indent += "│  ";
            }

            return indent;
        }

        internal class DirectoryClass
        {
            public readonly List<DirectoryClass> SubDirectories = new List<DirectoryClass>();
            public readonly List<FileClass> SubFiles = new List<FileClass>();
            public DirectoryInfo Directory;
        }

        internal class FileClass
        {
            public string Name;
            public FileInfo File;
        }
    }
}
