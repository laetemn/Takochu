﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takochu.io;
using Takochu.util;

namespace Takochu.smg
{
    public class Game
    {
        public Game(FilesystemBase filesystem)
        {
            mFilesystem = filesystem;

            // now we decide which game we're dealing with
            // just checking to see if a file exists in one game but not the other.
            if (mFilesystem.DoesFileExist("/ObjectData/ProductMapObjDataTable.arc"))
                GameUtil.SetGame(GameUtil.Game.SMG2);
            else
                GameUtil.SetGame(GameUtil.Game.SMG1);
        }

        public void Close()
        {
            mFilesystem.Close();
        }

        public bool DoesFileExist(string file)
        {
            return mFilesystem.DoesFileExist(file);
        }

        public bool IsGalaxy(string galaxy)
        {
            // this solution works for both games
            return mFilesystem.DoesFileExist($"/StageData/{galaxy}/{galaxy}Scenario.arc");
        }

        public List<string> GetGalaxies()
        {
            List<string> galaxies = new List<string>();

            // this solution works for both games
            List<string> dirs = mFilesystem.GetDirectories("/StageData");
            foreach(string dir in dirs)
            {
                if (IsGalaxy(dir))
                    galaxies.Add(dir);
            }

            return galaxies;
        }

        public FilesystemBase mFilesystem;
    }
}
