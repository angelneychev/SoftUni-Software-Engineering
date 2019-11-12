namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int CardDamagePoints = 120;
        private const int PlayerHealthPoint = 5;

        public TrapCard(string name) 
            : base(name, CardDamagePoints, PlayerHealthPoint)
        {
        }
    }
}

//Has 120 damage points and 5 health points.
//Constructor should take the following values upon initialization:
//string name
