using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Orchard.Environment;
using Orchard.Events;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.UI.Notify;

namespace Orchard.Exceptions {
    public class DefaultExceptionPolicy : IExceptionPolicy {
        private readonly INotifier _notifier;

        public DefaultExceptionPolicy() {
            Logger = NullLogger.Instance;
            T = NullLocalizer.Instance;
        }

        public DefaultExceptionPolicy(INotifier notifier) {
            _notifier = notifier;
           
            Logger = NullLogger.Instance;
            T = NullLocalizer.Instance;
        }

        public ILogger Logger { get; set; }
        public Localizer T { get; set; }

        public bool HandleException(object sender, Exception exception) {
            if (IsFatal(exception)) {
                return false;
            }

            if (sender is IEventBus &&  exception is OrchardFatalException) {
                return false;
            }

            Logger.Error(exception, "An unexpected exception was caught");

            do {
                RaiseNotification(exception);
                exception = exception.InnerException;
            } while (exception != null);

            return true;
        }

        private static bool IsFatal(Exception exception) {
            return 
                exception is StackOverflowException ||
                exception is AccessViolationException ||
                exception is AppDomainUnloadedException ||
                exception is ThreadAbortException ||
                exception is SecurityException ||
                exception is SEHException;
        }

        private void RaiseNotification(Exception exception) {
            if (_notifier == null) {
                return;
            }
            if (exception is OrchardException) {
                _notifier.Error((exception as OrchardException).LocalizedMessage);
            }
        }
    }
}
