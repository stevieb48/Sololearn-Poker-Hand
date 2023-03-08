using System;
using System.Collections;
/*
* This program will output the rank of the given poker hand
*
* @author Stephen Bailey
* @version 1.0
*
*          Sololearn Program
*/
namespace Sololearn_Poker_Hand
{
    class Program
    {
        static void Main(string[] args)
        {
            // tester input variable, comment out before live on Sololearn
            //string cards = "10H JH QH KH AH";    // royal flush tester working
            //string cards = "10H 3H 4H 5H 6H";    // straight flush tester working
            //string cards = "KC 10H KS KD KH";    // four of a kind tester working
            //string cards = "KC 8C KS KD 8D";    // full house tester working
            //string cards = "KC 8C 9C 4C 2C";    // flush tester working
            //string cards = "2C 3H 4D 5S 6C";    // straight tester working
            //string cards = "JC JH 4D JS 10C";    // three of a kind tester working
            //string cards = "2C 2H 10D 10S 6C";    // two pairs tester working
            //string cards = "2C 2H 4D JS 6C";    // one pair tester working
            //string cards = "JC 2H 4D QS 6C";    // High Card tester working

            // get cards, uncomment out before live Sololearn
            //string cards =  Console.ReadLine();

            // return card ranking
            PokerHandEvaluator newPokerHandEvaluator = new PokerHandEvaluator(cards);

            // send cards to be ranked and output tanking
            Console.WriteLine(newPokerHandEvaluator.Ranking);

            // hold the console open, comment out before live on Sololearn
            Console.ReadLine();
        }
    }

    //
    class PokerHandEvaluator
    {
        // card face trackers
        private int twos, threes, fours, fives, sixes, sevens, eights, nines, tens, elevens, twelves, thirteens, fourteens = 0;

        // card suit trackers
        private int spades, hearts, diamonds, clubs = 0;

        // array list for unsorted cards
        private ArrayList unsortedCardsNumbers = new ArrayList();

        // array after sorting arraylist
        private int[] sortedArray = new int[5];

        // properties
        private string Card1 { get; set; }
        private string Card2 { get; set; }
        private string Card3 { get; set; }
        private string Card4 { get; set; }
        private string Card5 { get; set; }
        public string Ranking { get; set; } = "";

        // Card Ranker constructer
        public PokerHandEvaluator(string cards)
        {
            // call method to separate hand into cards
            SeparateHand(cards);

            // rank the cards
            RankCards();

            // sort the cards value
            SortCards();

            // check for final conditions ie card rank
            EvaluateTheHand();
        }

        // card ranking method
        private void RankCards()
        {
            // call method to determine how many cards of same value
            TrackCards(Card1);
            TrackCards(Card2);
            TrackCards(Card3);
            TrackCards(Card4);
            TrackCards(Card5);
        }

        // method to turn hand into separate cards
        private void SeparateHand(string cards)
        {
            // split original input hand into array on blanks
            string[] handArray = cards.Split(' ');

            // break up hand into separate cards
            Card1 = handArray[0];
            Card2 = handArray[1];
            Card3 = handArray[2];
            Card4 = handArray[3];
            Card5 = handArray[4];
        }

        // determine track card values
        private void TrackCards(string card)
        {
            // if 3 characters in card must be a 10
            if (card.Length == 3)
            {
                // add to tens tracker
                tens++;

                // add to unsorted array to eventually check for consecutive numbers (straights)
                unsortedCardsNumbers.Add(10);

                // pass in index (index for suit must be third character because of ten) and card
                DetermineSuit(2, card);
            }
            // check if number ie 2 through 9 
            else if (int.TryParse(card[0].ToString(), out int value))
            {
                // pass in index (index for suit must be 2nd character because NOT a ten) and card
                DetermineSuit(1, card);

                // add to card trackers
                switch (value)
                {// must be a number 2 through 9
                    case 2:
                        // add to twos tracker
                        twos++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(2);
                        break;
                    case 3:
                        // add to threes tracker
                        threes++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(3);
                        break;
                    case 4:
                        // add to fours tracker
                        fours++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(4);
                        break;
                    case 5:
                        // add to fives tracker
                        fives++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(5);
                        break;
                    case 6:
                        // add to sixes tracker
                        sixes++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(6);
                        break;
                    case 7:
                        // add to sevens tracker
                        sevens++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(7);
                        break;
                    case 8:
                        // add to eights tracker
                        eights++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(8);
                        break;
                    default:
                        // add to nines tracker
                        nines++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(9);
                        break;
                }
            }
            else
            {// else must be a letter jack through ace
                // pass in index (index for suit must be 2nd character because NOT a ten) and card
                DetermineSuit(1, card);

                switch (card[0].ToString())
                {
                    case "J":
                        // add to elevens tracker
                        elevens++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(11);
                        break;
                    case "Q":
                        // add to twelves tracker
                        twelves++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(12);
                        break;
                    case "K":
                        // add to thirteens tracker
                        thirteens++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(13);
                        break;
                    default:
                        // add to fourteens tracker
                        fourteens++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(14);
                        break;
                }
            }
        }

        // determine suit of the card
        private void DetermineSuit(int index, string card1)
        {
            switch (card1[index].ToString())
            {
                case "S":
                    // add to spades tracker
                    spades++;
                    break;
                case "H":
                    // add to hearts tracker
                    hearts++;
                    break;
                case "D":
                    // add to diamonds tracker
                    diamonds++;
                    break;
                default:
                    // add to clubs tracker
                    clubs++;
                    break;
            }
        }

