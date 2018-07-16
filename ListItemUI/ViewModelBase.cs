using System;
using System.Collections.Generic;

namespace ListItemUI
{
    public abstract class ViewModelBase : PropertyChangedNotifier, IDisposable
    {
        private readonly List<IDisposable> _disposables = new List<IDisposable>();

        protected bool IsDisposed { get; private set; }

        protected void AddDisposable(IDisposable disposable)
        {
            if (IsDisposed)
                return;
            if (!_disposables.Contains(disposable))
                _disposables.Add(disposable);
        }

        public void RemoveDisposable(IDisposable disposable)
        {
            if (IsDisposed)
                return;
            _disposables.Remove(disposable);
        }

        ~ViewModelBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (IsDisposed)
                return;

            if (disposing)
            {
                foreach (var disp in _disposables)
                    disp.Dispose();
                // Dispose di tutti gli oggetti di cui sono owner
                OnDisposeOwnedObject();
            }

            OnSetNullObjectReferences();

            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
            IsDisposed = true;
        }

        protected virtual void OnSetNullObjectReferences()
        {
        }

        protected virtual void OnDisposeOwnedObject()
        {

        }
    }
}