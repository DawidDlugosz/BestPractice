using System;
using Decorator.NetCore.Component;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Decorator.NetCore.Test
{
    public class WithExecutionDate : IStageConfig, IConfigWithExecutionDate
    {
        public WithExecutionDate(string name)
        {
            StageName = name;
        }

        public string StageKind => "TestStage";
        public string StageName { get; set; }
        public DateTime T1Date => DateTime.Now;
        public DateTime T2Date => DateTime.Now.AddDays(-1);
    }

    public class TestProjectStetting : IProjectSetting
    {
        public WithExecutionDate Collection => new WithExecutionDate("WithName");

        public bool TryGetConfig<TConfig>(string stageKind, string stageName, out TConfig config) where TConfig : class
        {
            config = Collection as TConfig;

            return config != null;
        }
    }

    [TestClass]
    public class StageConfigTest
    {
        [TestMethod]
        public void CreateStageConfig()
        {
            var config = new StageConfig();
            var decoratedConfig = new ConfigWithExecutionDate(config);

            decoratedConfig.SetStageConfigBasedOnProjectSetting("TestStage", "Test", new TestProjectStetting());
            Console.WriteLine(decoratedConfig.T1Date);
        }
    }
}