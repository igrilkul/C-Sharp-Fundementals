 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            //TODO put your reflection code here
            string input;
            Type type = typeof(HarvestingFields);

            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic
                | BindingFlags.Public | BindingFlags.Instance);

            while((input=Console.ReadLine())!="HARVEST")
            {
                FieldInfo[] fieldsToPrint;
                if (input=="all")
                {
                    fieldsToPrint = fields;
                }
                else
                {
                    fieldsToPrint = fields.Where
                    (f => f.Attributes
                    .ToString()
                    .ToLower()
                    .Replace("family", "protected")
                    == input).ToArray();
                }
                 

                foreach(var field in fieldsToPrint)
                {
                    Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family","protected")} {field.FieldType.Name} {field.Name}");
                }

               
            }
        }
    }
}
