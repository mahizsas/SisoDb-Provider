﻿using System;

namespace SisoDb.Tests.IntegrationTests.Providers.SqlProvider.UnitOfWork.TestModel
{
    internal class TheBase
    {
        public Guid SisoId { get; set; }

        public string BaseString1 { get; set; }

        public int BaseInt1 { get; set; }
    }
}