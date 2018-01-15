namespace SecretIngredients
{
    public class Amy
    {
        public GetSecretIngredient MySecretIngredientMethod => AmysSecretIngredient;

        private string AmysSecretIngredient(int amount)
        {
            if (amount < 10) { return $"{amount} cans of sardines -- you need more!"; }
            return $"{amount} cans of sardines";
        }
    }
}
