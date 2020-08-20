using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var currentItem = Items[i];
                Context context = SetContext(currentItem);

                context.ContextInterface(currentItem);
            }
        }
        #region Strategy design patern for items 
        public abstract class AStrategy
        {
            public abstract void HandleItem(Item item);
            public void DegradeQuality(Item item)
            {
                int factor = 1;
                if (item.SellIn < 0)
                    factor = 2;
                for (int i = 0; i < factor; i++)
                {
                    if (item.Quality > 0)
                    {
                        item.Quality--;
                    }
                }
                if(item.Quality > 50)
                {
                    item.Quality = 50;
                }
            }
            public void IncreaseQuality(Item item)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }
        }
        public class NormalItemStratery : AStrategy
        {
            public override void HandleItem(Item item)
            {
                item.SellIn--;
                DegradeQuality(item);
            }
        }
        public class ConjuredItemStratery : AStrategy
        {
            public override void HandleItem(Item item)
            {
                item.SellIn--;
                DegradeQuality(item);
                DegradeQuality(item);
            }
        }
        public class AgedBrieItemStratery : AStrategy
        {
            public override void HandleItem(Item item)
            {
                item.SellIn--;
                IncreaseQuality(item);
            }
        }
        public class SulfurasItemStratery : AStrategy
        {
            public override void HandleItem(Item item)
            {
                item.SellIn = item.SellIn;
                item.Quality = item.Quality;
            }
        }
        public class BackstageItemStratery : AStrategy
        {
            public override void HandleItem(Item item)
            {
                item.SellIn--;
                if (item.SellIn < 0)
                {
                    item.Quality = 0;
                }
                else
                {
                    IncreaseQuality(item);
                    if (item.SellIn < 11)
                    {
                        IncreaseQuality(item);
                    }
                    if (item.SellIn < 6)
                    {
                        IncreaseQuality(item);
                    }
                }
            }
        }
        #endregion

        #region Context as kinda factory but not realy
        public class Context
        {
            private AStrategy _strategy;

            public Context(AStrategy strategy)
            {
                this._strategy = strategy;
            }
            public void ContextInterface(Item item)
            {
                _strategy.HandleItem(item);
            }
        }
        public Context SetContext(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            switch (item.Name)
            {
                case "Aged Brie":
                    return new Context(new AgedBrieItemStratery());
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new Context(new BackstageItemStratery());
                case "Sulfuras, Hand of Ragnaros":
                    return new Context(new SulfurasItemStratery());
                case "Conjured Mana Cake":
                    return new Context(new ConjuredItemStratery());
                default:
                    return new Context(new NormalItemStratery());
            }
        }
        #endregion
    }
}
