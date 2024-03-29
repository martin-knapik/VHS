﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VHS.System.FilesystemLayer.ExceptionHandlerWrappers;
using VHS.System.FilesystemLayer.Exceptions;

namespace VHS.System.FilesystemLayer
{
    public class FilesystemLayer : IFilesystemLayer
    {
        private readonly FilesystemExceptionHandlerWrapper _fslExceptionHandlerWrapper =
            new FilesystemExceptionHandlerWrapper();


        public List<string> GetAllFilesInDirectory(string directoryName)
        {
            CheckIfFilenameIsNullOrEmpty(directoryName);
            var files = _fslExceptionHandlerWrapper.HandleExceptions(() => Directory.GetFiles(directoryName));
            return files?.ToList() ?? new List<string>();
        }

        public List<string> GetAllSubdirectoriesInDirectory(string directoryName)
        {
            CheckIfFilenameIsNullOrEmpty(directoryName);
            var subdirectories =
                _fslExceptionHandlerWrapper.HandleExceptions(() => Directory.GetDirectories(directoryName));
            return subdirectories?.ToList() ?? new List<string>();
        }

        public byte[] GetByteContentsOfFile(string fileName)
        {
            CheckIfFilenameIsNullOrEmpty(fileName);
            return _fslExceptionHandlerWrapper.HandleExceptions(() => File.ReadAllBytes(fileName));
        }

        public string[] GetStringLinesOfFile(string fileName)
        {
            CheckIfFilenameIsNullOrEmpty(fileName);
            return _fslExceptionHandlerWrapper.HandleExceptions(() => File.ReadAllLines(fileName));
        }

        public void WriteFile(List<string> lines, string fileName)
        {
            CheckIfFilenameIsNullOrEmpty(fileName);
            _fslExceptionHandlerWrapper.HandleExceptions<bool>(() =>
            {
                File.WriteAllLines(fileName, lines);
                return true;
            });
        }

        private void CheckIfFilenameIsNullOrEmpty(string directoryName)
        {
            if (string.IsNullOrEmpty(directoryName))
            {
                throw new CommonFileSystemLayerException(CommonFileSystemLayerException.FSLExceptionType.IncorrectName);
            }
        }
    }
}