using System;
using Grpc.Core.Logging;

namespace Tripod.Framework.Common
{
    public class GrpcLogger : ILogger
    {
        private void UnifyOutput(string format, params object[] formatArgs)
        {
            Console.WriteLine(string.Format(format,formatArgs));
        }

        public void Debug(string message)
        {
            this.UnifyOutput(message);
        }

        public void Debug(string format, params object[] formatArgs)
        {
            this.UnifyOutput(format, formatArgs);
        }

        public void Error(string message)
        {
            this.UnifyOutput(message);
        }

        public void Error(string format, params object[] formatArgs)
        {
            this.UnifyOutput(format, formatArgs);
        }

        public void Error(Exception exception, string message)
        {
            this.UnifyOutput(exception.Message);
        }

        public ILogger ForType<T>()
        {
            return this;
        }

        public void Info(string message)
        {
            this.UnifyOutput(message);
        }

        public void Info(string format, params object[] formatArgs)
        {
            this.UnifyOutput(format, formatArgs);
        }

        public void Warning(string message)
        {
            this.UnifyOutput(message);
        }

        public void Warning(string format, params object[] formatArgs)
        {
            this.UnifyOutput(format, formatArgs);
        }

        public void Warning(Exception exception, string message)
        {
            this.UnifyOutput(exception.Message);
            this.UnifyOutput(exception.StackTrace);
        }
    }
}