        // determine value of the hand
        private void EvaluateTheHand()
        {
            if (IsHandRoyalFlush())
            {
                Ranking = "Royal Flush";
            }
            else if (IsHandStraightFlush())
            {
                Ranking = "Straight Flush";
            }
            else if (IsHandFourOfAKind())
            {
                Ranking = "Four of a Kind";
            }
            else if (IsHandFullHouse())
            {
                Ranking = "Full House";
            }
            else if (IsHandFlush())
            {
                Ranking = "Flush";
            }
            else if (IsHandStraight())
            {
                Ranking = "Straight";
            }
            else if (IsHandThreeOfAKind())
            {
                Ranking = "Three of a Kind";
            }
            else if (IsHandTwoPairs())
            {
                Ranking = "Two Pairs";
            }
            else if (IsHandOnePair())
            {
                Ranking = "One Pair";
            }
            else
            {
                Ranking = "High Card";
            }
        }

        // determines if cards are sequential
        private bool CardsSequential()
        {
            // check for consecutive numbers 
            if (sortedArray[sortedArray.Length - 1] == sortedArray[0] + sortedArray.Length - 1)
            {
                return true;
            }

            return false;
        }

        // sorts cards
        private void SortCards()
        {
            // sort the cards numbers
            unsortedCardsNumbers.Sort();

            // move to array to look for consecutive numbers
            sortedArray = (int[])unsortedCardsNumbers.ToArray(typeof(int));
        }

        // is hand a royal flush
        private bool IsHandRoyalFlush()
        {
            if (tens == 1 && elevens == 1 && twelves == 1 && thirteens == 1 && fourteens == 1 && (spades == 5 || hearts == 5 || diamonds == 5 || clubs == 5))
            {
                return true;
            }

            return false;
        }

        // is hand a straight flush
        private bool IsHandStraightFlush()
        {
            if (CardsSequential() && (spades == 5 || hearts == 5 || diamonds == 5 || clubs == 5))
            {
                return true;
            }

            return false;
        }

        // is hand four of a kind
        private bool IsHandFourOfAKind()
        {
            if (twos == 4 || threes == 4 || fours == 4 || fives == 4 || sixes == 4 || sevens == 4 || eights == 4 || nines == 4 || tens == 4 || elevens == 4 || twelves == 4 || thirteens == 4 || fourteens == 4)
            {
                return true;
            }

            return false;
        }

        // is hand a full house
        private bool IsHandFullHouse()
        {
            if ((twos == 3 || threes == 3 || fours == 3 || fives == 3 || sixes == 3 || sevens == 3 || eights == 3 || nines == 3 || tens == 3 || elevens == 3 || twelves == 3 || thirteens == 3 || fourteens == 3) && (twos == 2 || threes == 2 || fours == 2 || fives == 2 || sixes == 2 || sevens == 2 || eights == 2 || nines == 2 || tens == 2 || elevens == 2 || twelves == 2 || thirteens == 2 || fourteens == 2))
            {
                return true;
            }

            return false;
        }

        // is hand a flush
        private bool IsHandFlush()
        {
            if (spades == 5 || hearts == 5 || diamonds == 5 || clubs == 5)
            {
                return true;
            }

            return false;
        }

        // is hand a straight
        private bool IsHandStraight()
        {
            if (CardsSequential())
            {
                return true;
            }

            return false;
        }

        // is hand three of a kind
        private bool IsHandThreeOfAKind()
        {
            if (twos == 3 || threes == 3 || fours == 3 || fives == 3 || sixes == 3 || sevens == 3 || eights == 3 || nines == 3 || tens == 3 || elevens == 3 || twelves == 3 || thirteens == 3 || fourteens == 3)
            {
                return true;
            }

            return false;
        }

        // is hand two pairs
        private bool IsHandTwoPairs()
        {
            if (CheckForTwoPairs())
            {
                return true;
            }

            return false;
        }

        // is hand one pair
        private bool IsHandOnePair()
        {
            if (twos == 2 || threes == 2 || fours == 2 || fives == 2 || sixes == 2 || sevens == 2 || eights == 2 || nines == 2 || tens == 2 || elevens == 2 || twelves == 2 || thirteens == 2 || fourteens == 2)
            {
                return true;
            }

            return false;
        }

        //
        private bool CheckForTwoPairs()
        {
            // array list for unsorted cards
            ArrayList trackerArray = new ArrayList { twos, threes, fours, fives, sixes, sevens, eights, nines, tens, elevens, twelves, thirteens, fourteens };

            // sort tracker 
            trackerArray.Sort();

            // reverse the order get populated trackers in the front of array List
            trackerArray.Reverse();

            // 
            for (int i = 0; i < 12; i++)
            {
                //
                if (int.TryParse(trackerArray[0].ToString(), out int value1))
                {
                    //
                    if (int.TryParse(trackerArray[1].ToString(), out int value2))
                    {
                        // if two trackers have pairs
                        if (value1 == 2 && value2 == 2)
                        {
                            {
                                // must be 2 pairs
                                return true;
                            }
                        }
                    }
                }
            }

            // must not be 2 pairs
            return false;
        }
    }
}