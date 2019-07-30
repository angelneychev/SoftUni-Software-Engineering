namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        //Has 120 damage points and 5 health points.
        private const int DefaultDamagePoints = 5;
        private const int DefaultHealthPoints = 80;

        //Constructor should take the following values upon initialization: string name
        public TrapCard(string name) 
            : base(name, DefaultDamagePoints, DefaultHealthPoints)
        {
        }
    }
}
