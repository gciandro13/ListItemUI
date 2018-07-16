using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ListItemUI
{
    public abstract class PropertyChangedNotifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Scatena PropertyChanged passando il nome della proprietà da cui è chiamato.
        /// </summary>
        /// <param name="propertyName">Lasciare vuoto (perché definito come CallerMemberName)</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            RaisePropertyChangedInternal(propertyName);
        }

        /// <summary>
        /// Scatena PropertyChanged passando il nome della proprietà specificata. Usare quando si vuole
        /// fare raise per la proprietà B dal setter della proprietà A (altrimenti, chiamare RaiseCurrentPropertyChanged).
        /// </summary>
        protected void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
            string propertyName = ExtractPropertyName(propertyExpression);
            RaisePropertyChangedInternal(propertyName);
        }

        /// <summary>
        /// Preferire l'uso di Set(...)
        /// </summary>
        private void RaisePropertyChangedInternal(string propertyName)
        {
            var h = PropertyChanged;
            if (h != null)
                h(this, new PropertyChangedEventArgs(propertyName));
        }

        private static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            var memberExpression = (MemberExpression)propertyExpression.Body;
            return memberExpression.Member.Name;
        }

        /// <summary>
        /// Notifica i listener che l'oggetto corrente è cambiato quasi completamente, e che vanno rilette tutte
        /// le sue property.
        /// </summary>
        /// <see cref="http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged.propertychanged(v=vs.110).aspx"/>
        protected void RaiseAllPropertiesChanged()
        {
            RaisePropertyChangedInternal(string.Empty);
        }

        /// <param name="backingField">Il backing field della property.</param>
        /// <param name="value">Il nuovo valore da assegnare</param>
        /// <param name="propertyName">Lasciare vuoto (perché definito come CallerMemberName)</param>
        /// <returns>True se il valore è cambiato (ed è stato scatenato PropertyChanged), altrimenti false.</returns>
        protected bool Set<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            return SetInternal(ref backingField, value, propertyName);
        }

        private bool SetInternal<T>(ref T field, T value, string propertyName)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                RaisePropertyChangedInternal(propertyName);

                return true;
            }

            return false;
        }
    }
}