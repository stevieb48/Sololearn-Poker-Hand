using System;
using System.Collections;
/*

@author Stephen Bailey
@version 1.0
Date 3-3-2023

Sololearn Program

You are playing poker with your friends and need to evaluate your hand. 
A hand consists of five cards and is ranked, from lowest to highest, in the following way:

High Card: Highest value card (from 2 to Ace).
One Pair: Two cards of the same value.
Two Pairs: Two different pairs.
Three of a Kind: Three cards of the same value.
Straight: All cards are consecutive values.
Flush: All cards of the same suit.
Full House: Three of a kind and a pair.
Four of a Kind: Four cards of the same value.
Straight Flush: All cards are consecutive values of same suit.
Royal Flush: 10, Jack, Queen, King, Ace, in same suit. 

Task:
Output the rank of the given poker hand. 

Input Format: 
A string, representing five cards, each indicating the value and suite of the card, separated by spaces. 
Possible card values are: 2 3 4 5 6 7 8 9 10 J Q K A
Suites:  H (Hearts), D (Diamonds), C (Clubs), S (Spades)
For example, JD indicates Jack of Diamonds. 

Output Format:
A string, indicating the rank of the hand (in the format of the above description). 

Sample Input:
JS 2H JC AC 2D

Sample Output: 
Two Pairs

*/
namespace Sololearn_Poker_Hand
{
    class Program
    {
        static void Main(string[] args)
        {
            // tester input variable, comment out before live on Sololearn
            string cards = "10H JH QH KH AH";    // royal flush tester working
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

    // this class contains all the properties and functions to handle and evaluate the poker hand
    class PokerHandEvaluator
    {
        // CONSTANTS
        private const int NUMBER_OF_CARDS = 5;

        private const string JACK = "J";
        private const string QUEEN = "Q";
        private const string KING = "K";

        private const string SPADES = "S";
        private const string HEARTS = "H";
        private const string DIAMONDS = "D";

        // card face trackers
        private int twos, threes, fours, fives, sixes, sevens, eights, nines, tens, jacks, queens, kings, aces = 0;

        // card suit trackers
        private int spades, hearts, diamonds, clubs = 0;

        // array list for unsorted cards
        private ArrayList unsortedCardsNumbers = new ArrayList();

        // array after sorting arraylist
        private int[] sortedArray = new int[NUMBER_OF_CARDS];

        // properties
        private string Card1 { get; set; }
        private string Card2 { get; set; }
        private string Card3 { get; set; }
        private string Card4 { get; set; }
        private string Card5 { get; set; }
        public string Ranking { get; set; } = "";

        // constructor
        public PokerHandEvaluator(string cards)
        {
            // call method to separate hand into cards
            SeparateTheHand(cards);

            // rank the cards
            RankTheCards();

            // sort the cards value
            SortTheCards();

            // check for final conditions ie card rank
            EvaluateTheHand();
        }

        // method card ranking method
        private void RankTheCards()
        {
            // call method to determine how many cards of same value
            TrackTheCards(Card1);
            TrackTheCards(Card2);
            TrackTheCards(Card3);
            TrackTheCards(Card4);
            TrackTheCards(Card5);
        }

        // method to turn hand into separate cards
        private void SeparateTheHand(string cards)
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

        // method determine and track card values
        private void TrackTheCards(string card)
        {
            // if 3 characters in card must be a 10
            if (card.Length == 3)
            {
                // add to tens tracker
                tens++;

                // add to unsorted array to eventually check for consecutive numbers (straights)
                unsortedCardsNumbers.Add(10);

                // pass in index (index for suit must be third character because of ten) and card
                DetermineTheSuit(2, card);
            }
            // check if number ie 2 through 9 
            else if (int.TryParse(card[0].ToString(), out int value))
            {
                // pass in index (index for suit must be 2nd character because NOT a ten) and card
                DetermineTheSuit(1, card);

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
                DetermineTheSuit(1, card);

                switch (card[0].ToString())
                {
                    case JACK:
                        // add to jacks tracker
                        jacks++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(11);
                        break;
                    case QUEEN:
                        // add to queens tracker
                        queens++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(12);
                        break;
                    case KING:
                        // add to kings tracker
                        kings++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(13);
                        break;
                    default:    // must be an ACE
                        // add to aces tracker
                        aces++;

                        // add to unsorted array to eventually check for consecutive numbers (straights)
                        unsortedCardsNumbers.Add(14);
                        break;
                }
            }
        }

        // method determine suit of the card
        private void DetermineTheSuit(int index, string card1)
        {
            switch (card1[index].ToString())
            {
                case SPADES:
                    // add to spades tracker
                    spades++;
                    break;
                case HEARTS:
                    // add to hearts tracker
                    hearts++;
                    break;
                case DIAMONDS:
                    // add to diamonds tracker
                    diamonds++;
                    break;
                default:
                    // add to clubs tracker
                    clubs++;
                    break;
            }
        }

        // method determine value of the hand
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
            else if (IsHandThreeOfKind())
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

        // method determines if cards are sequential
        private bool AreCardsSequential()
        {
            // check for consecutive numbers 
            if (sortedArray[sortedArray.Length - 1] == sortedArray[0] + sortedArray.Length - 1)
            {
                return true;
            }

            return false;
        }

        // method sorts cards
        private void SortTheCards()
        {
            // sort the cards numbers
            unsortedCardsNumbers.Sort();

            // move to array to look for consecutive numbers
            sortedArray = (int[])unsortedCardsNumbers.ToArray(typeof(int));
        }

        // method is hand a royal flush
        private bool IsHandRoyalFlush()
        {
            if (tens == 1 && jacks == 1 && queens == 1 && kings == 1 && aces == 1 && (spades == 5 || hearts == 5 || diamonds == 5 || clubs == 5))
            {
                return true;
            }

            return false;
        }

        // method is hand a straight flush
        private bool IsHandStraightFlush()
        {
            if (AreCardsSequential() && (spades == 5 || hearts == 5 || diamonds == 5 || clubs == 5))
            {
                return true;
            }

            return false;
        }

        // method is hand four of a kind
        private bool IsHandFourOfAKind()
        {
            if (twos == 4 || threes == 4 || fours == 4 || fives == 4 || sixes == 4 || sevens == 4 || eights == 4 || nines == 4 || tens == 4 || jacks == 4 || queens == 4 || kings == 4 || aces == 4)
            {
                return true;
            }

            return false;
        }

        // method is hand a full house
        private bool IsHandFullHouse()
        {
            if ((twos == 3 || threes == 3 || fours == 3 || fives == 3 || sixes == 3 || sevens == 3 || eights == 3 || nines == 3 || tens == 3 || jacks == 3 || queens == 3 || kings == 3 || aces == 3) && (twos == 2 || threes == 2 || fours == 2 || fives == 2 || sixes == 2 || sevens == 2 || eights == 2 || nines == 2 || tens == 2 || jacks == 2 || queens == 2 || kings == 2 || aces == 2))
            {
                return true;
            }

            return false;
        }

        // method is hand a flush
        private bool IsHandFlush()
        {
            if (spades == 5 || hearts == 5 || diamonds == 5 || clubs == 5)
            {
                return true;
            }

            return false;
        }

        // method is hand a straight
        private bool IsHandStraight()
        {
            if (AreCardsSequential())
            {
                return true;
            }

            return false;
        }

        // method is hand three of a kind
        private bool IsHandThreeOfKind()
        {
            if (twos == 3 || threes == 3 || fours == 3 || fives == 3 || sixes == 3 || sevens == 3 || eights == 3 || nines == 3 || tens == 3 || jacks == 3 || queens == 3 || kings == 3 || aces == 3)
            {
                return true;
            }

            return false;
        }

        // method is hand two pairs
        private bool IsHandTwoPairs()
        {
            if (CheckForTwoPairs())
            {
                return true;
            }

            return false;
        }

        // method to see if hand is two pairs
        private bool CheckForTwoPairs()
        {
            // array list for unsorted cards
            ArrayList trackerArray = new ArrayList { twos, threes, fours, fives, sixes, sevens, eights, nines, tens, jacks, queens, kings, aces };

            // sort tracker 
            trackerArray.Sort();

            // reverse the order get populated trackers in the front of array List
            trackerArray.Reverse();

            // loop through array list of trackers
            for (int i = 0; i < 12; i++)
            {
                // grab the first value in the array list
                if (int.TryParse(trackerArray[0].ToString(), out int value1))
                {
                    // grab the second value in the array list
                    if (int.TryParse(trackerArray[1].ToString(), out int value2))
                    {
                        // if two of the trackers have pairs
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

        // method is hand one pair
        private bool IsHandOnePair()
        {
            if (twos == 2 || threes == 2 || fours == 2 || fives == 2 || sixes == 2 || sevens == 2 || eights == 2 || nines == 2 || tens == 2 || jacks == 2 || queens == 2 || kings == 2 || aces == 2)
            {
                return true;
            }

            return false;
        }
    }
}