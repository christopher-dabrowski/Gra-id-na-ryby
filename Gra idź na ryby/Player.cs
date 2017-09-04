﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra_idź_na_ryby
{
    public class Player
    {
        public string Name { get; private set; }
        private Random random;
        private Deck cards = new Deck(new Card[0]);
        private TextBox textBox;

        public int CardCount => cards.Count;
        public IEnumerable<string> CardNames => cards.GetCardNames();
        

        public Player(string name, Random random, TextBox textBox)
        {
            Name = name;
            this.random = random;
            this.textBox = textBox;

            textBox.Text += Name + " dołączył do gry" + Environment.NewLine;
        }

        public void TakeCard(Card card) => cards.Add(card);
        public Card Peek(int index = 0) => cards.Peek(index);
        public void SortHand() => cards.SortByValue();

        public IEnumerable<Values> PulOutBooks()
        {
            return cards.PoolBooks();
        }

        public Values RandomValue()
        {
            return cards.Peek(random.Next(cards.Count)).Value;
        }

        public Deck DoYouHaveAny(Values value)
        {
            Deck result = cards.PullOutValues(value);
            textBox.Text += string.Format("{0} ma {1} {2}", Name, result.Count, Card.PluralValueName(value, result.Count));
            return result;
        }
    }
}
