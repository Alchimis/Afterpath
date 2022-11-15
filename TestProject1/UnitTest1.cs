using NUnit.Framework;
using ConsoleApp1.NewFolder;
using System.Collections.Generic;
using System.Threading;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void Player_Music_List()
        {
            // ARRANGE
            List<string> playList = new List<string> {
                "staing alive",
                "smooth criminal",
                "killer queen",
            };
            var player = new Player(playList);

            // ACT
            var playerPlayList = player.MusicList; // Перенести в assert

            // ASSERT
;           Assert.AreEqual(playList, playerPlayList);
            Assert.AreEqual(0, player.MusicPlayedIndex);
            Assert.AreEqual(playList[0],player.MusicPlayed);
        }
        [Test]
        public void Next_Index()
        {
            // ARRANGE
            List<string> playList = new List<string> {
                "staing alive",
                "smooth criminal",
                "killer queen",
            };
            var player = new Player(playList);


            // ACT
            player.Next();

            // ASSERT
            Assert.AreEqual(1, player.MusicPlayedIndex);
            Assert.AreEqual(playList[1], player.MusicPlayed);
            Assert.AreEqual(PlayerStatus.new_music, player.Status);
        }
        [Test]
        public void Prev_Loop_Music_Played()
        {
            // ARRANGE
            List<string> playList = new List<string> {
                "staing alive",
                "smooth criminal",
                "killer queen",
                "boombastic",
            };
            var player = new Player(playList);

            // ACT
            player.Previous();

            // ASSERT
            Assert.AreEqual(playList[3], player.MusicPlayed);
            Assert.AreEqual(3, player.MusicPlayedIndex);
            Assert.AreEqual(PlayerStatus.new_music, player.Status);
        }
        [Test]
        public void Play_Status()
        {
            // ARRANGE
            List<string> playList = new List<string> {
                "staing alive",
                "smooth criminal",
                "killer queen",
                "boombastic",
            };
            var player = new Player(playList);
            

            // ACT
            player.Play();

            // ASSERT
            Assert.AreEqual(PlayerStatus.play, player.Status);
            Assert.AreEqual(playList[0],player.MusicPlayed);
            Assert.AreEqual(0,player.MusicPlayedIndex);
        }
        [Test]
        public void Play_Stop_Status()
        {
            // ARRANGE
            List<string> playList = new List<string> {
                "staing alive",
                "smooth criminal",
                "killer queen",
                "boombastic",
            };
            var player = new Player(playList);

            // ACT
            player.Play();
            player.Stop();
            var status = player.Status;

            // ASSERT
            Assert.AreEqual(PlayerStatus.pause, status);
            Assert.AreEqual(playList[0], player.MusicPlayed);
            Assert.AreEqual(0, player.MusicPlayedIndex);
        }
        [Test]
        public void Prev_Status()
        {
            // ARRANGE
            List<string> playList = new List<string> {
                "staing alive",
                "smooth criminal",
                "killer queen",
                "boombastic",
            };
            var player = new Player(playList);

            // ACT
            player.Next();
            player.Previous();

            // ASSERT
            Assert.AreEqual(PlayerStatus.new_music, player.Status);
            Assert.AreEqual(0, player.MusicPlayedIndex);
            Assert.AreEqual(playList[0], player.MusicPlayed);
        }
        [Test]
        public void Next_Loop_Index()
        {
            // ARRANGE
            List<string> playList = new List<string> {
                "staing alive",
                "smooth criminal",
                "killer queen",
                "boombastic",
            };
            var player = new Player(playList);

            // ACT
            player.Next();
            player.Next();
            player.Next();
            player.Next();

            // ASSERT
            Assert.AreEqual(0, player.MusicPlayedIndex);
            Assert.AreEqual(PlayerStatus.new_music, player.Status);
            Assert.AreEqual(playList[0], player.MusicPlayed);
        }
        [Test]
        public void Start_New_Music()
        {
            // ARRANGE
            List<string> playList = new List<string> {
                "staing alive",
                "smooth criminal",
                "killer queen",
                "boombastic",
            };
            var player = new Player(playList);
            var ch = player.Ch;
            var musicBefor = player.MusicPlayed; 
            // ACT
            player.Next();
            player.Play();

            // ASSERT
            Assert.AreNotEqual(ch, player.Ch);
            Assert.AreNotEqual(musicBefor, player.MusicPlayed);
        }
        [Test]
        public void Music_plaing() {

            // ARRANGE
            List<string> playList = new List<string> {
                "staing alive",
                "smooth criminal",
                "killer queen",
                "boombastic",
            };
            var player = new Player(playList);

            // ACT
            player.MusicPlay();

            // ASSERT
            Assert.AreEqual(0, player.MusicPlayedIndex);
            Assert.AreEqual(PlayerStatus.new_music, player.Status);
            Assert.AreEqual(playList[0], player.MusicPlayed);
        }
        [Test]
        public void Music_plaing_abord()
        {

            // ARRANGE
            List<string> playList = new List<string> {
                "staing alive",
                "smooth criminal",
                "killer queen",
                "boombastic",
            };
            var player = new Player(playList);

            // ACT
            player.Stop();
            player.MusicPlay();

            // ASSERT
            Assert.AreEqual(PlayerStatus.pause, player.Status);
            Assert.AreEqual(0, player.MusicPlayedIndex);
            Assert.AreEqual(playList[0], player.MusicPlayed);
        }
    }
}