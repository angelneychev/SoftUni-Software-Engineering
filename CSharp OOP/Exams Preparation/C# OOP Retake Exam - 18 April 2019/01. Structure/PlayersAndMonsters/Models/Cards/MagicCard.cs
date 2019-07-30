namespace PlayersAndMonsters.Models.Cards
{
    class MagicCard : Card
    {
        //Has 5 damage points and 80 health points.
        private const int DefaultDamagePoints = 5;
        private const int DefaultHealthPoints = 80;


        public MagicCard(string name) 
            : base(name, DefaultDamagePoints, DefaultHealthPoints)
        {
        }
    }
}
