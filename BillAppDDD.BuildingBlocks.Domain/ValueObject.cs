﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BillAppDDD.BuildingBlocks.Domain
{
    public abstract class ValueObject:IEquatable<ValueObject>
    {
        private List<PropertyInfo> properties;
        private List<FieldInfo> fields;

        public static bool operator ==(ValueObject obj1, ValueObject obj2)
        {
            if (Equals(obj1, null))
            {
                if (Equals(obj2, null))
                {
                    return true;
                }
                return false;
            }
            return obj1.Equals(obj2);
        }

        public static bool operator !=(ValueObject obj1, ValueObject obj2)
        {
            return !(obj1 == obj2);
        }

        public bool Equals(ValueObject obj)
        {
            return Equals(obj as object);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            return GetProperties().All(p => PropertiesAreEqual(obj, p))
                && GetFields().All(f => FieldsAreEqual(obj, f));
        }

        private bool PropertiesAreEqual(object obj, PropertyInfo p)
        {
            return object.Equals(p.GetValue(this, null), p.GetValue(obj, null));
        }

        private bool FieldsAreEqual(object obj, FieldInfo f)
        {
            return object.Equals(f.GetValue(this), f.GetValue(obj));
        }

        private IEnumerable<PropertyInfo> GetProperties()
        {
            if (this.properties == null)
            {
                this.properties = GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .ToList();
            }

            return this.properties;
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            if (this.fields == null)
            {
                this.fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .ToList();
            }

            return this.fields;
        }
    }
}
