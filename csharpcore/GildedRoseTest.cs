using Xunit;
using System.Collections.Generic;
using System.Dynamic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void UpdateQuality_AgedBrieItemTest()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(0, Items[0].SellIn);
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePassesItemTest()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePassesItemTest_NegativeSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 2 } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_SulfurasItemTest_MaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 80 } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(2, Items[0].SellIn);
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_NormalItemTest()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Normal item", SellIn = 5, Quality = 5 } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(4, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_NormalItemTest_ExceededQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Normal item", SellIn = -1, Quality = 60 } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_NormalItemTest_NegativeSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Normal Item", SellIn = -1, Quality = 4 } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ConjuredItemTest()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 2, Quality = 2 } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(1, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ConjuredItemTest_NegativeSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 5 } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(1, Items[0].Quality);
        }

    }
}