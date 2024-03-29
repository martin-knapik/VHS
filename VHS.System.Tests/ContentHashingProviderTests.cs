﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using VHS.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using VHS.System.FilesystemLayer;
using VHS.System.HashingProvider;
using VHS.System.HashingProvider.HashImplementations;

namespace VHS.System.Tests
{
    [TestClass()]
    public class ContentHashingProviderTests
    {
        [TestMethod()]
        public void HashContentShouldReturnHashedFileContent()
        {
            var hashProviderMock = new Mock<IHashImplementation>();
            hashProviderMock.Setup(m => m.HashBytes(It.IsAny<byte[]>())).Returns("123");
            var _fsl = new Mock<IFilesystemLayer>();
            var chp = new ContentHashingProvider(_fsl.Object, hashProviderMock.Object);

            var result = chp.GetContentOfFileAndHashIt("dummyPath");

            Assert.AreEqual("123", result);
        }
    }
}