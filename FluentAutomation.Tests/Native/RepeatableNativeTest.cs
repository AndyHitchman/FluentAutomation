using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FluentAutomation.Tests
{
    public class RepeatableNativeTest : IDisposable
    {
        private Lazy<InteractiveNative> interactiveFactory = new Lazy<InteractiveNative>(() => new InteractiveNative());
        protected InteractiveNative interactive { get { return interactiveFactory.Value; } }

        private Lazy<FormsNative> formsFactory = new Lazy<FormsNative>(() => new FormsNative());
        protected FormsNative forms { get { return formsFactory.Value; } }

        private Lazy<CaptureNative> captureFactory = new Lazy<CaptureNative>(() => new CaptureNative());
        protected CaptureNative capture { get { return captureFactory.Value; } }

        public void Dispose()
        {
            try
            {
                this.interactive.Dispose();
                this.forms.Dispose();
                this.capture.Dispose();
            }
            catch (Exception) { }
        }
    }
}
