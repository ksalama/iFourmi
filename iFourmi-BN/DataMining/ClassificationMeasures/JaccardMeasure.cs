﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iFourmi.DataMining.ClassificationMeasures
{
    public class JaccardMeasure:IClassificationQualityMeasure
    {
        public double CalculateMeasure(ConfusionMatrix[] list)
        {
            double measure = 0.0;
            foreach (ConfusionMatrix matrix in list)
            {
                double value = (double)(matrix.TP) / (double)(matrix.TP + matrix.FP + matrix.FN);
                if (!double.IsNaN(value))
                    measure += value;
            }
            measure /= (double)list.Length;
            return measure;
            
        }

        public override string ToString()
        {
            return "jaccard";
        }
    }
}
