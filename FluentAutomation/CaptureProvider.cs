using System;
using System.Collections.Generic;
using FluentAutomation.Exceptions;
using FluentAutomation.Interfaces;

namespace FluentAutomation
{
    public class CaptureProvider : ICaptureProvider
    {
        private readonly ICommandProvider commandProvider = null;

        public CaptureProvider(ICommandProvider commandProvider)
        {
            this.commandProvider = commandProvider;
        }

        public IEnumerable<string> CssClasses(string selector)
        {
            var unwrappedElement = this.commandProvider.Find(selector)();
            return unwrappedElement.Attributes.Get("class").Split(' ');
        }

        public string Text(string selector)
        {
            var unwrappedElement = this.commandProvider.Find(selector)();

            return string.Join(" ", unwrappedElement.Text.Split(new[]{" ", "\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries));
        }

        public IEnumerable<string> SelectText(string selector)
        {
            var unwrappedElement = this.commandProvider.Find(selector)();

            if (unwrappedElement.IsSelect && unwrappedElement.IsMultipleSelect)
            {
                return unwrappedElement.SelectedOptionTextCollection;
            }

            return new[] { unwrappedElement.Text };
        }

        public IEnumerable<string> Value(string selector)
        {
            var unwrappedElement = this.commandProvider.Find(selector)();

            if (unwrappedElement.IsSelect && unwrappedElement.IsMultipleSelect)
            {
                return unwrappedElement.SelectedOptionValues;
            }

            return new[] { unwrappedElement.Value };
        }

        public Uri Url()
        {
            return this.commandProvider.Url;
        }
    }
}