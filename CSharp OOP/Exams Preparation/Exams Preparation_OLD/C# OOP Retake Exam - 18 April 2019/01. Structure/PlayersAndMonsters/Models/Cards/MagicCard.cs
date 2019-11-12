namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {

        private const int CardDamagePoints  = 5;
        private const int PlayerHealthPoint  = 50;


        public MagicCard(string name)
            : base(name, CardDamagePoints, PlayerHealthPoint)
        {
        }
    }
}

//Has 5 damage points and 80 health points.
//Constructor should take the following values upon initialization:
//string name

