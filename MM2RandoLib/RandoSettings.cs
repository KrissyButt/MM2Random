﻿using System;
using System.Reflection;
using System.ComponentModel;

namespace MM2Randomizer
{
    public class RandoSettings : INotifyPropertyChanged
    {
        public RandoSettings()
        {
            SeedString = "";
            SourcePath = "";
            IsSourcePathAndSeedValid = false;
            IsJapanese = false;
            Is8StagesRandom = true;
            IsWeaponsRandom = true;
            IsItemsRandom = true;
            IsTeleportersRandom = true;
            IsColorsRandom = true;
            IsWeaponBehaviorRandom = true;
            IsWeaknessRandom = true;
            IsWeaknessEasy = false;
            IsWeaknessHard = true;
            IsBossAIRandom = true;
            IsEnemiesRandom = true;
            IsTilemapChangesEnabled = true;
            IsBGMRandom = true;
            IsWeaponNamesRandom = true;
            FastText = true;
            BurstChaserMode = false;
        }

        private string seedString;
        /// <summary>
        /// Alphabetical string representation of the RandomMM2.Seed integer of the most
        /// recently generated ROM.
        /// </summary>
        public string SeedString
        {
            get { return seedString; }
            set
            {
                value = value.ToUpper();
                if (seedString != value)
                {
                    seedString = value;
                    OnPropertyChanged("SeedString");

                    // TODO: Check for better validity of seed
                    if (seedString == "")
                    {
                        IsSeedValid = false;
                    }
                    else
                    {
                        IsSeedValid = true;
                    }

                    IsSourcePathAndSeedValid = IsSourcePathValid && IsSeedValid;
                }
            }
        }

        private string sourcePath;
        /// <summary>
        /// Full path to user-provided ROM to apply patch.
        /// </summary>
        public string SourcePath
        {
            get { return sourcePath; }
            set
            {
                if (sourcePath != value)
                {
                    sourcePath = value;
                    OnPropertyChanged("SourcePath");

                    // Check if source path is valid
                    IsSourcePathValid = System.IO.File.Exists(value);
                    IsSourcePathAndSeedValid = IsSourcePathValid && IsSeedValid;
                }
            }
        }

        private bool isSourcePathValid;
        public bool IsSourcePathValid
        {
            get
            {
                return isSourcePathValid;
            }
            set
            {
                if (isSourcePathValid != value)
                {
                    isSourcePathValid = value;
                    OnPropertyChanged("IsSourcePathValid");
                }
            }
        }

        private bool isSeedValid = true;
        public bool IsSeedValid
        {
            get { return isSeedValid; }
            set
            {
                if (isSeedValid != value)
                {
                    isSeedValid = value;
                    OnPropertyChanged("IsSeedValid");
                }
            }
        }
        private bool isSourcePathAndSeedValid;
        public bool IsSourcePathAndSeedValid
        {
            get
            {
                return isSourcePathAndSeedValid;
            }
            set
            {
                if (isSourcePathAndSeedValid != value)
                {
                    isSourcePathAndSeedValid = value;
                    OnPropertyChanged("IsSourcePathAndSeedValid");
                }
            }
        }

        /// <summary>
        /// Use ROM Rockman 2 (J).nes if true, Mega Man 2 (U).nes if false.
        /// </summary>
        public bool IsJapanese { get; set; }

        /// <summary>
        /// If True, the Robot Master stages will be shuffled and will not be indicated by the
        /// portraits on the Stage Select screen.
        /// </summary>
        public bool Is8StagesRandom { get; set; }

        /// <summary>
        /// If True, the weapons awarded from each Robot Master is shuffled.
        /// </summary>
        public bool IsWeaponsRandom { get; set; }

        /// <summary>
        /// If True, Items 1, 2, and 3 will be awarded from random Robot Masters.
        /// </summary>
        public bool IsItemsRandom { get; set; }

        /// <summary>
        /// If true, in Wily 5, the Robot Master locations in each teleporter is randomized.
        /// </summary>
        public bool IsTeleportersRandom { get; set; }

        /// <summary>
        /// If True, the damage each weapon does against each Robot Master is changed. The manner in
        /// which it is changed depends on if IsWeaknessEasy is True or if IsWeaknessHard is True.
        /// </summary>
        public bool IsWeaknessRandom { get; set; }

        /// <summary>
        /// If True, and if IsWeaknessRandom is True, the damage tables for each weapon are shuffled.
        /// </summary>
        public bool IsWeaknessEasy { get; set; }

        /// <summary>
        /// If True, and if IsWeaknessRandom is True, the damage tables for each weapon are filled
        /// with random values, within practical tolerances for each weapon.
        /// </summary>
        public bool IsWeaknessHard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsBossAIRandom { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsColorsRandom { get;  set; }

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsEnemiesRandom { get; set; }

        public bool IsEnemyWeaknessRandom { get; set; } = true;

        public bool IsBossInBossRoomRandom { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        public bool IsTilemapChangesEnabled { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsBGMRandom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsWeaponNamesRandom { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public bool FastText { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public bool BurstChaserMode { get; set; }
        public bool IsWeaponBehaviorRandom { get; set; }
        
        /// <summary>
        /// Get this assembly version as a bindable property.
        /// </summary>
        public Version AssemblyVersion
        {
            get
            {
                return Assembly.GetAssembly(typeof(RandomMM2)).GetName().Version;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise event to update bound GUI controls
        /// </summary>
        /// <param name="name">Name of updated property.</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
