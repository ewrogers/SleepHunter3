using System;

namespace SleepHunter.Models
{
    public class PlayerState : ObservableObject
    {
        private string _name = string.Empty;

        private string _mapName = string.Empty;
        private int _mapId;
        private int _mapX;
        private int _mapY;

        private long _currentHealth;
        private long _maxHealth;
        private long _currentMana;
        private long _maxMana;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string MapName
        {
            get => _mapName;
            set => SetProperty(ref _mapName, value);
        }

        public int MapId
        {
            get => _mapId;
            set => SetProperty(ref _mapId, value);
        }

        public int MapX
        {
            get => _mapX;
            set => SetProperty(ref _mapX, value);
        }

        public int MapY
        {
            get => _mapY;
            set => SetProperty(ref _mapY, value);
        }

        public long CurrentHealth
        {
            get => _currentHealth;
            set
            {
                SetProperty(ref _currentHealth, value);
                OnPropertyChanged(nameof(HealthPercentage));
            }
        }

        public long MaxHealth
        {
            get => _maxHealth;
            set
            {
                SetProperty(ref _maxHealth, value);
                OnPropertyChanged(nameof(HealthPercentage));
            }
        }

        public int HealthPercentage => (int)(CurrentHealth * 100 / Math.Max(1, MaxHealth));

        public long CurrentMana
        {
            get => _currentMana;
            set
            {
                SetProperty(ref _currentMana, value);
                OnPropertyChanged(nameof(ManaPercentage));
            }
        }

        public long MaxMana
        {
            get => _maxMana;
            set
            {
                SetProperty(ref _maxMana, value);
                OnPropertyChanged(nameof(ManaPercentage));
            }
        }

        public int ManaPercentage => (int)(CurrentMana * 100 / Math.Max(1, MaxMana));
    }
}
