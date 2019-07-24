namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValide(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return true;
        }
    }
}
