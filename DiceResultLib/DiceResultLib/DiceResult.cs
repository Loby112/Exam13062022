using System;

namespace DiceResultLib {
    public class DiceResult {
        private int _diceValue;
        private string _playerName;

        public DiceResult(string name, int value){
            PlayerName = name;
            DiceValue = value;

        }

        public DiceResult(){

        }

        public string PlayerName{
            get => _playerName;
            set{
                if (value == null) throw new ArgumentNullException();
                if(value.Length < 3) throw new ArgumentOutOfRangeException();
                _playerName = value;
            }
        }

        public int DiceValue{
            get => _diceValue;
            set{
                if (value < 1 || value > 6) throw new ArgumentOutOfRangeException();
                _diceValue = value;
            }
        }

        public override string ToString(){
            return $"Player name is {PlayerName} Dice Value is: {DiceValue}";
        }
    }
}
