using System;

namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        //_____________Song_____________

        [Test]
        public void Song_Valid()
        {
            var t = new TimeSpan(0, 3, 10);
            FestivalManager.Entities.Song s = new FestivalManager.Entities.Song("Song", t);
            Assert.IsNotNull(s);
            Assert.AreEqual("Song", s.Name);
            Assert.AreEqual(t, s.Duration);
            Assert.AreEqual($"Song ({t:mm\\:ss})", s.ToString());
        }

        //_____________Performer_____________

        [Test]
        public void Performer_Valid()
        {
            FestivalManager.Entities.Performer p = new FestivalManager.Entities.Performer("Ivan", "Ivanov", 30);
            Assert.IsNotNull(p);
            Assert.AreEqual("Ivan Ivanov", p.FullName);
            Assert.AreEqual(30, p.Age);
            Assert.AreEqual(0, p.SongList.Count);
            Assert.AreEqual("Ivan Ivanov", p.ToString());
        }

        //____________Stage_________________

        [Test]
        public void Ctor_Valid()
        {
            FestivalManager.Entities.Stage s = new FestivalManager.Entities.Stage();
            Assert.AreEqual(0, s.Performers.Count);
        }

        [Test]
        public void Add_Performer_Null()
        {
            FestivalManager.Entities.Stage s = new FestivalManager.Entities.Stage();
            Assert.Throws<ArgumentNullException>(() => { s.AddPerformer(null); });
        }

        [Test]
        public void Add_Performer_Below_18()
        {
            FestivalManager.Entities.Stage s = new FestivalManager.Entities.Stage();
            Assert.Throws<ArgumentException>(() => { s.AddPerformer(new FestivalManager.Entities.Performer("Ivan", "Ivanov", 16)); });
        }
        [Test]
        public void Add_Performer_Valid()
        {
            FestivalManager.Entities.Stage s = new FestivalManager.Entities.Stage();
            s.AddPerformer(new FestivalManager.Entities.Performer("Ivan", "Ivanov", 20));
            Assert.AreEqual(1, s.Performers.Count);
        }

        [Test]
        public void Add_Song_Null()
        {
            FestivalManager.Entities.Stage s = new FestivalManager.Entities.Stage();
            Assert.Throws<ArgumentNullException>(() => { s.AddSong(null); });
        }

        [Test]
        public void Add_Song_Below_1min()
        {
            FestivalManager.Entities.Stage s = new FestivalManager.Entities.Stage();
            Assert.Throws<ArgumentException>(() => { s.AddSong(new FestivalManager.Entities.Song("Song", new TimeSpan(0, 0, 30))); });
        }
        [Test]
        public void Add_Song_To_Performer_Valid()
        {
            var t = new TimeSpan(0, 3, 10);
            FestivalManager.Entities.Stage stage = new FestivalManager.Entities.Stage();
            FestivalManager.Entities.Performer p = new FestivalManager.Entities.Performer("Ivan", "Ivanov", 20);
            FestivalManager.Entities.Song s = new FestivalManager.Entities.Song("Song", t);
            stage.AddPerformer(p);
            stage.AddSong(s);
            string result = stage.AddSongToPerformer(s.Name, p.FullName);
            Assert.AreEqual($"{s} will be performed by {p}", result);
        }

        [Test]
        [TestCase(null, "Ivan Ivanov")]
        [TestCase("Song", null)]
        public void Add_Song_To_Performer_Names_Null(string songName, string performerName)
        {
            FestivalManager.Entities.Stage stage = new FestivalManager.Entities.Stage();
            Assert.Throws<ArgumentNullException>(() => { string result = stage.AddSongToPerformer(songName, performerName); });

        }

        [Test]
        [TestCase("Invalid Song", "Ivan Ivanov")]
        [TestCase("Song", "Invalid Name")]
        public void Add_Song_To_Performer_Names_Not_Foundl(string songName, string performerName)
        {
            FestivalManager.Entities.Stage stage = new FestivalManager.Entities.Stage();
            stage.AddSong(new FestivalManager.Entities.Song("Song", new TimeSpan(0, 1, 30)));
            stage.AddPerformer(new FestivalManager.Entities.Performer("Ivan", "Ivanov", 20));
            Assert.Throws<ArgumentException>(() => { string result = stage.AddSongToPerformer(songName, performerName); });

        }

        [Test]
        public void Play_Valid()
        {
            var t = new TimeSpan(0, 3, 10);
            FestivalManager.Entities.Stage stage = new FestivalManager.Entities.Stage();
            FestivalManager.Entities.Performer p = new FestivalManager.Entities.Performer("Ivan", "Ivanov", 20);
            FestivalManager.Entities.Song s = new FestivalManager.Entities.Song("Song", t);
            stage.AddPerformer(p);
            stage.AddSong(s);
            stage.AddSongToPerformer(s.Name, p.FullName);
            string result = stage.Play();
            Assert.AreEqual(result, "1 performers played 1 songs");
        }

    }
}