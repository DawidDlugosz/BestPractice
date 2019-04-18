using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternTest.Creational
{
    public interface ILoggerService
    {
        void LogError(string errorMessage);
        void LogWarning(string warningMessage);
    }

    public interface IMailingService
    {
        void SendEmail(string topic, string emailContent);
    }

    public interface IBusiness
    {
        void DoSomething();
    }

    public interface IBusinessSource
    {
        void DoSomethingMore();
    }

    public class BusinessSource : IBusinessSource
    {
        public BusinessSource(IMailingService mailing, ILoggerService logger)
        {
            _mailing = mailing;
            _logger = logger;
        }
        private IMailingService _mailing;
        private ILoggerService _logger;

        public void DoSomethingMore()
        {
            try
            {

            }
            catch(Exception exc)
            {
                _logger.LogError(exc.Message);
                _mailing.SendEmail("Error", exc.Message);
            }
        }
    }

    public class Business : IBusiness
    {
        public Business(ILoggerService logger, IBusinessSource source)
        {
            _logger = logger;
            _source = source;
        }

        ILoggerService _logger;
        private IBusinessSource _source;

        public void DoSomething()
        {
            try
            {
                _source.DoSomethingMore();
                throw new NotImplementedException();
            }
            catch(Exception exc)
            {
                _logger.LogError(exc.Message);
            }
        }
    }

    public class Root
    {
        IMailingService Mailing { get; set; }
        ILoggerService Logger { get; set; }
        IBusiness Business { get; set; }

        public void Execute()
        {
            try
            {
                Business.DoSomething();
            }
            catch(Exception exc)
            {
                Logger.LogError(exc.Message);
            }
        }
    }
}
