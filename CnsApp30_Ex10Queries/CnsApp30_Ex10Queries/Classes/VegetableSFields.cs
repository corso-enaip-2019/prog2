using System;
using System.Collections.Generic;
using System.Text;

namespace CnsApp30_Ex10Queries
{
    class VegetableSFields
    {
        public string Vegetable { get; set; }
        public List<Field> FieldsWhereItIsHarvested { get; set; }

        public VegetableSFields() { }

        public VegetableSFields(string cropSName,List<Field> fieldsWhereItIsHarvested)
        {
            Vegetable = cropSName;
            FieldsWhereItIsHarvested = fieldsWhereItIsHarvested;
        }
    }
}