using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Wox.Plugin.Common.Settings
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var memberExpr = propertyExpression.Body as MemberExpression;
            if (memberExpr == null)
                throw new ArgumentException("propertyExpression should represent access to a member");
            string memberName = memberExpr.Member.Name;
            RaisePropertyChanged(memberName);
        }

        protected void RaisePropertyChanged(/*[CallerMemberName] NOTE: Ne fonctionne qu'à partir du 4.5 et Wox ne supporte que le 3.5*/
            string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException("propertyName", "propertyName is null");

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
