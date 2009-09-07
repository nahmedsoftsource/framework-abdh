using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace Superior.Data.NHibernateClient
{
    public class LinqProjectionResultTransformer : NHibernate.Transform.IResultTransformer
    {
        Type type;
        MemberBinding[] bindings;

        public LinqProjectionResultTransformer(Type type, MemberBinding[] bindings)
        {
            this.type = type;
            this.bindings = bindings;
        }

        public System.Collections.IList TransformList(System.Collections.IList collection)
        {
            return collection;
        }

        public object TransformTuple(object[] tuple, string[] aliases)
        {
            object instance = Activator.CreateInstance(type);
            for (int i = 0; i < bindings.Length; i++)
            {
                SetValue(bindings[i].Member, instance, tuple[i]);
            }
            return instance;
        }

        private void SetValue(System.Reflection.MemberInfo memberInfo, object instance, object valueToSet)
        {
            FieldInfo field = memberInfo as FieldInfo;
            if (field != null)
            {
                field.SetValue(instance, valueToSet);
            }
            ((PropertyInfo)memberInfo).SetValue(instance, valueToSet, null);
        }
    }

}
