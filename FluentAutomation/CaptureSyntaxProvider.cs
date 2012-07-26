using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using FluentAutomation.Interfaces;

namespace FluentAutomation
{
    /// <summary>
    /// Capture content from the UI to allow feedback into automation.
    /// Incompatible with record and replay.
    /// </summary>
    public class CaptureSyntaxProvider
    {
        private readonly ICaptureProvider captureProvider;

        public CaptureSyntaxProvider(ICaptureProvider captureProvider)
        {
            this.captureProvider = captureProvider;
        }

        public IEnumerable<string> Classes(string selector)
        {
            return captureProvider.CssClasses(selector);
        }

        public string Text(string selector)
        {
            return captureProvider.Text(selector);
        }

        public IEnumerable<string> SelectText(string selector)
        {
            return captureProvider.SelectText(selector);
        }

        public IEnumerable<string> Value(string selector)
        {
            return captureProvider.Value(selector);
        }

        public Uri Url()
        {
            return captureProvider.Url();
        }
    }
}
