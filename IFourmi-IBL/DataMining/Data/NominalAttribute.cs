﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iFourmi.DataMining.Data
{
    public class NominalAttribute: Data.Attribute
    {
        #region Data Members

        private string[] _values;
        private int[] _counts;
        private Dictionary<string, int> _indexes;

        #endregion

        #region Properties

        public string[] Values
        {
            get { return this._values; }
        }

        public int[] ValueCounts
        {
            get { return this._counts; }
        }

        #endregion

        #region Constructor

        public NominalAttribute(string name, int index, string[] values)         
        {
            this._index = index;
            this._name = name; 
            this._values = values;
            this._indexes = new Dictionary<string, int>();
            this._counts = new int[values.Length];

            int i = 0;
            foreach (string value in values)
            {
                this._indexes.Add(value, i);
                i++;
            }          
        }

        #endregion

        #region Methods

        public int GetIndex(string value)
        {
            if (this._indexes.ContainsKey(value))
                return this._indexes[value];
            else
                return -1;
        }

         public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append( this._name + " ");

            builder.Append("{");

            for (int index = 0; index < this._values.Length; index++)
            {                
                builder.Append(this._values[index]);
                builder.Append(",");
            }

            builder = builder.Remove(builder.Length - 1, 1);
            builder.Append("}");
            
            return builder.ToString();
        }
        

        public  override Data.Attribute Clone()
        {
             Data.NominalAttribute clone = new NominalAttribute(this._name, this._index, this._values.Clone() as string[]);
             return clone;
            
        }


        #endregion


    }
}
