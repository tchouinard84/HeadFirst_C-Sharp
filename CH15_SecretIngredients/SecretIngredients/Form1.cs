using System;
using System.Windows.Forms;

namespace SecretIngredients
{
    public partial class Form1 : Form
    {
        private GetSecretIngredient ingredientMethod = null;
        private Suzanne suzanne = new Suzanne();
        private Amy amy = new Amy();

        public Form1()
        {
            InitializeComponent();
        }

        private void useIngredient_Click(object sender, EventArgs e)
        {
            if (ingredientMethod != null) { MessageBox.Show($"I'll add {ingredientMethod((int) amount.Value)}"); }
            else { MessageBox.Show("I don't have a secret ingredient!"); }
        }

        private void getSuzanne_Click(object sender, EventArgs e)
        {
            ingredientMethod = suzanne.MySecretIngredientMethod;
        }

        private void getAmy_Click(object sender, EventArgs e)
        {
            ingredientMethod = amy.MySecretIngredientMethod;
        }
    }
}
