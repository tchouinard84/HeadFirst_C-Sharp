namespace SecretIngredients
{
    public class Suzanne
    {
        public GetSecretIngredient MySecretIngredientMethod => SuzannesSecretIngredient;

        private string SuzannesSecretIngredient(int amount)
        {
            return $"{amount} ounces of cloves";
        }
    }
}
