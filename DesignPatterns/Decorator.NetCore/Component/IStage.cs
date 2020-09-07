using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Decorator.NetCore.Component
{
    public interface IResult
    {
        int GetValue();
        string GetSummary();
    }

    public class Result : IResult
    {
        public int GetValue()
        {
            return 1;
        }

        public string GetSummary()
        {
            return "Simple Result";
        }
    }

    public interface IProjectSetting
    {
        bool TryGetConfig<TConfig>(string stageKind, string stageName, out TConfig config) where TConfig : class;
    }

    public interface IStageConfig
    {
        string StageKind { get; }
        string StageName { get; }
    }

    public interface IStageConfig<in TProjectSetting> : IStageConfig
        where TProjectSetting : IProjectSetting
    {
        void SetStageConfigBasedOnProjectSetting(string stageKind, string stageName, TProjectSetting projectSetting);
    }

    public class StageConfig : IStageConfig<IProjectSetting>
    {
        public string StageKind { get; set; }
        public string StageName { get; set; }

        public void SetStageConfigBasedOnProjectSetting(string stageKind, string stageName, IProjectSetting projectSetting)
        {
            if (projectSetting.TryGetConfig<IStageConfig>(stageKind, stageName, out var config) == false)
                return;

            StageKind = config.StageKind;
            StageName = config.StageName;
        }
    }

    public interface IConfigWithExecutionDate
    {
        DateTime T1Date { get; }
        DateTime T2Date { get; }
    }

    public class ConfigWithExecutionDate : StageConfigDecorator, IConfigWithExecutionDate
    {
        public DateTime T1Date { get; set; }
        public DateTime T2Date { get; set; }

        public ConfigWithExecutionDate(IStageConfig<IProjectSetting> stageConfig) 
            : base(stageConfig)
        {}

        public override void SetStageConfigBasedOnProjectSetting(string stageKind, string stageName, IProjectSetting projectSetting)
        {
            base.SetStageConfigBasedOnProjectSetting(stageKind, stageName, projectSetting);
            if (projectSetting.TryGetConfig<IConfigWithExecutionDate>(stageKind, stageName, out var config) == false)
                return;

            T1Date = config.T1Date;
            T2Date = config.T2Date;
        }
    }

    public abstract class StageConfigDecorator : IStageConfig<IProjectSetting>
    {
        private readonly IStageConfig<IProjectSetting> _stageConfig;

        public string StageKind => _stageConfig.StageKind;
        public string StageName => _stageConfig.StageName;

        protected StageConfigDecorator(IStageConfig<IProjectSetting> stageConfig)
        {
            _stageConfig = stageConfig;
        }

        public virtual void SetStageConfigBasedOnProjectSetting(string stageKind, string stageName, IProjectSetting projectSetting)
        {
            _stageConfig.SetStageConfigBasedOnProjectSetting(stageKind, stageName, projectSetting);
        }
    }

    /// <summary>
    /// Component IStage
    /// </summary>
    public interface IStage
    {
        List<string> SetSetting();
        IResult ExecuteStageAndReturnResult();
    }

    public class SimpleStage : IStage
    {
        List<IStageDecorator> _decorators = new List<IStageDecorator>();
        public void RegisterStageDecorators(params IStageDecorator[] decorators)
        {
            _decorators.AddRange(decorators);
        }

        public List<string> SetSetting()
        {
            return new List<string>{"Simple Stage"};
        }

        public IResult ExecuteStageAndReturnResult()
        {
            throw new System.NotImplementedException();
        }
    }

    public class ShowStageResult : IStageDecorator
    {
        private IStage _stageToDecorate;

        public List<string> SetSetting()
        {
            return StageToDecorate.SetSetting();
        }

        public IResult ExecuteStageAndReturnResult()
        {
            var result = StageToDecorate.ExecuteStageAndReturnResult();
            ShowResult(result);
            return result;
        }

        private void ShowResult(IResult result)
        {
            Console.WriteLine(result.GetSummary());
        }

        public void SetStageToDecorate(IStage stageToDecorate)
        {
            _stageToDecorate = stageToDecorate;
        }

        public IStage StageToDecorate => _stageToDecorate;
    }

    public class SaveStageResult : IStage
    {
        private IStage _stageToDecorate;

        public SaveStageResult(IStage stageToDecorate)
        {
            _stageToDecorate = stageToDecorate;
        }

        public List<string> SetSetting()
        {
            var settings = StageToDecorate.SetSetting();
            settings.Add("Stage result will be saved");
            return settings;
        }

        public IResult ExecuteStageAndReturnResult()
        {
            var result = StageToDecorate.ExecuteStageAndReturnResult();
            SaveResult(result.GetValue());
            return result;
        }

        private void SaveResult(int getValue)
        {
            // will save value
        }

        public void SetStageToDecorate(IStage stageToDecorate)
        {
            _stageToDecorate = stageToDecorate;
        }

        public IStage StageToDecorate => _stageToDecorate;
    }

    public interface IStageDecorator : IStage
    {
        void SetStageToDecorate(IStage stageToDecorate);
        IStage StageToDecorate { get; }
    }

    public class StageProcessor : IStage
    {
        List<IStage> _registeredStageComponents = new List<IStage>();

        public void RegisterStageComponents(params IStage[] stageComponents)
        {
            _registeredStageComponents.AddRange(stageComponents);
        }
        public List<string> SetSetting()
        {
            throw new System.NotImplementedException();
        }

        public IResult ExecuteStageAndReturnResult()
        {
            throw new System.NotImplementedException();
        }
    }
}