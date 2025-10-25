using System;

namespace SleepHunter.Models
{
    public class PlayerState : ObservableObject
    {
        private string name = string.Empty;

        private string mapName = string.Empty;
        private int mapId;
        private int mapX;
        private int mapY;

        private long currentHealth;
        private long maxHealth;
        private long currentMana;
        private long maxMana;

        private bool chatHasFocus;
        
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string MapName
        {
            get => mapName;
            set => SetProperty(ref mapName, value);
        }

        public int MapId
        {
            get => mapId;
            set => SetProperty(ref mapId, value);
        }

        public int MapX
        {
            get => mapX;
            set => SetProperty(ref mapX, value);
        }

        public int MapY
        {
            get => mapY;
            set => SetProperty(ref mapY, value);
        }

        public long CurrentHealth
        {
            get => currentHealth;
            set
            {
                SetProperty(ref currentHealth, value);
                OnPropertyChanged(nameof(HealthPercentage));
            }
        }

        public long MaxHealth
        {
            get => maxHealth;
            set
            {
                SetProperty(ref maxHealth, value);
                OnPropertyChanged(nameof(HealthPercentage));
            }
        }

        public double HealthPercentage => (CurrentHealth * 100.0 / Math.Max(1, MaxHealth));

        public long CurrentMana
        {
            get => currentMana;
            set
            {
                SetProperty(ref currentMana, value);
                OnPropertyChanged(nameof(ManaPercentage));
            }
        }

        public long MaxMana
        {
            get => maxMana;
            set
            {
                SetProperty(ref maxMana, value);
                OnPropertyChanged(nameof(ManaPercentage));
            }
        }

        public double ManaPercentage => CurrentMana * 100.0 / Math.Max(1, MaxMana);

        public bool ChatHasFocus
        {
            get => chatHasFocus;
            set => SetProperty(ref chatHasFocus, value);
        }
    }
}
