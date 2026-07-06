namespace Consystently 
{
    namespace Sieve
    {
        /// <summary>
        /// Used for sorting Lists and Dictionaries. Add/Remove assortments as needed
        /// </summary>
        public enum Assortment
        {
            AtoZ,
            ZtoA,
            HighestQuantity,
            LowestQuantity,
        }
        
        /// <summary>
        /// The different kinds of categories for items. Used for filtering. Add/Remove categories as needed.
        /// </summary>
        public enum Category
        {
            Miscellaneous = 0,
            Consumables = 1
        }

        /// <summary>
        /// The different kinds of categories for items. Used for assigning value and filtering. Add/Remove rarities as needed.
        /// </summary>
        public enum Rarity
        {
            Common = 0,
            Rare = 1
        }

    }
}
